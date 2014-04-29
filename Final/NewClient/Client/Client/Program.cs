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
    // The IP and Port are coming from the command line
    public static void Main(string[] argv)
    {

        const int DOMAIN_NAME_ARG = 0;
        const int PORT_NUMBER_ARG = 1;

        try
        {
            TcpClient Tcpclnt = new TcpClient();
            Console.WriteLine("Connecting.....");
            int portNumber = Convert.ToInt32(argv[PORT_NUMBER_ARG]);
            // connecting to the server
            connect(Tcpclnt, argv[DOMAIN_NAME_ARG], portNumber);

            String sendString;
            Stream serverSendStream = Tcpclnt.GetStream();

            ASCIIEncoding asen = new ASCIIEncoding();

            while (true)
            {
                // sending a message over and over evey time enter is pressed
                sendString = sendMessage(Tcpclnt);

                const string EXIT_STRING = "exit";

                if (sendString.ToLower() == EXIT_STRING)
                    break;
            }
            // closing the client
            Tcpclnt.Close();
        }

        catch (Exception e)
        {
            Console.WriteLine("Error..... " + e.StackTrace);
        }

    }

    /// <summary>
    /// Connecting to a server at a specific Ip and port
    /// </summary>
    /// <param name="tcpclnt"></param>
    /// <param name="iPAddress"></param>
    /// <param name="portNumber"></param>
    /// <returns></returns>
    public static bool connect(TcpClient tcpclnt, string iPAddress, int portNumber)
    {
        IPAddress ipAdd = IPAddress.Any;



        tcpclnt.Connect(iPAddress, portNumber);


        bool connectedStatus = tcpclnt.Connected;

        return connectedStatus;
    }

    /// <summary>
    /// Sending a message back to the server.
    /// </summary>
    /// <param name="tcpclnt"></param>
    /// <returns></returns>
    public static string sendMessage(TcpClient tcpclnt)
    {
        String sendString = Console.ReadLine();
        Stream serverSendStream = tcpclnt.GetStream();

        ASCIIEncoding asen = new ASCIIEncoding();
        byte[] bytesInSend = asen.GetBytes(sendString);

        serverSendStream.Write(bytesInSend, 0, bytesInSend.Length);
        serverSendStream.Flush();
        int nBytes = bytesInSend.Length;
        return sendString;

    }

    /// <summary>
    /// A function that is used for tests because it returns an int. More than likely it is not
    /// longer needed but we kept it to show the work we did.
    /// </summary>
    /// <param name="tcpclnt"></param>
    /// <returns></returns>
    public static int testSendMessage(TcpClient tcpclnt)
    {

        Stream serverSendStream = tcpclnt.GetStream();
        String sendString = "Testing client receive message from server";
        ASCIIEncoding asen = new ASCIIEncoding();
        byte[] bytesInSend = asen.GetBytes(sendString);

        // send length then string to read to length
        serverSendStream.Write(bytesInSend, 0, bytesInSend.Length);
        int nBytes = bytesInSend.Length;
        return nBytes;
    }
    /// <summary>
    /// Receiving a message from a server. An instance of this is not called but it works in the tests
    /// </summary>
    /// <param name="tcpclnt"></param>
    /// <returns></returns>
    public static int receiveMessage(TcpClient tcpclnt)
    {
        const int MAX_CHARS = 1500;
        Stream serverStream = tcpclnt.GetStream();

        Byte[] buffer = new Byte[MAX_CHARS];

        Int32 bytes = serverStream.Read(buffer, 0, buffer.Length);
        String responceMessage = System.Text.Encoding.ASCII.GetString(buffer, 0, bytes);
        Console.WriteLine("Received: ", responceMessage);
        Console.Write(responceMessage);
        return bytes;
    }

}
