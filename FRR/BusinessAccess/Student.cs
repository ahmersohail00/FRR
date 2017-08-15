using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FRR.Models;
using SqlConfiguration;

namespace FRR.BusinessAccess
{
    public class Student : SqlData
    {
        public static int InsertNewStudent(StudentModel Student)
        {

            try
            {
                ConnectionName = ("GlobalConnection", false);
                Dictionary<string, object> NewStudent = new Dictionary<string, object>();
                NewStudent.Add("StudentName", Student.StudentName);
                NewStudent.Add("Address", Student.Address);
                NewStudent.Add("MobileNo", Student.MobileNo);
                NewStudent.Add("RollNo", Student.RollNo);
                NewStudent.Add("ClassID", Student.ClassID);
                NewStudent.Add("BranchID", Student.BranchID);
                NewStudent.Add("Action", "Insert");
                return ModifyData("spStudents", NewStudent);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
