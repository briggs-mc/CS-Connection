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
public class DatabaseConnector
{

    public static void Main()
    {

    }

    public class CommonFunctions
    {
        //Open a connection
        public static OleDbConnection connectToDB()
        {

            OleDbConnection connection = new OleDbConnection();



            connection.ConnectionString =

            "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\\Users\\briggs_mc\\cs350\\CS-connect\\databaseConnector\\csconnect.accdb;";
            

            connection.Open();

            
            return connection;

        }

        //read from an open database - using a supplied connection and 
        //a provided string command and also for now need the piece of the command that is 
        //the field I want to look at
        //but must be able to read more than line and more than one field
        //I am not sure how to do this at this time - need to return an array of stirngs?
        //how do I make this generic?
        public static string readFromDatabase(OleDbConnection connection,
            string command, string commandPiece)
        {


            // Create a command

            OleDbCommand cmd = new OleDbCommand();

            // Use the connection that was passed in

            cmd.Connection = connection;



            // The command will be a text command.

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = command;


            OleDbDataReader reader = cmd.ExecuteReader();

            string studentNameTest;

            if (reader.HasRows)
            {

                while (reader.Read())
                {

                    studentNameTest= (string)reader[commandPiece];
                    //string studentNameTest = (string)reader[commandPiece];
                    //Assert.Greater(studentNameTest.Length, 0);

                }
                
                studentNameTest= null;

            }
            else studentNameTest= null;
            reader.Close();
            return studentNameTest;

        }

        public static int writeToDatabase(OleDbConnection connection, string command)
        {

            // Create a command

            OleDbCommand cmd = new OleDbCommand();

            // Use the connection that was passed in

            cmd.Connection = connection;



            // The command will be a text command.

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = command;
           

            int nNoAdded = cmd.ExecuteNonQuery();

            return nNoAdded;
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
  
