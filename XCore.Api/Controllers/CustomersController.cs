using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using XCore.Api.Extensions;
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
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CustomersController(IUnitOfWork unitOfWork, ILoggerManager logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customer = await _unitOfWork.Customer.GetCustomersAsync(trackChanges: false);

            var customersDto = _mapper.Map<IEnumerable<CustomerDto>>(customer);

            return Ok(customersDto);
        }

        // GET: api/customers/5
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer(int customerId)
        {
            var customer = await _unitOfWork.Customer.GetCustomerAsync(customerId, trackChanges: false);

            // Make sure customer exists, handle error if not found
            if (customer == null)
            {
                _logger.LogInfo($"Customer with id: {customerId} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var customerDto = _mapper.Map<CustomerDto>(customer);
                return Ok(customerDto);
            }
        }

        // POST: api/customers
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<CustomerForCreationDto>> CreateCustomer([FromBody] CustomerForCreationDto customer)
        {
            var customerEntity = _mapper.Map<Customer>(customer);

            _unitOfWork.Customer.CreateCustomer(customerEntity);
            await _unitOfWork.SaveAsync();

            var customerToReturn = _mapper.Map<CustomerDto>(customerEntity);

            return CreatedAtRoute("CustomerId", new { customerId = customerToReturn.CustomerId }, customerToReturn);
        }

        // PUT: api/customers/5
        [HttpPut("{customerId:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> UpdateCustomer(int customerId, [FromBody] CustomerForUpdateDto customer)
        {
            if (customerId != customer.CustomerId)
            {
                _logger.LogInfo($"Customer with id: {customerId} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var customerEntity = HttpContext.Items["customer"] as Customer;

                _mapper.Map(customer, customerEntity);
                await _unitOfWork.SaveAsync();

                return NoContent();
            }
        }

        // DELETE: api/customers/5
        [HttpDelete("{customerId:int}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInfo($"Customer with id: {customerId} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var customer = HttpContext.Items["customer"] as Customer;

                _unitOfWork.Customer.DeleteCustomer(customer);
                await _unitOfWork.SaveAsync();

                return NoContent();
            }
        }
    }
}
