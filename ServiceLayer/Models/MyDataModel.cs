using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class MyDataModel
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public FilterTypeEnum type { get; set; }

        //tarihi istediğim formata çevirmek için
        public string FormattedStartDate => startDate.Date.ToString("yyyy-MM-dd");
        public string FormattedEndDate => endDate.Date.ToString("yyyy-MM-dd");
    }

    // diğerinde enum olduğu için ekledim
    public enum FilterTypeEnum
    {
        Created = 0,
        Changed = 1,
        Renamed = 2,
        Deleted = 3,
    }
}
