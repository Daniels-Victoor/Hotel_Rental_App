using Staycation.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Staycation.Infrastructures.Interface
{
    public interface IHotelRepository
    {
        List<HotelMotel> AllHotelList { get; set; }

        Task<List<HotelMotel>> GetAllHotelAsync();
        Task<HotelMotel> GetHotelByIdAsyn(int Id);
        Task<bool> SaveHotelToJson();
    }
}