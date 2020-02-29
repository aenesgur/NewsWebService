using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.ClassLibrary
{
    public class Entities
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Spot { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public string Category { get; set; }
        public DateTime CreatingDate { get; set; }
        public int OrderOfAdding { get; set; }
    }
}
