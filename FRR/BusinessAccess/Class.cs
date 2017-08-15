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
    public class Class : SqlData
    {
        private static List<ClassModel> LoadAllClasses()
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

        public static void LoadClasses(System.Windows.Forms.ComboBox cmb)
        {
            try
            {
                List<Models.ClassModel> _Class = LoadAllClasses().Where(a => a.IsActive == true).ToList();
                _Class.Insert(0, new Models.ClassModel() { ClassID = 0, ClassName = "Select Class", IsActive = true });
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
    }
}
