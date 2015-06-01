using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using HaarbyTennis.Model;




namespace HaarbyTennis.Utilities
{
    
  
    public class OpenXMLConvertor
    {


        public static ExcelPackage GetExcelListFromData(List<Medlem> list)
        {
            
            ExcelPackage p = new ExcelPackage();
            ExcelWorksheet ws;

            string arknavn;          
            int listesidetal = 1;           
            arknavn = "Medlemmer";
            p.Workbook.Worksheets.Add(arknavn);
            ws = p.Workbook.Worksheets[listesidetal];
            ws.Name = arknavn; //Setting Sheet's name
            ws.Cells.Style.Font.Name = "Arial";
            ws.Cells.Style.Font.Size = 12;

            List<string> overskrifter = new List<string> { "Id", "Fornavn", "Efternavn", "Adresse", "Postnr", "By", "Telefon ", "Email" };
            for (int j = 0; j < overskrifter.Count; j++)
            {
                ws.Cells[1, j + 1].Value = overskrifter[j];
                ws.Cells[1, j + 1].Style.Font.Bold = true;
                ws.Cells[1, j + 1].Style.Font.Size = 15;

            }

            foreach (Medlem medlem in list)
            {
                for (int row = 0; row < list.Count; row++)
                {
                    ws.Cells[row + 2, 1].Value = list[row].Id;
                    ws.Cells[row + 2, 2].Value = list[row].Fornavn.ToString();
                    ws.Cells[row + 2, 3].Value = list[row].Efternavn.ToString();
                    ws.Cells[row + 2, 4].Value = list[row].Adresse.ToString();
                    ws.Cells[row + 2, 5].Value = list[row].Postnummer;
                    ws.Cells[row + 2, 6].Value = list[row].Bynavn.ToString();
                    ws.Cells[row + 2, 7].Value = list[row].Tlf_1;
                    ws.Cells[row + 2, 8].Value = list[row].Email.ToString();
                }
            }

            return p;
         }
        public static ExcelPackage GetExcelList(HtmlTable list)
        {
            ExcelPackage p = new ExcelPackage();
            ExcelWorksheet ws;

            string arknavn;
            int start = 1;// HVORFOR HAVE START - der er altid headere
            int listesidetal = 1;

            start = 1;
            arknavn = "Liste";
            p.Workbook.Worksheets.Add(arknavn);
            ws = p.Workbook.Worksheets[listesidetal];
            ws.Name = arknavn; //Setting Sheet's name
            ws.Cells.Style.Font.Name = "Arial";
            ws.Cells.Style.Font.Size = 12;



            if (list.Rows[0].Cells.Count != 0)
            {
                start++;
                for (int j = 0; j < list.Rows[0].Cells.Count; j++)
                {
                    ws.Cells[1, j + 1].Value = ((HtmlHead)list.Rows[0].Cells[j].Controls[0]).Title;
                    ws.Cells[1, j + 1].Style.Font.Bold = true;
                }
            }

            for (int i = 0; i < list.Rows.Count - 1; i++)
            {
                for (int j = 0; j < list.Rows[i + 1].Cells.Count; j++)
                {
                    if (list.Rows[i + 1].Cells[j].Controls[0] is Label)
                    {
                        ws.Cells[i + start, j + 1].Value = ((Label)list.Rows[i + 1].Cells[j].Controls[0]).Text;
                    }
                    if (list.Rows[i + 1].Cells[j].Controls[0] is HyperLink)
                    {
                        ws.Cells[i + start, j + 1].Value = ((HyperLink)list.Rows[i + 1].Cells[j].Controls[0]).Text;
                    }
                }
            }

            for (int i = 1; i < list.Rows[1].Cells.Count + 1; i++)
                ws.Column(i).AutoFit();

            return p;

        }


        //Udkommenteret - input er Griddata fra Telrik.
        //public static ExcelPackage GetExcelListFromGrid(GridDataItemCollection griditems)
        //{
        //    ExcelPackage p = new ExcelPackage();
        //    ExcelWorksheet ws;

        //    string arknavn;
        //    int start = 1;// HVORFOR HAVE START - der er altid headere
        //    int listesidetal = 1;

        //    start = 1;
        //    arknavn = "Liste";
        //    p.Workbook.Worksheets.Add(arknavn);
        //    ws = p.Workbook.Worksheets[listesidetal];
        //    ws.Name = arknavn; //Setting Sheet's name


        //    if (griditems[0].Cells.Count != 0)
        //    {
        //        start++;
        //        for (int j = 0; j < griditems[0].Cells.Count; j++)
        //        {
        //            ws.Cells[1, j + 1].Value = griditems[0].Cells[j].Text;
        //            ws.Cells[1, j + 1].Style.Font.Bold = true;
        //        }
        //    }

        //    for (int i = 0; i < griditems.Count - 1; i++)
        //    {
        //        for (int j = 0; j < griditems[i + 1].Cells.Count; j++)
        //        {
        //            ws.Cells[i + start, j + 1].Value = griditems[i + 1].Cells[j].Text;
        //        }
        //    }

        //    for (int i = 1; i < griditems[1].Cells.Count + 1; i++)
        //        ws.Column(i).AutoFit();

        //    return p;
        //}
    }

}