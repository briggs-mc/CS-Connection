using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using NUnit.Framework;
using System.Threading;

public class server
{
    static TcpListener tcpListener = new TcpListener(8001);

    /// <summary>
    /// Calling recieve over and over for each client until they exit.
    /// </summary>
    public static void Listeners()
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

           

            //here we recieve client's text if any.
            while (true)
            {
                string theString = testReceive(socketForClient);
                
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
    /// <summary>
    /// Setting up threads for mutuple clients.
    /// </summary>
    public static void Main()
    {

    

        tcpListener.Start();
        Console.WriteLine("Type how many clients you are allowing to connect");
        int numberOfClientsYouNeedToConnect = int.Parse(Console.ReadLine());
        Console.WriteLine("You have allowed: " + numberOfClientsYouNeedToConnect + " to connect");
        for (int i = 0; i < numberOfClientsYouNeedToConnect; i++)
        {
            Thread newThread = new Thread(new ThreadStart(Listeners));
            newThread.Start();
        }
       
    
    }

    /// <summary>
    /// The client receive function. Gets a message from a client.
    /// </summary>
    /// <param name="client_socket"></param>
    public static void receiveMessageFromClients(Socket client_socket)
    {
        byte[] Rec_bytes = new byte[100];
        int messageLength = client_socket.Receive(Rec_bytes);
        Console.WriteLine("Received...");
        for (int i = 0; i < messageLength; i++)
            Console.Write(Convert.ToChar(Rec_bytes[i]));

    }
    /// <summary>
    /// Sends a message to the client that a user types in.
    /// </summary>
    /// <param name="clientSocket"></param>
    public static void sendMessage(Socket clientSocket)
    {
        ASCIIEncoding asn = new ASCIIEncoding();
        String sendString = Console.ReadLine();
        
        clientSocket.Send(asn.GetBytes(sendString));
    }

    /// <summary>
    /// Sends the client the exact message back that he sent to the server.
    /// </summary>
    /// <param name="clientSocket"></param>
    /// <returns></returns>
    public static int echoMessage(Socket clientSocket)
    {
        string messageToSend = testReceive(clientSocket);
        ASCIIEncoding asn = new ASCIIEncoding();
        clientSocket.Send(asn.GetBytes(messageToSend));
        return messageToSend.Length;

    }

   

    /// <summary>
    /// A receive function that returns a string.
    /// </summary>
    /// <param name="client_socket"></param>
    /// <returns></returns>
    public static string testReceive(Socket client_socket)
    {
        
        byte[] Rec_bytes = new byte[100];
        int messageLength = client_socket.Receive(Rec_bytes);
        Console.WriteLine("Received...");
        char [] messageRecv = new char[messageLength];
        for (int i = 0; i < messageLength; i++)
        {
            
            messageRecv[i] = Convert.ToChar(Rec_bytes[i]);
        }
        string revcString = new string(messageRecv);
        Console.Write(revcString +"\n\r");
        
        return revcString;
        


    }

    /// <summary>
    /// Accepts connection for a client.
    /// </summary>
    /// <param name="Listener"></param>
    /// <param name="client_socket"></param>
    public static void acceptConnection(out TcpListener Listener, out Socket client_socket)
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

       
    
