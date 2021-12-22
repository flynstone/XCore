using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using XCore.Entities;
using XCore.Entities.DataTransferObjects.Customers;
using XCore.Entities.Models.Rentals;
using XCore.LoggerService;
using XCore.Repositories.Interfaces;

namespace XCore.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly XCoreDbContext _context;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public CustomersController(
          IUnitOfWork unitOfWork,
          XCoreDbContext context,
          ILoggerManager loggerManager,
          IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._context = context;
            this._loggerManager = loggerManager;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            CustomersController customersController = this;
            IEnumerable<Customer> customersAsync = await customersController._unitOfWork.Customer.GetCustomersAsync(false);
            IEnumerable<CustomerDto> customerDtos = customersController._mapper.Map<IEnumerable<CustomerDto>>((object)customersAsync);
            return (IActionResult)customersController.Ok((object)customerDtos);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer(int customerId)
        {
            CustomersController customersController = this;
            Customer customerAsync = await customersController._unitOfWork.Customer.GetCustomerAsync(customerId, false);
            if (customerAsync == null)
            {
                customersController._loggerManager.LogInfo(string.Format("Customer with id: {0} doesn't exist in the database.", (object)customerId));
                return (IActionResult)customersController.NotFound();
            }
            CustomerDto customerDto = customersController._mapper.Map<CustomerDto>((object)customerAsync);
            return (IActionResult)customersController.Ok((object)customerDto);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerForCreationDto>> CreateCustomer(
          [FromBody] CustomerForCreationDto customer)
        {
            CustomersController customersController = this;
            Customer customerEntity = customersController._mapper.Map<Customer>((object)customer);
            customersController._unitOfWork.Customer.CreateCustomer(customerEntity);
            await customersController._unitOfWork.SaveAsync();
            ActionResult<CustomerForCreationDto> actionResult = (ActionResult<CustomerForCreationDto>)(ActionResult)customersController.CreatedAtAction(nameof(CreateCustomer), (object)new
            {
                customerId = customerEntity.CustomerId
            }, (object)customerEntity);
            customerEntity = (Customer)null;
            return actionResult;
        }

        [HttpPut("{customerId:int}")]
        public async Task<ActionResult> UpdateCustomer(
          int customerId,
          [FromBody] CustomerForUpdateDto customer)
        {
            CustomersController customersController = this;
            Customer entity = customersController._mapper.Map<Customer>((object)customer);
            entity.CustomerId = customerId;
            customersController._context.Entry<Customer>(entity).State = EntityState.Modified;
            await customersController._unitOfWork.SaveAsync();
            return (ActionResult)customersController.NoContent();
        }

        [HttpDelete("{customerId:int}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            CustomersController customersController = this;
            Customer customerAsync = await customersController._unitOfWork.Customer.GetCustomerAsync(customerId, false);
            if (customerAsync == null)
            {
                customersController._loggerManager.LogError(string.Format("Customer with id: {0} doesn't exist in the database", (object)customerId));
                return (IActionResult)customersController.NotFound();
            }
            customersController._unitOfWork.Customer.DeleteCustomer(customerAsync);
            await customersController._unitOfWork.SaveAsync();
            return (IActionResult)customersController.NoContent();
        }
    }
}
