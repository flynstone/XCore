using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using XCore.Entities;
using XCore.Entities.DataTransferObjects.Categories;
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
        private readonly XCoreDbContext _context;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public CategoriesController(
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
        public async Task<IActionResult> GetCategories()
        {
            CategoriesController categoriesController = this;
            IEnumerable<Category> categoriesAsync = await categoriesController._unitOfWork.Category.GetCategoriesAsync(false);
            IEnumerable<CategoryDto> categoryDtos = categoriesController._mapper.Map<IEnumerable<CategoryDto>>((object)categoriesAsync);
            return (IActionResult)categoriesController.Ok((object)categoryDtos);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            CategoriesController categoriesController = this;
            Category categoryAsync = await categoriesController._unitOfWork.Category.GetCategoryAsync(categoryId, false);
            if (categoryAsync == null)
            {
                categoriesController._loggerManager.LogInfo(string.Format("Category with id: {0} doesn't exist in the database.", (object)categoryId));
                return (IActionResult)categoriesController.NotFound();
            }
            CategoryDto categoryDto = categoriesController._mapper.Map<CategoryDto>((object)categoryAsync);
            return (IActionResult)categoriesController.Ok((object)categoryDto);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryForCreationDto>> CreateCategory(
          [FromBody] CategoryForCreationDto category)
        {
            CategoriesController categoriesController = this;
            Category categoryEntity = categoriesController._mapper.Map<Category>((object)category);
            categoriesController._unitOfWork.Category.CreateCategory(categoryEntity);
            await categoriesController._unitOfWork.SaveAsync();
            ActionResult<CategoryForCreationDto> actionResult = (ActionResult<CategoryForCreationDto>)(ActionResult)categoriesController.CreatedAtAction(nameof(CreateCategory), (object)new
            {
                categoryId = categoryEntity.CategoryId
            }, (object)categoryEntity);
            categoryEntity = (Category)null;
            return actionResult;
        }

        [HttpPut("{categoryId:int}")]
        public async Task<ActionResult> UpdateCategory(
          int categoryId,
          [FromBody] CategoryForUpdateDto category)
        {
            CategoriesController categoriesController = this;
            Category entity = categoriesController._mapper.Map<Category>((object)category);
            entity.CategoryId = categoryId;
            categoriesController._context.Entry<Category>(entity).State = EntityState.Modified;
            await categoriesController._unitOfWork.SaveAsync();
            return (ActionResult)categoriesController.NoContent();
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            CategoriesController categoriesController = this;
            Category categoryAsync = await categoriesController._unitOfWork.Category.GetCategoryAsync(categoryId, false);
            if (categoryAsync == null)
            {
                categoriesController._loggerManager.LogError(string.Format("Category with id: {0} doesn't exist in the database", (object)categoryId));
                return (IActionResult)categoriesController.NotFound();
            }
            categoriesController._unitOfWork.Category.DeleteCategory(categoryAsync);
            await categoriesController._unitOfWork.SaveAsync();
            return (IActionResult)categoriesController.NoContent();
        }
    }
}
