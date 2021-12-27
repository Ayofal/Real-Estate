using AccessHomes.Domain.Entities;
using AccessHomes.Service.Contract;
using AccessHomes.Service.DTO.Request;
using AccessHomes.Service.DTO.Response;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using AccessHomes.Infrastructure.Extension;
using AccessHomes.Domain.Settings;
using Microsoft.AspNetCore.Identity;
using AccessHomes.Domain.QueryParameters;

namespace AccessHomes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertiesRepo _propertyRepository;
        private readonly IAttachmentsRepo _attachmentRepository;
        private readonly IAmenitiesRepo _amenityRepository;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;

        public PropertiesController(IPropertiesRepo propertyRepository, IAttachmentsRepo attachmentRepository, IAmenitiesRepo amenityRepository, IPhotoService photoService, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _attachmentRepository = attachmentRepository;
            _amenityRepository = amenityRepository;
            _photoService = photoService;
            _mapper = mapper;
        }

        //GET api/properties
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyQueryResponse>>> GetAllProperties([FromQuery] PaginationParams page)
        {
            try
            {
                var propertyItems = await _propertyRepository.GetAllProperties(page);

                Response.AddPaginationHeader(propertyItems.CurrentPage, propertyItems.PageSize,
                propertyItems.TotalCount, propertyItems.TotalPages);

                return Ok(_mapper.Map<IEnumerable<PropertyQueryResponse>>(propertyItems));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }



        //GET api/properties/{id}
        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetPropertyById")]
        public async Task<ActionResult<PropertyQueryResponse>> GetPropertyById(int id)
        {
            var propertyItem = await _propertyRepository.GetPropertiesById(id);
            if (propertyItem != null)
            {
                return Ok(_mapper.Map<PropertyQueryResponse>(propertyItem));
            }
            return NotFound();
        }

        [AllowAnonymous]
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<PropertyQueryResponse>>> Search([FromQuery] PropertyQueryParameters property, [FromQuery] PaginationParams page, [FromQuery] List<AmenityQueryParameters> amenities)
        {
            try
            {
                var propertyModelFromRepo = await _propertyRepository.Search(property, page,amenities);
                Response.AddPaginationHeader(propertyModelFromRepo.CurrentPage, propertyModelFromRepo.PageSize,
                propertyModelFromRepo.TotalCount, propertyModelFromRepo.TotalPages);
                var result = _mapper.Map<IEnumerable<PropertyQueryResponse>>(propertyModelFromRepo);

                    
                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }



        [HttpPost]
        public async Task<ActionResult<PropertyQueryResponse>> CreateProperty(CreatePropertyRequest createPropertyRequest)

        {
            var propertyModel = _mapper.Map<Properties>(createPropertyRequest);
       
            propertyModel.UserId = User.FindFirst("uid").Value;

            await _propertyRepository.CreateProperties(propertyModel);
            await _propertyRepository.SaveChanges();

            var propertyQueryResponse = _mapper.Map<PropertyQueryResponse>(propertyModel);

            return CreatedAtRoute(nameof(GetPropertyById), new { id = propertyQueryResponse.Id }, propertyQueryResponse);
        }


        //PUT api/properties/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProperty(int id, UpdatePropertyRequest propertyUpdateDto)
        {
            var amenityModelFromRepo = _amenityRepository.GetAmenitiesByPropertyId(id);
            var attachmentModelFromRepo = _attachmentRepository.GetAttachmentsByPropertyId(id);
            if (amenityModelFromRepo == null)
            {
                return NotFound();
            }
            foreach (var am in amenityModelFromRepo)
            {
                _amenityRepository.DeleteAmenities(am);
            }
            if (attachmentModelFromRepo == null)
            {
                return NotFound();
            }
            foreach (var at in attachmentModelFromRepo)
            {

                _attachmentRepository.DeleteAttachments(at);
            }

            var propertyModelFromRepo = await _propertyRepository.GetPropertiesById(id);
            if (propertyModelFromRepo == null)
            {
                return NotFound();
            }

            


            _mapper.Map(propertyUpdateDto, propertyModelFromRepo);

            _propertyRepository.UpdateProperties(propertyModelFromRepo);

            await _propertyRepository.SaveChanges();

            return NoContent();
        }

        //PATCH api/properties/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialPropertyUpdate(int id,JsonPatchDocument<UpdatePropertyRequest> patchDoc)
        {
            var amenityModelFromRepo = _amenityRepository.GetAmenitiesByPropertyId(id);
            var attachmentModelFromRepo = _attachmentRepository.GetAttachmentsByPropertyId(id);
            if (amenityModelFromRepo == null)
            {
                return NotFound();
            }
            foreach (var am in amenityModelFromRepo)
            {
                _amenityRepository.DeleteAmenities(am);
            }
            if (attachmentModelFromRepo == null)
            {
                return NotFound();
            }
            foreach (var at in attachmentModelFromRepo)
            {

                _attachmentRepository.DeleteAttachments(at);
            }

            var propertyModelFromRepo = await _propertyRepository.GetPropertiesById(id);
            if (propertyModelFromRepo == null)
            {
                return NotFound();
            }

            var propertyToPatch = _mapper.Map<UpdatePropertyRequest>(propertyModelFromRepo);
            patchDoc.ApplyTo(propertyToPatch, ModelState);

            if (!TryValidateModel(propertyToPatch))
            {
                return ValidationProblem(ModelState);
            }


            

            _mapper.Map(propertyToPatch, propertyModelFromRepo);

            _propertyRepository.UpdateProperties(propertyModelFromRepo);

            await _propertyRepository.SaveChanges();

            return NoContent();
        }


        //DELETE api/properties/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProperty(int id)
        {

            var propertyModelFromRepo = await _propertyRepository.GetPropertiesById(id);
            if (propertyModelFromRepo == null)
            {
                return NotFound();
            }


            foreach (var attachment in propertyModelFromRepo.Attachments)
            {
                if (attachment.PublicId != null)
                {
                    var result = await _photoService.DeletePhotoAsync(attachment.PublicId);
                    if (result.Error != null) return BadRequest(result.Error.Message);
                }
            }


            _propertyRepository.DeleteProperties(propertyModelFromRepo);
            await _propertyRepository.SaveChanges();



            return NoContent();
        }

        [HttpPost("image/{id}")]
        public async Task<ActionResult> AddImage(List<IFormFile> file,int id)

        {
            
            List<Attachments> photos = new List<Attachments>();
            foreach (var formFile in file)
            {
                Attachments attachment = new Attachments();
                var result = await _photoService.AddPhotoAsync(formFile);

                if (result.Error != null) return BadRequest(result.Error.Message);

                attachment.ImageUrl = result.SecureUrl.AbsoluteUri;
                attachment.PublicId = result.PublicId;
                attachment.PropertiesId = id;

                photos.Add(attachment);
            }

            foreach (var at in photos)
            {
                await _attachmentRepository.CreateAttachments(at);
            }
            await _propertyRepository.SaveChanges();

            return Ok();
        }
    }
}
