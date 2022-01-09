using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using XCore.Api.Extensions;
using XCore.Entities.DataTransferObjects.Categories;
using XCore.Entities.DataTransferObjects.Rentals;
using XCore.Entities.Models.Rentals;
using XCore.LoggerService;
using XCore.Repositories.Interfaces;

namespace XCore.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CategoriesController(IUnitOfWork unitOfWork, ILoggerManager logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: api/categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _unitOfWork.Category.GetCategoriesAsync(trackChanges: false);

            var categoriesDto = _mapper.Map<IEnumerable<RentalDto>>(categories);

            return Ok(categoriesDto);
        }

        // GET: api/categories/5
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            var category = await _unitOfWork.Category.GetCategoryAsync(categoryId, trackChanges: false);

            // Make sure category exists, handle error if not found
            if (category == null)
            {
                _logger.LogInfo($"Category with id: {categoryId} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var categoryDto = _mapper.Map<CategoryDto>(category);
                return Ok(categoryDto);
            }
        }

        // POST: api/categories
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<CategoryForCreationDto>> CreateCategory([FromBody] CategoryForCreationDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);

            _unitOfWork.Category.CreateCategory(categoryEntity);
            await _unitOfWork.SaveAsync();

            var categoryToReturn = _mapper.Map<RentalDto>(categoryEntity);

            return CreatedAtRoute("CategoryId", new { categoryId = categoryToReturn.CategoryId }, categoryToReturn);
        }

        // PUT: api/categories/5
        [HttpPut("{categoryId:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> UpdateCategory(int categoryId, [FromBody] CategoryForUpdateDto category)
        {
            if (categoryId != category.CategoryId)
            {
                _logger.LogInfo($"Category with id: {categoryId} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var categoryEntity = HttpContext.Items["category"] as Category;

                _mapper.Map(category, categoryEntity);
                await _unitOfWork.SaveAsync();

                return NoContent();
            }
        }

        // DELETE: api/categories/5
        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInfo($"Category with id: {categoryId} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var category = HttpContext.Items["category"] as Category;

                _unitOfWork.Category.DeleteCategory(category);
                await _unitOfWork.SaveAsync();

                return NoContent();
            }
        }
    }
}
