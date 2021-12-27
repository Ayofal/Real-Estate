using AutoMapper;
using AccessHomes.Domain.Entities;
using AccessHomes.Service.DTO.Request;
using AccessHomes.Service.DTO.Response;
using AccessHomes.Domain.Auth;
using AccessHomes.Domain.QueryParameters;

namespace AccessHomes.Infrastructure.Configs
{
    public class MappingProfileConfiguration : Profile
    {
        public MappingProfileConfiguration()
        {
            CreateMap<Person, CreatePersonRequest>().ReverseMap();
            CreateMap<Person, UpdatePersonRequest>().ReverseMap();
            CreateMap<Person, PersonQueryResponse>().ReverseMap();
            CreateMap<Student, StudentQueryResponse>().ReverseMap();

            CreateMap<CreatePropertyRequest,Properties>();
            CreateMap<Properties, UpdatePropertyRequest>();
            CreateMap<UpdatePropertyRequest, Properties>();
            CreateMap<Properties, PropertyQueryResponse>();

            CreateMap<CreateProp_AttachmentsRequest, Prop_Attachments>();
            CreateMap<Prop_Attachments, UpdateProp_AttachmentsRequest>();
            CreateMap<UpdateProp_AttachmentsRequest, Prop_Attachments>();
            CreateMap<Prop_Attachments, Prop_AttachmentsQueryResponse>();

            CreateMap<CreateAttachmentRequest, Attachments>();
            CreateMap<Attachments, UpdateAttachmentRequest>();
            CreateMap<UpdateAttachmentRequest, Attachments>();
            CreateMap<Attachments, AttachmentQueryResponse>();
            CreateMap<Ratings, AddRatingRequest>();

            CreateMap<CreateAmenityRequest, Amenities>();
            CreateMap<Amenities, UpdateAmenityRequest>();
            CreateMap<UpdateAmenityRequest, Amenities>();
            CreateMap<Amenities, AmenityQueryResponse>();
            CreateMap<AmenityQueryParameters, Amenities>();

            CreateMap<ApplicationUser, UserQueryResponse>();

            
        }
    }
}
