using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FRR.Models;
using SqlConfiguration;
using System.Data;
using System.Data.SqlClient;

namespace FRR.BusinessAccess
{
    public class Class : SqlData
    {
        public static List<ClassModel> LoadAllClasses()
        {
            try
            {
                
                ConnectionName = ("GlobalConnection", false);
                Dictionary<string, object> NewClass = new Dictionary<string, object>();
                NewClass.Add("Action", "Select All");
                List<ClassModel> lstClass = new List<ClassModel>();
                DataTable dt = GetData("spClass", NewClass);
                if (dt.Rows.Count > 0)
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ClassModel _Class = new ClassModel();
                        _Class.ClassID = int.Parse(dt.Rows[i]["ClassID"].ToString());
                        _Class.ClassName = dt.Rows[i]["ClassName"].ToString();
                        _Class.IsActive = bool.Parse(dt.Rows[i]["IsActive"].ToString());
                        lstClass.Add(_Class);
                    }
                return lstClass;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void LoadClasses(System.Windows.Forms.ComboBox cmb, bool? IsActive = true)
        {
            try
            {
                List<ClassModel> _Class = IsActive.HasValue ? GlobalData.AllClasses.Where(a => a.IsActive == IsActive.Value).ToList() : GlobalData.AllClasses;
                _Class.Insert(0, new ClassModel() { ClassID = 0, ClassName = "Select Class", IsActive = true });
                cmb.DataSource = _Class;
                cmb.DisplayMember = "ClassName";
                cmb.ValueMember = "ClassID";
                cmb.SelectedIndex = 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string LoadClassByID(int ID)
        {
            try
            {
                return GlobalData.AllClasses.Where(a => a.ClassID == ID).ToArray()[0].ClassName;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
