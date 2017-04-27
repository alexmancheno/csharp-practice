using Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PopulateTickerTable
{
    class Program
    {
        private SqlDataAdapter da;

        static void Main(string[] args)
        {
            using (FileStream stream = File.Open(@"c:\users\alex\documents\visual studio 2015\Projects\ExcelReader\ExcelReader\Yahoo Ticker Symbols - Jan 2016.xlsx", FileMode.Open, FileAccess.Read))

            {
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                
                char[] separatingChar = { '\t' };

                for (int i = 0;  i < 27724; i++)
                {
                    excelReader.Read();
                    if (i >= 4)
                    {
                        string queryString = String.Empty;
                        string ticker = String.Empty;
                        string name = String.Empty;
                        string exchange = String.Empty;
                        string country = String.Empty;
                        string cat = String.Empty;
                        string num = String.Empty;

                        IDataRecord data = (IDataRecord)excelReader;

                        if (data[0] != null) ticker = data[0].ToString();
                        if (data[1] != null) name = data[1].ToString();
                        if (data[2] != null) exchange = data[2].ToString();
                        if (data[3] != null) country = data[3].ToString();
                        if (data[4] != null) cat = data[4].ToString();
                        if (data[5] != null) num = data[5].ToString();

                        queryString = "INSERT INTO Stock_List1 (Ticker, Comp_Name, Exchange, Country, Category_Name, Category_Number,Initialized, Error) values (@ticker, @name, @ex, @country, @cat_name, @cat_num, 0, 0);";
                        //Console.WriteLine(queryString);

                        using (SqlConnection connection = new SqlConnection(@"Data Source=ALEX-PC;Initial Catalog=Numeraxial; Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                        {
                            using (SqlCommand cmd = new SqlCommand(queryString, connection))
                            {

                                cmd.Parameters.Add("@ticker", SqlDbType.NVarChar);
                                cmd.Parameters["@ticker"].Value = ticker;

                                cmd.Parameters.Add("@name", SqlDbType.NVarChar);
                                cmd.Parameters["@name"].Value = name;

                                cmd.Parameters.Add("@ex", SqlDbType.NVarChar);
                                cmd.Parameters["@ex"].Value = exchange;

                                cmd.Parameters.Add("@country", SqlDbType.NVarChar);
                                cmd.Parameters["@country"].Value = country;

                                cmd.Parameters.Add("@cat_name", SqlDbType.NVarChar);
                                cmd.Parameters["@cat_name"].Value = cat;

                                cmd.Parameters.Add("@cat_num", SqlDbType.SmallInt);
                                cmd.Parameters["@cat_num"].Value = num;

                                connection.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                Console.WriteLine("Success!");
                Console.ReadLine();
            }
        }
    }
}

       