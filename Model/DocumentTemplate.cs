using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DocumentTemplate
    {
        public String HeaderCsHtml { get; set; }
        public String BodyCsHtml { get; set; }
        public String FooterCsHtml { get; set; }

        public InvoicePdfGenerationDetails InvoicePdfGenerationDetails { get; set; }
    }
}
