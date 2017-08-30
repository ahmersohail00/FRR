using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRR.Models
{
    public class FeesModel
    {
        public int VoucherNo { get; set; }
        public DateTime DateReceived { get; set; }
        public decimal AmountReceived { get; set; }
        public Month FeesMonth { get; set; }
        public int StudentID { get; set; }
        public DateTime EntryTime { get; set; }
    }
}
