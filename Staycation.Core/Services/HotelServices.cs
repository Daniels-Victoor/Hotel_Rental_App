using AutoMapper;
using HotelDto.HotelManagementDto;
using Staycation.Core.Interface;
using Staycation.Infrastructures.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Staycation.Core.Services
{
    public class HotelServices : IHotelServices
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotelRepository"></param>
        /// <param name="mapper"></param>
        public HotelServices(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all the hotels in our json file
        /// </summary>
        /// <returns>an IEnumerable of Hotel Dto</returns>
        public async Task<IEnumerable<HotelLandPageDto>> GetAllHotelAsync()
        {
            var hotel = await _hotelRepository.GetAllHotelAsync();
            return _mapper.Map<IEnumerable<HotelLandPageDto>>(hotel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<HotelDetailsDto> GetHotelByIdAsync(int id)
        {
            var hotel = await _hotelRepository.GetHotelByIdAsyn(id);
            if (hotel == null)
            {
                throw new ArgumentException(nameof(hotel));
            }
            return _mapper.Map<HotelDetailsDto>(hotel);
        }
       

    }
}
