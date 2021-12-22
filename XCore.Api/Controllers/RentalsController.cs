using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using XCore.Entities;
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
        private readonly XCoreDbContext _context;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public RentalsController(
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
        public async Task<IActionResult> GetRentals()
        {
            RentalsController rentalsController = this;
            IEnumerable<Rental> rentalsAsync = await rentalsController._unitOfWork.Rental.GetRentalsAsync(false);
            IEnumerable<RentalDto> rentalDtos = rentalsController._mapper.Map<IEnumerable<RentalDto>>((object)rentalsAsync);
            return (IActionResult)rentalsController.Ok((object)rentalDtos);
        }

        [HttpGet("{rentalId}")]
        public async Task<IActionResult> GetRental(int rentalId)
        {
            RentalsController rentalsController = this;
            Rental rentalAsync = await rentalsController._unitOfWork.Rental.GetRentalAsync(rentalId, false);
            if (rentalAsync == null)
            {
                rentalsController._loggerManager.LogInfo(string.Format("Rental with id: {0} doesn't exist in the database.", (object)rentalId));
                return (IActionResult)rentalsController.NotFound();
            }
            RentalDto rentalDto = rentalsController._mapper.Map<RentalDto>((object)rentalAsync);
            return (IActionResult)rentalsController.Ok((object)rentalDto);
        }

        [HttpPost]
        public async Task<ActionResult<RentalForCreationDto>> CreateRental(
          [FromBody] RentalForCreationDto rental)
        {
            RentalsController rentalsController = this;
            Rental rentalEntity = rentalsController._mapper.Map<Rental>((object)rental);
            rentalsController._unitOfWork.Rental.CreateRental(rentalEntity);
            await rentalsController._unitOfWork.SaveAsync();
            ActionResult<RentalForCreationDto> actionResult = (ActionResult<RentalForCreationDto>)(ActionResult)rentalsController.CreatedAtAction(nameof(CreateRental), (object)new
            {
                RentalId = rentalEntity.RentalId
            }, (object)rentalEntity);
            rentalEntity = (Rental)null;
            return actionResult;
        }

        [HttpPut("{rentalId:int}")]
        public async Task<ActionResult> UpdateRental(
          int rentalId,
          [FromBody] RentalForUpdateDto rental)
        {
            RentalsController rentalsController = this;
            Rental entity = rentalsController._mapper.Map<Rental>((object)rental);
            entity.RentalId = rentalId;
            rentalsController._context.Entry<Rental>(entity).State = EntityState.Modified;
            await rentalsController._unitOfWork.SaveAsync();
            return (ActionResult)rentalsController.NoContent();
        }

        [HttpDelete("{rentalId}")]
        public async Task<IActionResult> DeleteRental(int rentalId)
        {
            RentalsController rentalsController = this;
            Rental rentalAsync = await rentalsController._unitOfWork.Rental.GetRentalAsync(rentalId, false);
            if (rentalAsync == null)
            {
                rentalsController._loggerManager.LogError(string.Format("Rental with id: {0} doesn't exist in the database", (object)rentalId));
                return (IActionResult)rentalsController.NotFound();
            }
            rentalsController._unitOfWork.Rental.DeleteRental(rentalAsync);
            await rentalsController._unitOfWork.SaveAsync();
            return (IActionResult)rentalsController.NoContent();
        }

        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            RentalsController rentalsController = this;
            IEnumerable<Customer> customersAsync = await rentalsController._unitOfWork.Customer.GetCustomersAsync(false);
            IEnumerable<CustomerDto> customerDtos = rentalsController._mapper.Map<IEnumerable<CustomerDto>>((object)customersAsync);
            return (IActionResult)rentalsController.Ok((object)customerDtos);
        }

        [HttpGet("medias")]
        public async Task<IActionResult> GetMedias()
        {
            RentalsController rentalsController = this;
            IEnumerable<Media> mediasAsync = await rentalsController._unitOfWork.Media.GetMediasAsync(false);
            IEnumerable<MediaDto> mediaDtos = rentalsController._mapper.Map<IEnumerable<MediaDto>>((object)mediasAsync);
            return (IActionResult)rentalsController.Ok((object)mediaDtos);
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            RentalsController rentalsController = this;
            IEnumerable<Category> categoriesAsync = await rentalsController._unitOfWork.Category.GetCategoriesAsync(false);
            IEnumerable<CategoryDto> categoryDtos = rentalsController._mapper.Map<IEnumerable<CategoryDto>>((object)categoriesAsync);
            return (IActionResult)rentalsController.Ok((object)categoryDtos);
        }
    }
}

