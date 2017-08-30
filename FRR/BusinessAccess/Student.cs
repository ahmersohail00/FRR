using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FRR.Models;
using SqlConfiguration;
using System.Data;

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

        public static List<StudentModel> LoadAllStudents()
        {
            try
            {
                ConnectionName = ("GlobalConnection", false);
                Dictionary<string, object> NewStudent = new Dictionary<string, object>();
                NewStudent.Add("Action", "Select All");
                List<StudentModel> lstStudent = new List<StudentModel>();
                DataTable dt = GetData("spStudents", NewStudent);
                if (dt.Rows.Count > 0)
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        StudentModel _Student = new StudentModel();
                        _Student.StudentID = int.Parse(dt.Rows[i]["StudentID"].ToString());
                        _Student.StudentName = dt.Rows[i]["StudentName"].ToString();
                        _Student.Address = dt.Rows[i]["Address"].ToString();
                        _Student.MobileNo = dt.Rows[i]["MobileNo"].ToString();
                        _Student.IsActive = bool.Parse(dt.Rows[i]["IsActive"].ToString());
                        _Student.RollNo = dt.Rows[i]["RollNo"].ToString();
                        _Student.ClassID = int.Parse(dt.Rows[i]["ClassID"].ToString());
                        _Student.BranchID = int.Parse(dt.Rows[i]["BranchID"].ToString());
                        _Student.EntryTime = DateTime.Parse(dt.Rows[i]["EntryTime"].ToString());
                        lstStudent.Add(_Student);
                    }
                return lstStudent;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
