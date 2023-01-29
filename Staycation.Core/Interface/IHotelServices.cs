using HotelDto.HotelManagementDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Staycation.Core.Interface
{
    public interface IHotelServices
    {
        Task<IEnumerable<HotelLandPageDto>> GetAllHotelAsync();
        Task<HotelDetailsDto> GetHotelByIdAsync(int id);
    }
}