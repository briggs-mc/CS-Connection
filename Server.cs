using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using NUnit.Framework;


public class server
{
    public static void Main()
    {

        try
        {

            TcpListener Listener;
            Socket client_socket;
            acceptconnection(out Listener, out client_socket);

            Receive(client_socket);
            //int gh = testReceive(client_socket);
            

            ASCIIEncoding asen = new ASCIIEncoding();
            client_socket.Send(asen.GetBytes("The string was recieved by the server."));
            Console.WriteLine("\nSent Acknowledgement");
           
            client_socket.Close();
            Listener.Stop();

        }
        catch (Exception error)
        {
            Console.WriteLine("Error..... " + error.StackTrace);
        }
    }

    public static void Receive(Socket client_socket)
    {
        byte[] Rec_bytes = new byte[100];
        int k = client_socket.Receive(Rec_bytes);
        Console.WriteLine("Received...");
        for (int i = 0; i < k; i++)
            Console.Write(Convert.ToChar(Rec_bytes[i]));
    }

    public static int testReceive(Socket client_socket)
    {
        byte[] Rec_bytes = new byte[100];
        int messageLength = client_socket.Receive(Rec_bytes);
        Console.WriteLine("Received...");
        for (int i = 0; i < messageLength; i++)
            Console.Write(Convert.ToChar(Rec_bytes[i]));
        return messageLength;
        
    }

    public static void acceptconnection(out TcpListener Listener, out Socket client_socket)
    {
         IPAddress ipAdd = IPAddress.Any;
       // IPAddress ipAdd = IPAddress.Any;
        //use IP addressof the machine

        //Start listening
        Listener = new TcpListener(ipAdd, 8001);
        //Wait for connection

        Listener.Start();
        Console.WriteLine("The server is running at port 8001...");
        Console.WriteLine("The local End point is  :" +
                              Listener.LocalEndpoint);
        Console.WriteLine("Waiting for a connection.....");

        client_socket = Listener.AcceptSocket();
        Console.WriteLine("Connection accepted from " + client_socket.RemoteEndPoint);
    }
}

       
    
