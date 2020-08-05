using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFileUpload01
{
    class Program
    {
        static void Main(string[] args)
        {
            //making changes on 5Aug2020
            //21Jan2020 p4

            // string sqlconn = System.Configuration.ConfigurationManager.ConnectionStrings["SqlCom"].ConnectionString;
            // SqlConnection con = new SqlConnection(sqlconn);

           
            //getting full file path of Uploaded file  
            //string CSVFilePath = Path.GetFullPath(FileUpload1.PostedFile.FileName);
            //string CSVFilePath = @"C:\Users\Ryan\Documents\Visual Studio 2010\Projects\Bulk Copy from CSV to SQL Server Table\WindowsFormsApplication1\bin"; // CSV file Path
            string CSVFilePath = @"C:\Uploads\test01.csv"; // CSV file Path

            //Creating object of datatable  
            DataTable tblcsv = new DataTable();
            //creating columns  
            tblcsv.Columns.AddRange(new DataColumn[3]
            {
                new DataColumn("accountnumber", typeof(string)),
                new DataColumn("mis", typeof(string)),
                new DataColumn("AccountOfficer_Code", typeof(string)),
            }
                );

            //Reading All text i.e read the contents of the csv file 
            string ReadCSV = File.ReadAllText(CSVFilePath);
            //spliting row after new line  
            foreach (string csvRow in ReadCSV.Split('\r'))
            {
                if (!string.IsNullOrEmpty(csvRow))
                {
                    //Adding each row into datatable  
                    tblcsv.Rows.Add();
                    int count = 0;
                    foreach (string FileRec in csvRow.Split(','))
                    {
                        tblcsv.Rows[tblcsv.Rows.Count - 1][count] = FileRec;
                        count++;
                    }
                }
            }
            // //Calling insert Functions  
            // InsertCSVRecords(tblcsv);
        }

        //static void Main(string[] args)
        //{
        //   // string sqlconn = System.Configuration.ConfigurationManager.ConnectionStrings["SqlCom"].ConnectionString;
        //   // SqlConnection con = new SqlConnection(sqlconn);

        //    //Creating object of datatable  
        //    DataTable tblcsv = new DataTable();
        //    //creating columns  
        //    tblcsv.Columns.Add("accountnumber");
        //    tblcsv.Columns.Add("mis");
        //    tblcsv.Columns.Add("AccountOfficer_Code");
        //    //getting full file path of Uploaded file  
        //    //string CSVFilePath = Path.GetFullPath(FileUpload1.PostedFile.FileName);
        //    //string CSVFilePath = @"C:\Users\Ryan\Documents\Visual Studio 2010\Projects\Bulk Copy from CSV to SQL Server Table\WindowsFormsApplication1\bin"; // CSV file Path
        //    string CSVFilePath = @"C:\Uploads\test01.csv"; // CSV file Path

        //    //Reading All text  
        //    string ReadCSV = File.ReadAllText(CSVFilePath);
        //    //spliting row after new line  
        //    foreach (string csvRow in ReadCSV.Split('\n'))
        //    {
        //        if (!string.IsNullOrEmpty(csvRow))
        //        {
        //            //Adding each row into datatable  
        //            tblcsv.Rows.Add();
        //            int count = 0;
        //            foreach (string FileRec in csvRow.Split(','))
        //            {
        //                tblcsv.Rows[tblcsv.Rows.Count - 1][count] = FileRec;
        //                count++;
        //            }
        //        }


        //    }
        //   // //Calling insert Functions  
        //   // InsertCSVRecords(tblcsv);
        //}
    }
}
