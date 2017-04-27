using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExcelReader
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream stream = File.Open(@"c:\users\alex\documents\visual studio 2015\Projects\ExcelReader\ExcelReader\Yahoo Ticker Symbols - Jan 2016.xlsx", FileMode.Open, FileAccess.Read);
            //FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

            //Choose one of either 1 or 2
            //1. Reading from a binary Excel file ('97-2003 format; *.xls)
            //IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

            //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            //Choose one of either 3, 4, or 5
            //3. DataSet - The result of each spreadsheet will be created in the result.Tables
            DataSet result = excelReader.AsDataSet();

            //4. DataSet - Create column names from first row
            //excelReader.IsFirstRowAsColumnNames = true;
            //DataSet result = excelReader.AsDataSet();
            int x = 0;
            //5. Data Reader methods
            while (excelReader.Read())
            {
                if (((IDataRecord)excelReader)[0] == null && x >= 5) break;
                if (x >= 5)
                {
                    //Console.WriteLine(x);
                    Console.WriteLine(((IDataRecord)excelReader)[0].ToString() + "     " + ((IDataRecord)excelReader)[1].ToString() + "     " +((IDataRecord)excelReader)[2].ToString() + "    " +((IDataRecord)excelReader)[3].ToString());
                    //Thread.Sleep(100);
                }
                x++;
            }
            Console.WriteLine("Success!!");
            //6. Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();
            Console.ReadKey();
        }
    }
}
