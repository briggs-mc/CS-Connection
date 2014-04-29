//CS350 Spring 2014
//CS Connect Group 3
//This program is for opening, reading data, and writing to an Access Database
//This contains the basic database functions for any database purpose

using System;
using System.Collections.Generic;
//using System.Collections.Generic.List;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Net;



namespace CSConnector
{
    public class DatabaseConnector
    {

        public class CommonFunctions
        {
            //Open a connection
            public static OleDbConnection connectToDB()
            {

                OleDbConnection connection = new OleDbConnection();

                connection.ConnectionString =

                "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\\Users\\briggs_mc\\Desktop\\Final\\databaseConnector\\csconnect.accdb;";

                connection.Open();

                return connection;

            }


            /// <summary>
            /// read from an open database - using a supplied connection and 
            /// table name and field - good to get one piece of data from a table
            /// </summary>
            /// <param name="connection"></param>
            /// <param name="table"></param>
            /// <param name="dBfield"></param>
            /// <returns></returns>
            public static string readFromDatabase(OleDbConnection connection,
                string table, string dBfield)
            {


                OleDbCommand cmd = buildDatabaseConnectionCommand(connection);

                //piece together command text
                cmd.CommandText = "SELECT " + dBfield + " " + "FROM " + table;

                System.Console.WriteLine(cmd.CommandText);

                OleDbDataReader reader = cmd.ExecuteReader();

                string studentNameTest;

                if (reader.HasRows)
                {

                    studentNameTest = "Junk1";  //this is for test
                    while (reader.Read())
                    {

                        studentNameTest = (string)reader[dBfield];


                    }

                }
                else studentNameTest = "Junk2"; //this is for test
                reader.Close();
                return studentNameTest;

            }

            /// <summary>
            /// this builds the database connection command given a connection
            /// these are used everytime a connection is made
            /// it returns a connection command
            /// </summary>
            /// <param name="connection"></param>
            /// <returns></returns>
            public static OleDbCommand buildDatabaseConnectionCommand(OleDbConnection connection)
            {
                // Create a command

                OleDbCommand cmd = new OleDbCommand();

                // Use the connection that was passed in

                cmd.Connection = connection;

                // The command will be a text command.

                cmd.CommandType = CommandType.Text;
                return cmd;
            }

            /// <summary>
            /// Write to the database 
            /// </summary>
            /// <param name="connection"></param>
            /// <param name="command"></param>
            /// <returns></returns>
            public static int writeToDatabase(OleDbConnection connection, string command)
            {

                //Create the command for the database connection
                OleDbCommand cmd = buildDatabaseConnectionCommand(connection);

                //use the command that was sent in
                cmd.CommandText = command;

                //execute the command
                int nNoAdded = cmd.ExecuteNonQuery();

                return nNoAdded;
            }

            /// <summary>
            /// 
            ///generic read data - given an query - read the database
            ///returns a list of data
            /// </summary>
            /// <param name="connection"></param>
            /// <param name="queryString"></param>
            /// <returns></returns>
            public static List<string> readData(OleDbConnection connection, string queryString)
            {


                //Create the command for the database connection
                OleDbCommand cmd = buildDatabaseConnectionCommand(connection);

                //piece together command
                cmd.CommandText = queryString;

                OleDbDataReader reader = cmd.ExecuteReader();
                int X = reader.RecordsAffected;

                List<string> queryReturn = new List<string>();

                if (reader.HasRows)
                {

                    int i = 0;
                    while (reader.Read())
                    {

                        queryReturn.Insert(i, reader.ToString());
                        ++i;
                    }

                }

                reader.Close();
                return queryReturn;
            }

            /// <summary>
            /// Run a Select Count query to check for info in database
            /// </summary>
            /// <param name="connection"></param>
            /// <param name="queryString"></param>
            /// <returns></returns>
            public static int noRowsContainingInfo(OleDbConnection connection, string queryString)
            {

                //string ddlist = "select count(*) from jud_order where complex_name=@a and case_no=@b and sign=@c and jud_order_date=@d and user_code=@e";
                OleDbCommand cmd = new OleDbCommand(queryString, connection);



                OleDbDataReader reader = cmd.ExecuteReader();
                int X = reader.RecordsAffected;

                String queryReturn;
                int count = 0;
                if (reader.HasRows)
                {
                    queryReturn = reader.ToString();
                    while (reader.Read())
                    {
                        count = (int)reader[0];

                    }

                }

                reader.Close();


                // int count = (int)cmd.ExecuteScalar();

                //which you can then assign to count after type casting the result.

                return count;
            }




        }

    }
}


