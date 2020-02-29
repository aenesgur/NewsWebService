using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Console.Emlak
{
    public class EmlakEntities
    {
        public int Id { get; set; }

        public string adv_text { get; set; }
        public string adv_def_link { get; set; }
        public string adv_location { get; set; }
        public string adv_price { get; set; }
        public string adv_title { get; set; }
        public string adv_imagename { get; set; }
        public string adv_image { get; set; }
        public string adv_city_id { get; set; }
        public string adv_cityname { get; set; }
    }
}
