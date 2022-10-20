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
        //private readonly IRepository<DishOrder> _dishOrderRepository;
        private readonly IRepository<Dish> _dishRepository;
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Order> _orderRepository;

        public ReportController(
            IRepository<Dish> dishRepository,
            IRepository<Person> personRepository,
            IRepository<Order> orderRepository)
        {
            
            _dishRepository = dishRepository;
            _personRepository = personRepository;
            _orderRepository = orderRepository;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> RequestReport()
        {
            //var filePath = $"C:\\Users\\stoya\\source\\repos\\FormsService\\FormsService\\logs\\{fileName}"; // get file full path based on file name
            //if (!System.IO.File.Exists(filePath))
            //{
            //    return BadRequest();
            //}
            var inputTemplatePath =
                "C:\\Users\\student\\source\\repos\\FormsService\\FormsService\\Reports\\InputDoc.docx";
            var outputPath =
                "C:\\Users\\student\\source\\repos\\FormsService\\FormsService\\Reports\\OutputDoc.docx";
            
            var orders = await _orderRepository.GetAll();
           



            System.IO.File.Delete(outputPath);
            System.IO.File.Copy(inputTemplatePath, outputPath);
            var tableContent = new TableContent("OrdersTable");
            var valuesToFill = new Content();
            int j = 1;
            foreach (var order in orders)
            {
                valuesToFill.Tables.Add(tableContent.AddRow(new FieldContent("Number", j.ToString())));
                valuesToFill.Tables.Add(tableContent.AddRow(new FieldContent("Name", order.Person.Name)));
                valuesToFill.Tables.Add(tableContent.AddRow(new FieldContent("YesNo", order.Location == Location.WithMe ? "Да" : "")));
                valuesToFill.Tables.Add(tableContent.AddRow(new FieldContent("Dishes", order.Dishes.ToString())));
            }
            

            //var valuesToFill = new Content(
            //    new FieldContent("ReportDate", DateTime.Now.Date.ToShortDateString()),
            //    new TableContent("OrdersTable")
            //        .AddRow(
            //            new FieldContent("Number", "1"),
            //            new FieldContent("Name", "Семёнов Илья Васильевич"),
            //            new FieldContent("YesNo", "Нет"),
            //            new FieldContent("Dishes", "Салат Борщ"))
            //        .AddRow(
            //            new FieldContent("Number", "2"),
            //            new FieldContent("Name", "Петров Фёдор Анатольевич"),
            //            new FieldContent("YesNo", "Да"),
            //            new FieldContent("Dishes", "Салат"))
            //
            //);

            using (var outputDocument = new TemplateProcessor(outputPath)
                       .SetRemoveContentControls(true))
            {
                outputDocument.FillContent(valuesToFill);
                outputDocument.SaveChanges();
            }

            return Ok();
            //return File(await System.IO.File.ReadAllBytesAsync(filePath), "application/octet-stream", fileName);
        }

    }
}
