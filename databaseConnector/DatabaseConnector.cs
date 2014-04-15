//CS350 Spring 2014
//CS Connect Group 3
//This program is for opening, reading data, and writing to an Access Database


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

    public class CommonFunctions
    {
        //Open a connection
        public static OleDbConnection connectToDB()
        {

            OleDbConnection connection = new OleDbConnection();



            connection.ConnectionString =

            "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\\Users\\briggs_mc\\cs350\\cs-connect\\databaseConnector\\csconnect.accdb;";
            

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
            string table, string dBfield)
        {


            // Create a command

            OleDbCommand cmd = new OleDbCommand();

            // Use the connection that was passed in

            cmd.Connection = connection;



            // The command will be a text command.

            cmd.CommandType = CommandType.Text;

            //cmd.CommandText = command;

            cmd.CommandText = "SELECT " + dBfield + " " + "FROM " + table;
            //cmd.CommandText = "SELECT " + "StudentName " + "FROM " + "userInfo";
            //cmd.CommandText = "SELECT StudentName FROM userInfo";
            //cmd.CommandText = dBCommand + commandPiece + dBword + table;
            System.Console.WriteLine(cmd.CommandText);

            OleDbDataReader reader = cmd.ExecuteReader();

            string studentNameTest;

            if (reader.HasRows)
            {

                studentNameTest = "Junk1";
                while (reader.Read())
                {

                    studentNameTest = (string)reader[dBfield];
                    //string studentNameTest = (string)reader[commandPiece];
                    //Assert.Greater(studentNameTest.Length, 0);

                }
                
                

            }
            else studentNameTest= "Junk2";
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


