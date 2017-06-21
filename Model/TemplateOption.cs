using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TemplateOption
    {
        public float? HeaderHeight { get; set; }
        public float? FooterHeight { get; set; }
        public PageBorder PageMargin { get; set; }

 
        public bool IsLandscapeOrientation { get; set; }
    }
}
