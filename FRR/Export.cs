using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRR
{
    static class Export
    {
        public static void ToPDF()
        {

            Document doc = new Document(PageSize.A4);
            var output = new FileStream("D://Ahmer Sohail//Projects//Abc.pdf", FileMode.Create);
            var writer = PdfWriter.GetInstance(doc, output);
            doc.Open();
            PdfPTable MainTable = new PdfPTable(new float[] { 95F, 10F, 95F });
            PdfPTable StudentTable = Base("Student Copy");
            PdfPTable SchoolTable = Base("School Copy");

            PdfPCell MainCell1 = new PdfPCell(StudentTable);
            PdfPCell MainCell2 = new PdfPCell();
            PdfPCell MainCell3 = new PdfPCell(SchoolTable);



            MainTable.DefaultCell.Border = 0;
            MainTable.WidthPercentage = 100;

            MainTable.AddCell(MainCell1);
            MainTable.AddCell(MainCell2);
            MainTable.AddCell(MainCell3);

            //PdfPCell cell11 = new PdfPCell();
            //cell11.Colspan = 1;
            //cell11.AddElement(new Paragraph("ABC Traders Receipt"));
            //cell11.AddElement(new Paragraph("Thankyou for shoping at ABC traders,your order details are below"));


            //cell11.VerticalAlignment = Element.ALIGN_LEFT;

            //PdfPCell cell12 = new PdfPCell();


            //cell12.VerticalAlignment = Element.ALIGN_CENTER;


            //MainTable.AddCell(cell11);

            //MainTable.AddCell(cell12);


            //PdfPTable table2 = new PdfPTable(3);

            ////One row added

            //PdfPCell cell21 = new PdfPCell();

            //cell21.AddElement(new Paragraph("Photo Type"));

            //PdfPCell cell22 = new PdfPCell();

            //cell22.AddElement(new Paragraph("No. of Copies"));

            //PdfPCell cell23 = new PdfPCell();

            //cell23.AddElement(new Paragraph("Amount"));


            //table2.AddCell(cell21);

            //table2.AddCell(cell22);

            //table2.AddCell(cell23);


            ////New Row Added

            //PdfPCell cell31 = new PdfPCell();

            //cell31.AddElement(new Paragraph("Safe"));

            //cell31.FixedHeight = 300.0f;

            //PdfPCell cell32 = new PdfPCell();

            //cell32.AddElement(new Paragraph("2"));

            //cell32.FixedHeight = 300.0f;

            //PdfPCell cell33 = new PdfPCell();

            //cell33.AddElement(new Paragraph("20.00 * " + "2" + " = " + (20 * Convert.ToInt32("2")) + ".00"));

            //cell33.FixedHeight = 300.0f;



            //table2.AddCell(cell31);

            //table2.AddCell(cell32);

            //table2.AddCell(cell33);


            //PdfPCell cell2A = new PdfPCell(table2);

            //cell2A.Colspan = 2;

            //MainTable.AddCell(cell2A);

            //PdfPCell cell41 = new PdfPCell();

            //cell41.AddElement(new Paragraph("Name : " + "ABC"));

            //cell41.AddElement(new Paragraph("Advance : " + "advance"));

            //cell41.VerticalAlignment = Element.ALIGN_LEFT;

            //PdfPCell cell42 = new PdfPCell();

            //cell42.AddElement(new Paragraph("Customer ID : " + "011"));

            //cell42.AddElement(new Paragraph("Balance : " + "3993"));

            //cell42.VerticalAlignment = Element.ALIGN_RIGHT;


            //MainTable.AddCell(cell41);

            //MainTable.AddCell(cell42);


            doc.Add(MainTable);

            doc.Close();
        }

        private static PdfPTable Base(string Copy)
        {
            PdfPTable BaseTable = new PdfPTable(2);
            PdfPCell Base1 = new PdfPCell(new Phrase("Al Khalil Huffaz School\nFees Receipt\n" + Copy, FontFactory.GetFont("Arial", 16, Font.BOLD)));
            PdfPCell Base2A = new PdfPCell(new Phrase("\nNo. 00001\n\r", FontFactory.GetFont("Arial", 16, Font.NORMAL)));
            PdfPCell Base2B = new PdfPCell(new Phrase("\n"+DateTime.Today.ToString("dd-MM-yyyy")+"\n\r", FontFactory.GetFont("Arial", 16, Font.NORMAL)));
            PdfPCell Base3 = new PdfPCell(new Phrase("\nName : Ahmer Sohail\n\r", FontFactory.GetFont("Arial", 16, Font.BOLD)));
            PdfPCell Base4A = new PdfPCell(new Phrase("\nClass : P3\n\r", FontFactory.GetFont("Arial", 16, Font.NORMAL)));
            PdfPCell Base4B = new PdfPCell(new Phrase("\nA/c No. 305\n\r", FontFactory.GetFont("Arial", 16, Font.NORMAL)));

            PdfPTable SubBaseTable = new PdfPTable(new float[] { 76F, 19F });
            
            PdfPCell Base5A = new PdfPCell(new Phrase("\nDetails", FontFactory.GetFont("Arial", 16, Font.BOLD)));
            PdfPCell Base5B = new PdfPCell(new Phrase("\nRs.", FontFactory.GetFont("Arial", 16, Font.BOLD)));
            PdfPCell Base6A = new PdfPCell(new Phrase("Amount for the month of: , 2017\n\r", FontFactory.GetFont("Arial", 16, Font.NORMAL)));
            PdfPCell Base6B = new PdfPCell(new Phrase("\n2000\n\r", FontFactory.GetFont("Arial", 16, Font.NORMAL)));
            PdfPCell Base7A = new PdfPCell(new Phrase("\nTotal\n\r", FontFactory.GetFont("Arial", 16, Font.BOLD)));
            PdfPCell Base7B = new PdfPCell(new Phrase("\n2000\n\r", FontFactory.GetFont("Arial", 16, Font.BOLD)));

            Base1.Padding = 5;
            Base1.HorizontalAlignment = Element.ALIGN_CENTER;
            Base1.VerticalAlignment = Element.ALIGN_MIDDLE;
            Base1.Colspan = 2;

            Base2A.HorizontalAlignment = Element.ALIGN_CENTER;
            Base2A.VerticalAlignment = Element.ALIGN_MIDDLE;
            Base2A.Padding = 2;

            Base2B.HorizontalAlignment = Element.ALIGN_CENTER;
            Base2B.VerticalAlignment = Element.ALIGN_MIDDLE;
            Base2B.Padding = 2;

            Base3.HorizontalAlignment = Element.ALIGN_CENTER;
            Base3.VerticalAlignment = Element.ALIGN_MIDDLE;
            Base3.Colspan = 2;

            Base4A.HorizontalAlignment = Element.ALIGN_CENTER;
            Base4A.VerticalAlignment = Element.ALIGN_MIDDLE;
            Base4A.Padding = 2;

            Base4B.HorizontalAlignment = Element.ALIGN_CENTER;
            Base4B.VerticalAlignment = Element.ALIGN_MIDDLE;
            Base4B.Padding = 2;

            Base5A.HorizontalAlignment = Element.ALIGN_CENTER;
            Base5A.VerticalAlignment = Element.ALIGN_BOTTOM;
            Base5A.Padding = 2;

            Base5B.HorizontalAlignment = Element.ALIGN_CENTER;
            Base5B.VerticalAlignment = Element.ALIGN_BOTTOM;
            Base5B.Padding = 2;

            Base6A.HorizontalAlignment = Element.ALIGN_LEFT;
            Base6A.VerticalAlignment = Element.ALIGN_MIDDLE;
            Base6A.Padding = 2;

            Base6B.HorizontalAlignment = Element.ALIGN_CENTER;
            Base6B.VerticalAlignment = Element.ALIGN_MIDDLE;
            Base6B.Padding = 2;

            Base7A.HorizontalAlignment = Element.ALIGN_RIGHT;
            Base7A.VerticalAlignment = Element.ALIGN_MIDDLE;
            Base7A.Padding = 2;

            Base7B.HorizontalAlignment = Element.ALIGN_CENTER;
            Base7B.VerticalAlignment = Element.ALIGN_MIDDLE;
            Base7B.Padding = 2;

            BaseTable.AddCell(Base1);
            BaseTable.AddCell(Base2A);
            BaseTable.AddCell(Base2B);
            BaseTable.AddCell(Base3);
            BaseTable.AddCell(Base4A);
            BaseTable.AddCell(Base4B);

            SubBaseTable.AddCell(Base5A);
            SubBaseTable.AddCell(Base5B);
            SubBaseTable.AddCell(Base6A);
            SubBaseTable.AddCell(Base6B);
            SubBaseTable.AddCell(Base7A);
            SubBaseTable.AddCell(Base7B);

            PdfPCell Base5 = new PdfPCell(SubBaseTable);
            Base5.Colspan = 2;
            BaseTable.AddCell(Base5);
            
            return BaseTable;
        }
    }
}
