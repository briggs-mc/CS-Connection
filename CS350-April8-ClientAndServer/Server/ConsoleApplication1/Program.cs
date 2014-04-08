using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using NUnit.Framework;
using System.Threading;

public class server
{
    static TcpListener tcpListener = new TcpListener(8001);

    static void Listeners()
    {
        Socket socketForClient = tcpListener.AcceptSocket();
        if (socketForClient.Connected)
        {
            Console.WriteLine("Client:" + socketForClient.RemoteEndPoint + " now connected to server.");
            NetworkStream networkStream = new NetworkStream(socketForClient);
            System.IO.StreamWriter streamWriter =
            new System.IO.StreamWriter(networkStream);
            System.IO.StreamReader streamReader =
            new System.IO.StreamReader(networkStream);

            ////here we send message to client
            //Console.WriteLine("type your message to be recieved by client:");
            //string theString = Console.ReadLine();
            //streamWriter.WriteLine(theString);
            ////Console.WriteLine(theString);
            //streamWriter.Flush();



            //here we recieve client's text if any.
            while (true)
            {
                string theString = testReceive(socketForClient);
                //string theString = streamReader.ReadLine();
                //Console.WriteLine("Message recieved by client:"+ theString);
                if (theString.ToLower() == "exit")
                {
                    break;
                }
            }
            streamReader.Close();
            networkStream.Close();
            streamWriter.Close();


        }
        Console.WriteLine("Client disconnected from IP: " + socketForClient.RemoteEndPoint);
        socketForClient.Close();
        Console.ReadKey();
    }
    public static void Main()
    {

    //    try
    //    {

    //        // keep checking for client information coming in and  receive it
    //        // only send when information is typed and ready to be sent

    //        const string DONE_COMMAND = "7";

    //        TcpListener Listener;
    //        Socket client_socket;

        tcpListener.Start();

        int numberOfClientsYouNeedToConnect = int.Parse(Console.ReadLine());
        Console.WriteLine("You have allowed: " + numberOfClientsYouNeedToConnect + " to connect");
        for (int i = 0; i < numberOfClientsYouNeedToConnect; i++)
        {
            Thread newThread = new Thread(new ThreadStart(Listeners));
            newThread.Start();
        }
       
    
    }

    public static void Receive(Socket client_socket)
    {
        byte[] Rec_bytes = new byte[100];
        int messageLength = client_socket.Receive(Rec_bytes);
        Console.WriteLine("Received...");
        for (int i = 0; i < messageLength; i++)
            Console.Write(Convert.ToChar(Rec_bytes[i]));

    }

    public static void sendMessage(Socket clientSocket)
    {
        ASCIIEncoding asn = new ASCIIEncoding();
        String sendString = Console.ReadLine();
        //String sendString = "This is a test!!!!!!!!!!!!!!!!!!!!!!!!";
        clientSocket.Send(asn.GetBytes(sendString));
    }

    public static int echoMessage(Socket clientSocket)
    {
        string messageToSend = testReceive(clientSocket);
        ASCIIEncoding asn = new ASCIIEncoding();
        clientSocket.Send(asn.GetBytes(messageToSend));
        return messageToSend.Length;

    }

   


    public static string testReceive(Socket client_socket)
    {
        //const int MAX_CHARS = 1500;
        byte[] Rec_bytes = new byte[100];
        int messageLength = client_socket.Receive(Rec_bytes);
        Console.WriteLine("Received...");
        char [] messageRecv = new char[messageLength];
        for (int i = 0; i < messageLength; i++)
        {
            //Console.Write(Convert.ToChar(Rec_bytes[i]));
            messageRecv[i] = Convert.ToChar(Rec_bytes[i]);
        }
        string revcString = new string(messageRecv);
        Console.Write(revcString +"\n\r");
        
        return revcString;
        


    }

    public static void acceptconnection(out TcpListener Listener, out Socket client_socket)
    {
        // Use any IP
         IPAddress ipAdd = IPAddress.Any;
        

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

       
    
