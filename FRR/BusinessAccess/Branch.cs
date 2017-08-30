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
    public class Branch : SqlData
    {
        public static List<BranchModel> LoadAllBranches()
        {
            try
            {
                ConnectionName = ("GlobalConnection", false);
                Dictionary<string, object> NewBranch = new Dictionary<string, object>();
                NewBranch.Add("Action", "Select All");
                List<BranchModel> lstBranch = new List<BranchModel>();
                DataTable dt = GetData("spBranches", NewBranch);
                if (dt.Rows.Count > 0)
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        BranchModel _Branch = new BranchModel();
                        _Branch.BranchID = int.Parse(dt.Rows[i]["BranchID"].ToString());
                        _Branch.BranchName = dt.Rows[i]["BranchName"].ToString();
                        lstBranch.Add(_Branch);
                    }
                return lstBranch;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void LoadBranches(System.Windows.Forms.ComboBox cmb)
        {
            try
            {
                List<BranchModel> _Branch = GlobalData.AllBranches;
                _Branch.Insert(0, new BranchModel() { BranchID = 0, BranchName = "Select Branch" });
                cmb.DataSource = _Branch;
                cmb.DisplayMember = "BranchName";
                cmb.ValueMember = "BranchID";
                cmb.SelectedIndex = 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string LoadBranchByID(int ID)
        {
            try
            {
                return GlobalData.AllBranches.Where(a => a.BranchID == ID).ToArray()[0].BranchName;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
