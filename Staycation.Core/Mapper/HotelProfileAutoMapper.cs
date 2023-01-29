using AutoMapper;
using HotelDto.HotelManagementDto;
using Staycation.Domain.Model;

namespace Staycation.Core.Mapper
{
    public class HotelProfileAutoMapper : Profile
    {
        public HotelProfileAutoMapper()
        {

            CreateMap<HotelMotel, HotelLandPageDto>().ReverseMap();
            CreateMap<HotelMotel, HotelDetailsDto>().ReverseMap();

        }
     
      
    }
}
