using AutoMapper;
using UniqueIdentifier.DTOs;
using UniqueIdentifier.Entities;

namespace UniqueIdentifier.Mapper
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<Identity, IdentityDTO>().ReverseMap();
        }
    }
}
