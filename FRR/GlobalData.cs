using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FRR
{
    static class GlobalData
    {
        public static int BranchID { get; set; }
        public static List<Models.ClassModel> AllClasses { get; set; }
        public static List<Models.BranchModel> AllBranches { get; set; }
        public static List<Models.StudentModel> AllStudents { get; set; }

        /// <summary>
        /// Extension method to validate that input text is a number.
        /// </summary>
        /// <param name="e">Key Press Event Initialization.</param>
        /// <param name="IsCalculation">if true then decimal point (.) is allowed, if false then decimal point (.) is not allowed</param>
        public static void ValidateNumber(this TextBox txt, KeyPressEventArgs e, bool IsCalculation)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                if (e.KeyChar == '.' && IsCalculation)
                    if (txt.Text.IndexOf('.') > -1)
                        e.Handled = true;
                    else e.Handled = false;
                else e.Handled = true;
        }

        public static string ValidateControls(this Form F)
        {
            string Message = "";
            for (int i = 0; i < F.Controls.Count; i++)
            {
                Control c = F.Controls[i];
                if (c.TabStop && c.Tag != null && string.IsNullOrWhiteSpace(c.Tag.ToString()))
                    if (c.GetType() == typeof(TextBox))
                    {
                        if (string.IsNullOrWhiteSpace(c.Text)) Message = $"{c.Tag} is Empty!!!";
                    }
                    else if (c.GetType() == typeof(ComboBox))
                    {
                        if ((c as ComboBox).SelectedIndex == 0) Message = $"Please Select {c.Tag}!!!";
                    }
                if (!string.IsNullOrWhiteSpace(Message)) break; else continue;
            }
            return Message;
        }

        /// <summary>
        /// Extension method to write list data to Microsoft.Office.Interop.Excel File.
        /// </summary>
        /// <typeparam name="T">Ganeric list</typeparam>
        /// <param name="list"></param>
        /// <param name="PathToSave">Path to save file.</param>
        public static void ToExcel<T>(this List<T> list, string PathToSave)
        {
            #region Declarations

            if (string.IsNullOrEmpty(PathToSave))
            {
                throw new Exception("Invalid file path.");
            }
            else if (PathToSave.ToLower().Contains("") == false)
            {
                throw new Exception("Invalid file path.");
            }

            if (list == null)
            {
                throw new Exception("No data to export.");
            }

            Microsoft.Office.Interop.Excel.Application excelApp = null;
            Microsoft.Office.Interop.Excel.Workbooks books = null;
            Microsoft.Office.Interop.Excel._Workbook book = null;
            Microsoft.Office.Interop.Excel.Sheets sheets = null;
            Microsoft.Office.Interop.Excel._Worksheet sheet = null;
            Microsoft.Office.Interop.Excel.Range range = null;
            Microsoft.Office.Interop.Excel.Font font = null;
            // Optional argument variable
            object optionalValue = Missing.Value;

            string strHeaderStart = "A2";
            string strDataStart = "A3";
            #endregion

            #region Processing


            try
            {
                #region Init Microsoft.Office.Interop.Excel app.


                excelApp = new Microsoft.Office.Interop.Excel.Application();
                books = (Microsoft.Office.Interop.Excel.Workbooks)excelApp.Workbooks;
                book = (Microsoft.Office.Interop.Excel._Workbook)(books.Add(optionalValue));
                sheets = (Microsoft.Office.Interop.Excel.Sheets)book.Worksheets;
                sheet = (Microsoft.Office.Interop.Excel._Worksheet)(sheets.get_Item(1));

                #endregion

                #region Creating Header


                Dictionary<string, string> objHeaders = new Dictionary<string, string>();

                PropertyInfo[] headerInfo = typeof(T).GetProperties();


                foreach (var property in headerInfo)
                {
                    var attribute = property.GetCustomAttributes(typeof(DisplayNameAttribute), false)
                                            .Cast<DisplayNameAttribute>().FirstOrDefault();
                    objHeaders.Add(property.Name, attribute == null ?
                                        property.Name : attribute.DisplayName);
                }


                range = sheet.get_Range(strHeaderStart, optionalValue);
                range = range.get_Resize(1, objHeaders.Count);

                range.set_Value(optionalValue, objHeaders.Values.ToArray());
                range.BorderAround(Type.Missing, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);

                font = range.Font;
                font.Bold = true;
                range.Interior.Color = Color.LightGray.ToArgb();

                #endregion

                #region Writing data to cell


                int count = list.Count;
                object[,] objData = new object[count, objHeaders.Count];

                for (int j = 0; j < count; j++)
                {
                    var item = list[j];
                    int i = 0;
                    foreach (KeyValuePair<string, string> entry in objHeaders)
                    {
                        var y = typeof(T).InvokeMember(entry.Key.ToString(), BindingFlags.GetProperty, null, item, null);
                        objData[j, i++] = (y == null) ? "" : y.ToString();
                    }
                }


                range = sheet.get_Range(strDataStart, optionalValue);
                range = range.get_Resize(count, objHeaders.Count);

                range.set_Value(optionalValue, objData);
                range.BorderAround(Type.Missing, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);

                range = sheet.get_Range(strHeaderStart, optionalValue);
                range = range.get_Resize(count + 1, objHeaders.Count);
                range.Columns.AutoFit();

                #endregion

                #region Saving data and Opening Microsoft.Office.Interop.Excel file.


                if (string.IsNullOrEmpty(PathToSave) == false)
                    book.SaveCopyAs(PathToSave);

                excelApp.Visible = true;

                #endregion

                #region Release objects

                try
                {
                    if (sheet != null)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                    sheet = null;

                    if (sheets != null)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(sheets);
                    sheets = null;

                    if (book != null)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
                    book = null;

                    if (books != null)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(books);
                    books = null;

                    if (excelApp != null)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                    excelApp = null;
                }
                catch (Exception ex)
                {
                    sheet = null;
                    sheets = null;
                    book = null;
                    books = null;
                    excelApp = null;
                }
                finally
                {
                    GC.Collect();
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion
        }

        public enum eHashType
        {
            HMAC, MD5, SHA1, SHA256, SHA384, SHA512
        }

        private static byte[] GetHash(string input, eHashType hash)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);

            switch (hash)
            {
                case eHashType.HMAC:
                    return HMAC.Create().ComputeHash(inputBytes);

                case eHashType.MD5:
                    return MD5.Create().ComputeHash(inputBytes);

                case eHashType.SHA1:
                    return SHA1.Create().ComputeHash(inputBytes);

                case eHashType.SHA256:
                    return SHA256.Create().ComputeHash(inputBytes);

                case eHashType.SHA384:
                    return SHA384.Create().ComputeHash(inputBytes);

                case eHashType.SHA512:
                    return SHA512.Create().ComputeHash(inputBytes);

                default:
                    return inputBytes;
            }
        }

        /// <summary>
        /// Computes the hash of the string using a specified hash algorithm
        /// </summary>
        /// <param name="input">The string to hash</param>
        /// <param name="hashType">The hash algorithm to use</param>
        /// <returns>The resulting hash or an empty string on error</returns>
        public static string ComputeHash(this string input, eHashType hashType)
        {
            try
            {
                byte[] hash = GetHash(input, hashType);
                StringBuilder ret = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                    ret.Append(hash[i].ToString("x2"));

                return ret.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        public static IEnumerable<IEnumerable<T>> Transpose<T>(this IEnumerable<IEnumerable<T>> values)
        {
            if (values.Count() == 0)
                return values;
            if (values.First().Count() == 0)
                return Transpose(values.Skip(1));

            var x = values.First().First();
            var xs = values.First().Skip(1);
            var xss = values.Skip(1);
            return
             new[] {new[] {x}
           .Concat(xss.Select(ht => ht.First()))}
               .Concat(new[] { xs }
               .Concat(xss.Select(ht => ht.Skip(1)))
               .Transpose());
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
        {
            var r = new Random((int)DateTime.Now.Ticks);
            return list
                .Select(x => new { Number = r.Next(), Item = x })
                .OrderBy(x => x.Number)
                .Select(x => x.Item)
                .ToList();
        }

        public const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern Int32 SendMessage(this IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        public static void SearchBox(this TextBox txt, DataGridView dgv, string SearchCriteria)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[SearchCriteria].Value.ToString().ToLower().Contains(txt.Text))
                    row.Visible = true;
                else row.Visible = false;
            }
        }

        /// <summary>
        /// Converts a string into a "SecureString"
        /// </summary>
        /// <param name="str">Input String</param>
        /// <returns></returns>
        public static System.Security.SecureString ToSecureString(this String str)
        {
            System.Security.SecureString secureString = new System.Security.SecureString();
            foreach (Char c in str)
                secureString.AppendChar(c);
            return secureString;
        }
    }
}
