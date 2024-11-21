using AutoMapper;
using Boo_Store_Portal_Api.Dto;
using Boo_Store_Portal_Api.Models;

namespace Boo_Store_Portal_Api.BookMapping
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<CreatePublisherDto, Publisher>().ReverseMap();
            CreateMap<UpdatePublisherDto, Publisher>().ReverseMap();
            CreateMap<PatchPublisherDto, Publisher>().ReverseMap();
            CreateMap<Publisher, ResponsePublisherDto>().ReverseMap();

            // PubInfo Mappings
            CreateMap<CreatePubInfoDto, PubInfo>().ReverseMap();
            CreateMap<UpdatePubInfoDto, PubInfo>().ReverseMap();
            CreateMap<PatchPubInfoDto, PubInfo>().ReverseMap();
            CreateMap<PubInfo, ResponsePubInfoDto>().ReverseMap();
        }
    }
}
