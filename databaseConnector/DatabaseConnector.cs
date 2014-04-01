using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Net;



//namespace databaseConnector
public class databaseConnector
{
    
    public static void Main()
    {

    }

        public class CommonFunctions
        {

            public static OleDbConnection connectToDB()
            {

                OleDbConnection connection = new OleDbConnection();



                connection.ConnectionString =

               "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\\Users\\briggs_mc\\cs350\\CS-connect\\databaseConnector\\csconnect.accdb;";
            

                connection.Open();

            
                return connection;

            }
        }
    
}
        //public static List<Username> getUsers(string presentationId, OleDbConnection connection)
        //{

        //    List<Username> authors = new List<Username>();



        //    // Create a command

        //    OleDbCommand cmd = new OleDbCommand();



        //    // Use the connection that was passed in

        //    cmd.Connection = connection;



        //    // The command will be a text command.

        //    cmd.CommandType = CommandType.Text;



        //    // get the department Name

        //    string command = "Select * from userInfo, Student where presentationStudent.presentationId = $pid " +

        //        "and Student.studentId=presentationStudent.studentId order by authorOrder";



        //    command = command.Replace("$pid", presentationId);

        //    cmd.CommandText = command;

        //    OleDbDataReader reader = cmd.ExecuteReader();

        //    if (reader.HasRows)
        //    {

        //        while (reader.Read())
        //        {

        //            Author nextAuthor = new Author();

        //            nextAuthor.First = (string)reader["firstName"];

        //            nextAuthor.Middle = (string)reader["MiddleName"];

        //            nextAuthor.Last = (string)reader["lastName"];

        //            nextAuthor.Email = (string)reader["emailAddress"];

        //            authors.Add(nextAuthor);

        //        }

        //    }

        //    reader.Close();



        //    return authors;

        //}
  
