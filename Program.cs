using System;
using System.Data.SqlClient;
using System.Data;

namespace ConsAppAssignment7
{
    internal class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataAdapter sda;
        public static DataSet ds;
        public static string cons = "server=NAVEEN-BOOK-8C9;database=LibraryDb;trusted_connection=true";
        public static string Query ;
        static void Main(string[] args)
        {
            string choice;
            do
            {
                try
                {
                    con = new SqlConnection(cons);
                    cmd = new SqlCommand
                    {
                        Connection = con
                    };

                    Console.WriteLine("Enter Operation you want to perform \n1.Display Book Data\n2.Add New Book\n3.Update Book Data");
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Query = "select * from Books";
                            cmd.CommandText = Query;
                            sda = new SqlDataAdapter(cmd);
                            ds = new DataSet();
                            con.Open();
                            sda.Fill(ds);
                            con.Close();
                            Console.WriteLine("Book ID\t\tBook Name\t Book Author\tBook Genre\tQantity");
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                Console.Write(row[0] + "\t\t");
                                Console.Write(row[1] + "\t\t");
                                Console.Write(row[2] + "\t\t");
                                Console.Write(row[3] + "\t\t");
                                Console.Write(row[4] + "\t");
                                Console.WriteLine("\n");
                            }
                            break;
                        case 2:
                            Query = "select * from Books";
                            cmd.CommandText = Query;
                            sda = new SqlDataAdapter(cmd);
                            ds = new DataSet();
                            con.Open();
                            sda.Fill(ds, "Books");
                            DataTable dt = ds.Tables["Books"];
                            DataRow dr = dt.NewRow();
                            Console.WriteLine("Enter Book Id");
                            dr["BookId"] = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Book Name");
                            dr["Tittle"] = Console.ReadLine();
                            Console.WriteLine("Enter Book Author");
                            dr["Author"] = Console.ReadLine();
                            Console.WriteLine("Enter Book Genres");
                            dr["Genre"] = Console.ReadLine();
                            Console.WriteLine("Enter Book Quantity");
                            dr["Quqntity"] = int.Parse(Console.ReadLine());
                            dt.Rows.Add(dr);
                            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                            sda.Update(ds, "Books");
                            Console.WriteLine("Books Record Inserted !!!");
                            con.Close();
                            break;
                        case 3:
                            Query = "select * from Books";
                            cmd.CommandText = Query;
                            sda = new SqlDataAdapter(cmd);
                            ds = new DataSet();
                            con.Open();
                            sda.Fill(ds, "Books");
                            Console.WriteLine("Enter Book Id to update Book Record");
                            int id = int.Parse(Console.ReadLine());
                            DataRow drow = null;

                            foreach (DataRow row in ds.Tables["Books"].Rows)
                            {
                                if ((int)row["BookId"] == id)
                                {
                                    drow = row;
                                    break;
                                }
                            }
                            if (drow == null)
                            {
                                Console.WriteLine($"No such Book {id} exsist in the Books Table");
                            }
                            else
                            {
                                Console.WriteLine("Enter Book Name");
                                drow["Tittle"] = Console.ReadLine();
                                Console.WriteLine("Enter Author");
                                drow["Author"] = Console.ReadLine();
                                Console.WriteLine("Enter Book Genre");
                                drow["Genre"] = Console.ReadLine();
                                Console.WriteLine("Enter Book Quantity");
                                drow["Quqntity"] = int.Parse(Console.ReadLine());
                                SqlCommandBuilder builders = new SqlCommandBuilder(sda);
                                sda.Update(ds, "Books");
                                Console.WriteLine("Books Record Updated !!!");
                            }
                            break;
                        default:
                            Console.WriteLine("Inavlid Operation !!!");
                            break;
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error !!!" + ex.Message);
                }
                finally
                {
                    Console.WriteLine("End of the Process"); 
                }
                Console.WriteLine("Do you want to perform Above Operations again ? (yes/no)");
                choice = Console.ReadLine();
            } while (choice == "yes");
            Console.ReadKey();

        }
    }
}
