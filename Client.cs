using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using NUnit.Framework;










// CS 350 Spring 2014 Software Design
// Team 3 Adam Piersa, Erik Johnson, Marisa Briggs
// reference: http://www.codeproject.com/Articles/1415/Introduction-to-TCP-client-server-in-C
// client software
public class Client
{





    public static void Main(string[] argv)
    {

        const int DOMAIN_NAME_ARG = 0;
        const int PORT_NUMBER_ARG = 1;

        try
        {
            //TcpClient tcpclnt = new TcpClient();
            

            //int portNumber = Convert.ToInt32(argv[PORT_NUMBER_ARG]);

            ////tcpclnt.Connect("161.115.86.57", 8001);
            //IPAddress ipadd = IPAddress.Any;

            //tcpclnt.Connect(argv[DOMAIN_NAME_ARG], portNumber);
            //// use the ipaddress as in the server program

            ////Console.WriteLine("Connected");
            ////Console.Write("Enter the string to be transmitted : ");

            //String sendString = Console.ReadLine();
            //Stream serverSendStream = tcpclnt.GetStream();

            //ASCIIEncoding asen = new ASCIIEncoding();
            //byte[] bytesInSend = asen.GetBytes(sendString);
            ////Console.WriteLine("Transmitting.....");


            //// send length then string to read to length+1
            //serverSendStream.Write(bytesInSend, 0, bytesInSend.Length);

            
            ////

            TcpClient Tcpclnt = new TcpClient();
            Console.WriteLine("Connecting.....");
            int portNumber = Convert.ToInt32(argv[PORT_NUMBER_ARG]);
            connect(Tcpclnt,argv[DOMAIN_NAME_ARG], portNumber);
            sendMessage(Tcpclnt);



            ////


            //byte[] bytesToRead = new byte[100];
            //int numberOfBytesRead = serverSendStream.Read(bytesToRead, 0, bytesToRead.Length);

            //for (int i = 0; i < numberOfBytesRead; i++)
            //    Console.Write(Convert.ToChar(bytesToRead[i]));

            Tcpclnt.Close();
        }

        catch (Exception e)
        {
            Console.WriteLine("Error..... " + e.StackTrace);
        }

    }


    public  static bool connect(TcpClient tcpclnt, string iPAddress, int portNumber)
    {
        IPAddress ipAdd = IPAddress.Any;
 
        //TcpClient tcpclnt = new TcpClient();
        
        tcpclnt.Connect(iPAddress, portNumber);
        
        
        bool connectedStatus = tcpclnt.Connected;
        
        return connectedStatus;
    }


    public static int sendMessage(TcpClient tcpclnt)
    {
        String sendString = Console.ReadLine();
        Stream serverSendStream = tcpclnt.GetStream();

        ASCIIEncoding asen = new ASCIIEncoding();
        byte[] bytesInSend = asen.GetBytes(sendString);
        //Console.WriteLine("Transmitting.....");


        // send length then string to read to length+1
        serverSendStream.Write(bytesInSend, 0, bytesInSend.Length);
        int nBytes = bytesInSend.Length;
        return nBytes;
    }

}
