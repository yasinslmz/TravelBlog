using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlog.Models.ViewModel
{
    public class CityListViewModel
    {
        public List<City> TopCities { get; set; }
        public List<City> AllCities { get; set; }
    }
}