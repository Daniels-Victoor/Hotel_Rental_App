
using Newtonsoft.Json.Linq;
using Staycation.Domain.Model;
using Staycation.Infrastructures.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Staycation.Infrastructure.Repository
{
    public class HotelRepository : IHotelRepository
    {
        readonly string _dataStoreLocation = Path.Combine($"{new DirectoryInfo(".").Parent}", "Staycation.Infrastructures/DataStore");

        private List<HotelMotel> _allHotelList = new List<HotelMotel>();
        private readonly IJsonHelper _jsonHelper;

        public HotelRepository( IJsonHelper jsonHelper)
        {
          _jsonHelper = jsonHelper;
        }

        public List<HotelMotel> AllHotelList
        {
            get { return _allHotelList; }
            set { _allHotelList = value; }
        }

        public async Task<List<HotelMotel>> GetAllHotelAsync()
        {
            string fileLocation = Path.Combine(_dataStoreLocation, "Hotel.json");
            AllHotelList = await _jsonHelper.Reader<List<HotelMotel>>(fileLocation);
            return AllHotelList;
        }

        public async Task<bool> SaveHotelToJson()
        {
            string fileLocation = Path.Combine(_dataStoreLocation, "Hotel.json");

            try
            {
               await _jsonHelper.Writer<List<HotelMotel>>(fileLocation, AllHotelList);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<HotelMotel> GetHotelByIdAsyn(int Id)
        {
            var HotelList = await GetAllHotelAsync();
            return HotelList.Find(x => x.HotelId == Id);
        }
    }
}
