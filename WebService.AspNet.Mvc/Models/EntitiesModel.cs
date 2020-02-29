using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.AspNet.Mvc.Models
{
    public class EntitiesModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Spot { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
    }
}