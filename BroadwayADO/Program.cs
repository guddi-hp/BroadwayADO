using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayADO
{
    class Program
    {
        static string connectionString =
            "Data Source=DESKTOP-7RRSGE5;Initial Catalog=AdoDB;"
            + "Integrated Security=true";
        static void Main(string[] args)
        {
            var result = "y";
            do
            {
                //Console.WriteLine("Enter the Table name");
                //string tablename = Console.ReadLine();
                Console.WriteLine("Enter the choice.\n1. Display record\n2. Create new record\n3. Update record\n4. Delete a record\n");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            ReadFromTable(connection);

                            break;
                        case "2":
                            InsertIntoTable(connection);

                            break;
                        case "3":
                            UpdateTable(connection);

                            break;
                        case "4":
                            DeleteFromTable(connection);

                            break;
                        default:

                            break;


                    }
                    connection.Close();
                }

                Console.WriteLine("Continue (y/n)");
                result = Console.ReadLine();

            } while (result == "y" || result == "Y");

            Console.ReadLine();




        }
        private static void ReadFromTable(SqlConnection connection)
        {

            string queryString = "select * from Student";
            SqlCommand command = new SqlCommand(queryString, connection);

            try
            {
                Console.WriteLine("Id\tName\tEmail\tAge\n");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    var readers = new string[] { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString() };


                    Console.WriteLine(string.Join("\t", readers));
                    //Console.WriteLine("\t{1}\t{2}\t{3}\t", readers);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Console.WriteLine("Total Rent: Rs.");
            Console.ReadLine();

        }
        private static void InsertIntoTable(SqlConnection connection)
        {
            Console.WriteLine("Enter name:");
            var Name = Console.ReadLine();
            Console.WriteLine("Enter Email:");
            var Email = Console.ReadLine();
            Console.WriteLine("Enter Age:");
            var Age = Console.ReadLine();

            string queryString = $"insert into Student (Name,Email,Age) values ('{Name}','{Email}','{Age}')";
            SqlCommand command = new SqlCommand(queryString, connection);

            try
            {
                var res = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Console.WriteLine("Total Rent: Rs.");
            Console.ReadLine();

        }

        private static void UpdateTable(SqlConnection connection)
        {
            Console.WriteLine("Enter the id of the record you want to update");
            var id = Console.ReadLine();
            Console.WriteLine("Enter name:");
            var Name = Console.ReadLine();
            Console.WriteLine("Enter Email:");
            var Email = Console.ReadLine();
            Console.WriteLine("Enter Age:");
            var Age = Console.ReadLine();
            
            string queryString = $"Update  Student set Name=('{Name}'), Email=('{Email}'), Age=('{Age}') where id=('{id}')";
            SqlCommand command = new SqlCommand(queryString, connection);
            try

            {
                var res = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Console.WriteLine("Total Rent: Rs.");
            Console.ReadLine();
        }
        private static void DeleteFromTable(SqlConnection connection)
        {
            //Console.WriteLine("/*Enter the id of the record you want to Delete*/");
            //var id = Console.ReadLine();
            ////Console.WriteLine("Enter name:");
            ////var Name = Console.ReadLine();
            ////Console.WriteLine("Enter Email:");
            ////var Email = Console.ReadLine();
            ////Console.WriteLine("Enter Age:");
            ////var Age = Console.ReadLine();

            //string queryString = $"Delete  Student set Name=('{Name}'), Email=('{Email}'), Age=('{Age}') where id=('{id}')";
            //SqlCommand command = new SqlCommand(queryString, connection);

            //try
            //{
            //    var res = command.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            ////Console.WriteLine("Total Rent: Rs.");
            //Console.ReadLine();
            Console.WriteLine("Enter the id of the record to be deleted");
            var id = Console.ReadLine();
            string queryString = $"delete from Student where id=('{id}')";
            SqlCommand command = new SqlCommand(queryString, connection);

            try
            {
               
                var res = command.ExecuteNonQuery();
                Console.WriteLine(" Successfully data deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
