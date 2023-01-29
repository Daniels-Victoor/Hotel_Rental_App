using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDto.HotelManagementDto
{
    public class HotelDetailsDto
    {
        public int HotelId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string[] Image { get; set; }

        public double Price { get; set; }

        public int Bedroom { get; set; }

        public int Livingroom { get; set; }

        public int Bathroom { get; set; }

        public int Diningroom { get; set; }

        public int Mb { get; set; }

        public int Unitready { get; set; }

        public int Refrigator { get; set; }

        public int Television { get; set; }

        public string Description { get; set; }
    }
}
