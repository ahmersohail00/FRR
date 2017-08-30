using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRR.Models
{
    public class StudentModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public bool IsActive { get; set; }
        public string RollNo { get; set; }
        public int ClassID { get; set; }
        public int BranchID { get; set; }
        public DateTime EntryTime { get; set; }
    }
}
