using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using XCore.Api.Extensions;
using XCore.Entities.DataTransferObjects.Categories;
using XCore.Entities.DataTransferObjects.Customers;
using XCore.Entities.DataTransferObjects.Medias;
using XCore.Entities.DataTransferObjects.Rentals;
using XCore.Entities.Models.Rentals;
using XCore.LoggerService;
using XCore.Repositories.Interfaces;

namespace XCore.Api.Controllers
{
    [Route("api/rentals")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public RentalsController(IUnitOfWork unitOfWork, ILoggerManager logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: api/rentals
        [HttpGet]
        public async Task<IActionResult> GetRentals()
        {
            var rentals = await _unitOfWork.Rental.GetRentalsAsync(trackChanges: false);

            var rentalsDto = _mapper.Map<IEnumerable<RentalDto>>(rentals);

            return Ok(rentalsDto);
        }

        // GET: api/rentals/5
        [HttpGet("{rentalId}")]
        public async Task<IActionResult> GetRental(int rentalId)
        {
            var rental = await _unitOfWork.Rental.GetRentalAsync(rentalId, trackChanges: false);

            // Make sure rental exists, handle error if not found
            if (rental == null)
            {
                _logger.LogInfo($"Rental with id: {rentalId} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var rentalDto = _mapper.Map<RentalDto>(rental);
                return Ok(rentalDto);
            }
        }

        // POST: api/rentals
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateRental([FromBody] RentalForCreationDto rental)
        {
            var rentalEntity = _mapper.Map<Rental>(rental);

            _unitOfWork.Rental.CreateRental(rentalEntity);
            await _unitOfWork.SaveAsync();

            var rentalToReturn = _mapper.Map<RentalDto>(rentalEntity);

            return CreatedAtRoute("RentalId", new { rentalId = rentalToReturn.RentalId }, rentalToReturn);
        }

        // PUT: api/rentals/5
        [HttpPut("{rentalId:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> UpdateRental(int rentalId, [FromBody] RentalForUpdateDto rental)
        {
            if (rentalId != rental.RentalId)
            {
                _logger.LogInfo($"Rental with id: {rentalId} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var rentalEntity = HttpContext.Items["rental"] as Rental;

                _mapper.Map(rental, rentalEntity);
                await _unitOfWork.SaveAsync();

                return NoContent();
            }
        }

        // DELETE: api/rentals/5
        [HttpDelete("{rentalId}")]
        public async Task<IActionResult> DeleteRental(int rentalId)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInfo($"Rental with id: {rentalId} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var rental = HttpContext.Items["rental"] as Rental;

                _unitOfWork.Rental.DeleteRental(rental);
                await _unitOfWork.SaveAsync();

                return NoContent();
            }
        }

        // ------------------------------------------------------
        // GET: Related data from different tables in database
        // ------------------------------------------------------
        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _unitOfWork.Customer.GetCustomersAsync(trackChanges: false);

            var customersDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);

            return Ok(customersDto);
        }

        [HttpGet("medias")]
        public async Task<IActionResult> GetMedias()
        {
            var medias = await _unitOfWork.Media.GetMediasAsync(trackChanges: false);

            var mediaDtos = _mapper.Map<IEnumerable<MediaDto>>(medias);

            return Ok(mediaDtos);
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _unitOfWork.Category.GetCategoriesAsync(trackChanges: false);

            var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return Ok(categoryDtos);
        }
    }
}

