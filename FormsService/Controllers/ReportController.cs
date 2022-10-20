using FormsService.DAL.Entities;
using FormsService.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TemplateEngine.Docx;

namespace FormsService.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class ReportController : Controller
    {
        private readonly IRepository<Order> _orderRepository;

        public ReportController(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> RequestReport()
        {
            var inputTemplatePath = Path.Combine(Environment.CurrentDirectory, @"Reports\InputDoc.docx");
            var outputPath = Path.Combine(Environment.CurrentDirectory, @"Reports\OutputDoc.docx");

            if (!System.IO.File.Exists(inputTemplatePath))
            {
                return BadRequest();
            }

            var orders = await _orderRepository.GetAllWithEagerLoading(order => order.Person,
                order => order.Dishes);

            System.IO.File.Delete(outputPath);
            System.IO.File.Copy(inputTemplatePath, outputPath);
            var tableContent = new TableContent("OrdersTable");

            var j = 1;

            foreach (var order in orders)
            {
                tableContent.AddRow(new FieldContent("Number", j.ToString()),
                new FieldContent("Name", order.Person.Name),
                new FieldContent("YesNo", order.Location == Location.WithMe ? "Да" : "Нет"),
                new FieldContent("Dishes", string.Join(",", order.Dishes.Select(x => x.Name))));
                j++;
            }
            var valuesToFill = new Content(tableContent);
            valuesToFill.Fields.Add(new FieldContent("ReportDate", DateTime.Now.Date.ToShortDateString()));

            using (var outputDocument = new TemplateProcessor(outputPath)
                       .SetRemoveContentControls(true))
            {
                outputDocument.FillContent(valuesToFill);
                outputDocument.SaveChanges();
            }

            return File(await System.IO.File.ReadAllBytesAsync(outputPath), "application/octet-stream", "Report.docx");
        }
    }
}