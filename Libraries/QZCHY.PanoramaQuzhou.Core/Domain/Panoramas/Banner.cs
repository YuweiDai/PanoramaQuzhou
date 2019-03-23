using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZCHY.PanoramaQuzhou.Core.Domain.Panoramas
{
    public class Banner : BaseEntity
    {
        public string Name { get; set; }

        public string NavToUrl { get; set; }        

        public string ImageUrl { get; set; }

        public int Order { get; set; }
    }
}
