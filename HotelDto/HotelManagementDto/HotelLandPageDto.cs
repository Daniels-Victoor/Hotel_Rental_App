using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDto.HotelManagementDto
{
    public class HotelLandPageDto
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool IsPopular { get; set; }
        public string[] Image { get; set; }
        public double Price { get; set; }
        public string Catergory { get; set; }
    }
}
