using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using XCore.Api.Extensions;
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
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public MediasController(IUnitOfWork unitOfWork, ILoggerManager logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: api/medias
        [HttpGet]
        public async Task<IActionResult> GetMedias()
        {
            var medias = await _unitOfWork.Media.GetMediasAsync(trackChanges: false);

            var mediasDto = _mapper.Map<IEnumerable<MediaDto>>(medias);

            return Ok(mediasDto);
        }

        // GET: api/medias/5
        [HttpGet("{mediaId}")]
        public async Task<IActionResult> GetMedia(int mediaId)
        {
            var media = await _unitOfWork.Media.GetMediaAsync(mediaId, trackChanges: false);

            // Make sure media exists, handle error if not found
            if (media == null)
            {
                _logger.LogInfo($"Media with id: {mediaId} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var mediaDto = _mapper.Map<MediaDto>(media);
                return Ok(mediaDto);
            }
        }

        // POST: api/medias
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<MediaForCreationDto>> CreateMedia([FromBody] MediaForCreationDto media)
        {
            var mediaEntity = _mapper.Map<Media>(media);

            _unitOfWork.Media.CreateMedia(mediaEntity);
            await _unitOfWork.SaveAsync();

            var mediaToReturn = _mapper.Map<MediaDto>(mediaEntity);

            return CreatedAtRoute("RentalId", new { mediaId = mediaToReturn.MediaId }, mediaToReturn);
        }

        // PUT: api/medias
        [HttpPut("{mediaId:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> UpdateMedia(int mediaId, [FromBody] MediaForUpdateDto media)
        {
            if (mediaId != media.MediaId)
            {
                _logger.LogInfo($"Media with id: {mediaId} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var mediaEntity = HttpContext.Items["media"] as Media;

                _mapper.Map(media, mediaEntity);
                await _unitOfWork.SaveAsync();

                return NoContent();
            }
        }

        // DELETE: api/medias
        [HttpDelete("{mediaId}")]
        public async Task<IActionResult> DeleteMedia(int mediaId)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInfo($"Media with id: {mediaId} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var media = HttpContext.Items["media"] as Media;

                _unitOfWork.Media.DeleteMedia(media);
                await _unitOfWork.SaveAsync();

                return NoContent();
            }
        }

        // ------------------------------------------------------
        // GET: Related data from different table in database
        // ------------------------------------------------------
        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _unitOfWork.Category.GetCategoriesAsync(trackChanges: false);

            var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return Ok(categoryDtos);
        }
    }
}
