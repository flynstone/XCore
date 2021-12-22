using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using XCore.Entities;
using XCore.Entities.DataTransferObjects.Categories;
using XCore.Entities.DataTransferObjects.Medias;
using XCore.Entities.Models.Rentals;
using XCore.LoggerService;
using XCore.Repositories.Interfaces;

namespace XCore.Api.Controllers
{
    [Route("api/medias")]
    [ApiController]
    public class MediasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly XCoreDbContext _context;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public MediasController(
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
        public async Task<IActionResult> GetMedias()
        {
            MediasController mediasController = this;
            IEnumerable<Media> mediasAsync = await mediasController._unitOfWork.Media.GetMediasAsync(false);
            IEnumerable<MediaDto> mediaDtos = mediasController._mapper.Map<IEnumerable<MediaDto>>((object)mediasAsync);
            return (IActionResult)mediasController.Ok((object)mediaDtos);
        }

        [HttpGet("{mediaId}")]
        public async Task<IActionResult> GetMedia(int mediaId)
        {
            MediasController mediasController = this;
            Media mediaAsync = await mediasController._unitOfWork.Media.GetMediaAsync(mediaId, false);
            if (mediaAsync == null)
            {
                mediasController._loggerManager.LogInfo(string.Format("Media with id: {0} doesn't exist in the database.", (object)mediaId));
                return (IActionResult)mediasController.NotFound();
            }
            MediaDto mediaDto = mediasController._mapper.Map<MediaDto>((object)mediaAsync);
            return (IActionResult)mediasController.Ok((object)mediaDto);
        }

        [HttpPost]
        public async Task<ActionResult<MediaForCreationDto>> CreateMedia(
          [FromBody] MediaForCreationDto media)
        {
            MediasController mediasController = this;
            Media mediaEntity = mediasController._mapper.Map<Media>((object)media);
            mediasController._unitOfWork.Media.CreateMedia(mediaEntity);
            await mediasController._unitOfWork.SaveAsync();
            ActionResult<MediaForCreationDto> actionResult = (ActionResult<MediaForCreationDto>)(ActionResult)mediasController.CreatedAtAction(nameof(CreateMedia), (object)new
            {
                mediaId = mediaEntity.MediaId
            }, (object)mediaEntity);
            mediaEntity = (Media)null;
            return actionResult;
        }

        [HttpPut("{mediaId:int}")]
        public async Task<ActionResult> UpdateMedia(
          int mediaId,
          [FromBody] MediaForUpdateDto media)
        {
            MediasController mediasController = this;
            Media entity = mediasController._mapper.Map<Media>((object)media);
            entity.MediaId = mediaId;
            mediasController._context.Entry<Media>(entity).State = EntityState.Modified;
            await mediasController._unitOfWork.SaveAsync();
            return (ActionResult)mediasController.NoContent();
        }

        [HttpDelete("{mediaId}")]
        public async Task<IActionResult> DeleteMedia(int mediaId)
        {
            MediasController mediasController = this;
            Media mediaAsync = await mediasController._unitOfWork.Media.GetMediaAsync(mediaId, false);
            if (mediaAsync == null)
            {
                mediasController._loggerManager.LogError(string.Format("Media with id: {0} doesn't exist in the database", (object)mediaId));
                return (IActionResult)mediasController.NotFound();
            }
            mediasController._unitOfWork.Media.DeleteMedia(mediaAsync);
            await mediasController._unitOfWork.SaveAsync();
            return (IActionResult)mediasController.NoContent();
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            MediasController mediasController = this;
            IEnumerable<Category> categoriesAsync = await mediasController._unitOfWork.Category.GetCategoriesAsync(false);
            IEnumerable<CategoryDto> categoryDtos = mediasController._mapper.Map<IEnumerable<CategoryDto>>((object)categoriesAsync);
            return (IActionResult)mediasController.Ok((object)categoryDtos);
        }
    }
}
