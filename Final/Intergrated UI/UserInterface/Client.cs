using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using UserInterface;
using System.Threading;
//using NUnit.Framework;

// CS 350 Spring 2014 Software Design
// Team 3 Adam Piersa, Erik Johnson, Marisa Briggs
// reference: http://www.codeproject.com/Articles/1415/Introduction-to-TCP-client-server-in-C
// client software
public class Client
    // Comments for this class are on New Client file.
{
    public static TcpClient serverTCP;
    public static void startInit(TcpClient tcpClient)
    {
        userForm ui = new userForm();
        serverTCP = tcpClient;
        try
        {
            Stream serverSendStream = tcpClient.GetStream();
        }
        // catch error on connecting to a server
        catch (Exception e)
        {
            Console.WriteLine("Error..... " + e.StackTrace);
        }

    }



    public static bool connectStatus(TcpClient tcpclnt, string iPAddress, int portNumber)
    {
        IPAddress ipAdd = IPAddress.Any;
        tcpclnt.Connect(iPAddress, portNumber);
        bool connectedStatus = tcpclnt.Connected;
        return connectedStatus;
    }
    public static TcpClient connect(TcpClient tcpclnt, string iPAddress, int portNumber)
    {
        IPAddress ipAdd = IPAddress.Any;
        tcpclnt.Connect(iPAddress, portNumber);
        bool connectedStatus = tcpclnt.Connected;
        return tcpclnt;
    }

    //*****
    public static string sendMessage(TcpClient tcpclnt)
    {
        Stream serverSendStream = tcpclnt.GetStream();
        String sendString = "Hellllllllloooooooooooooooooooooooooooooooooooooooooooooooo";
        ASCIIEncoding asen = new ASCIIEncoding();
        byte[] bytesInSend = asen.GetBytes(sendString);
        serverSendStream.Write(bytesInSend, 0, bytesInSend.Length);
        serverSendStream.Flush();
        int nBytes = bytesInSend.Length;
        return sendString;

    }
    //******

    public static void sendMessageUI(TcpClient tcpclnt, string message)
    {
        String sendString = message;
        Stream serverSendStream = tcpclnt.GetStream();
        ASCIIEncoding asen = new ASCIIEncoding();
        byte[] bytesInSend = asen.GetBytes(sendString);
        serverSendStream.Write(bytesInSend, 0, bytesInSend.Length);
        serverSendStream.Flush();
        int nBytes = bytesInSend.Length;
    }



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
