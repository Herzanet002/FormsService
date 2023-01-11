using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using FormsService.API.Controllers.Base;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace FormsService.API.Controllers;
public class ReportsController : ApiControllerBase
{
	private readonly IDishOrderRepository _dishOrderRepository;
	private readonly IOrderRepository _ordersRepository;
	private readonly IPersonRepository _personsRepository;
	private readonly IServiceProvider _serviceProvider;
	private readonly IWordWorkerService<Order> _wordWorkerService;

	public ReportsController(IOrderRepository ordersRepository,
		IDishOrderRepository dishOrderRepository,
		IPersonRepository personsRepository,
		IServiceProvider serviceProvider,
		IWordWorkerService<Order> wordWorkerService)
	{
		_ordersRepository = ordersRepository;
		_dishOrderRepository = dishOrderRepository;
		_personsRepository = personsRepository;
		_serviceProvider = serviceProvider;
		_wordWorkerService = wordWorkerService;
	}

	[HttpGet("DateReport")]
	[ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(BadRequestObjectResult), 400)]
	public async Task<IActionResult> RequestDateReport(int day, int month, int year)
	{
		var inputTemplatePath = Path.Combine(Environment.CurrentDirectory, @"Reports\InputDoc.docx");
		var outputPath = Path.Combine(Environment.CurrentDirectory, @"Reports\OutputDoc.docx");

		if (!System.IO.File.Exists(inputTemplatePath)) return BadRequest("File not found");

		System.IO.File.Delete(outputPath);
		System.IO.File.Copy(inputTemplatePath, outputPath);
		var date = new DateOnly(year, month, day);

		var orders = (await _ordersRepository.GetAllWithInclude(order => order.Person,
			order => order.Dishes)).Where(order => order.DateForming.Date == date.ToDateTime(TimeOnly.MinValue));

		_wordWorkerService
			.CreateReport(orders, date)
			.SaveReport(outputPath);

		return File(await System.IO.File.ReadAllBytesAsync(outputPath), "application/octet-stream", "Report.docx");
	}

	[HttpGet("MonthReport")]
	[ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(BadRequestObjectResult), 400)]
	public async Task<IActionResult> RequestMonthReport(int month, int year)
	{
		if (month == 0 && year == 0)
		{
			month = DateTime.Now.Month;
			year = DateTime.Now.Year;
		}

		if (month == 0 || year == 0) return BadRequest();

		var outputPath = Path.Combine(Environment.CurrentDirectory, @"Reports\Report.xlsx");
		var date = new DateOnly(year, month, 1);

		await _dishOrderRepository.GetAllWithInclude(p => p.Order, q => q.Order.Person);
		var employees = await _personsRepository.GetAllWithInclude(x => x.Orders!);

		using var scope = _serviceProvider.CreateScope();
		var excelWorker = scope.ServiceProvider.GetService<ExcelWorkerService<Person>>()
						  ?? throw new NullReferenceException(nameof(ExcelWorkerService<Person>));

		await excelWorker.CreateExcelReport(date, employees, outputPath);

		return Ok();
	}

	
}