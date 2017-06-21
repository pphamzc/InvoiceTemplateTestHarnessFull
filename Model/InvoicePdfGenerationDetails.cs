using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Model
{
    public class InvoicePdfGenerationDetails
    {
        public DataSet HeaderDetailsDataSet { get { return Create(); } }
        public DataSet BodyDetailsDataSet { get { return Create(); } }

        public string ImagesFolderRootPath { get; set; }

        public DataSet Create()
        {
           
            DataTable table = new DataTable();

            table.NewRow();
            DataSet set = new DataSet();

            set.Tables.Add(table);

            return set;
        }
    }
}
