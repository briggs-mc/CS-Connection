//
/*   Server Program    */

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using NUnit.Framework;

[TestFixture]
public class TestServer
{
    [Test]
    public void AcceptConnection()
    {
        TcpListener myList;
        Socket s;
        server.acceptconnection(out myList, out s);
        Assert.Greater(0, Convert.ToInt32(s));
        Assert.NotNull(myList);

    }

    [Test]
    public void ReceiveMesage()
    {
        TcpListener myList;
        Socket s;
        server.acceptconnection(out myList, out s);
        server.Receive(s);

    }

    [Test]
    public void SendMessage()
    {
 
    }
}

public class server
{
    public static void Main()
    {

        try
        {

            TcpListener myList;
            Socket s;
            acceptconnection(out myList, out s);

            Receive(s);





            ASCIIEncoding asen = new ASCIIEncoding();
            s.Send(asen.GetBytes("The string was recieved by the server."));
            Console.WriteLine("\nSent Acknowledgement");
            /* clean up */
            s.Close();
            myList.Stop();

        }
        catch (Exception e)
        {
            Console.WriteLine("Error..... " + e.StackTrace);
        }
    }

    public static void Receive(Socket s)
    {
        byte[] b = new byte[100];
        int k = s.Receive(b);
        Console.WriteLine("Recieved...");
        for (int i = 0; i < k; i++)
            Console.Write(Convert.ToChar(b[i]));
    }

    public static void acceptconnection(out TcpListener myList, out Socket s)
    {
        IPAddress ipAd = IPAddress.Parse("161.115.86.57");
        //use local m/c IP address, and 
        //use the same in the client

        /* Initializes the Listener */
        myList = new TcpListener(ipAd, 8001);

        /* Start Listeneting at the specified port */
        myList.Start();


        Console.WriteLine("The server is running at port 8001...");
        Console.WriteLine("The local End point is  :" +
                          myList.LocalEndpoint);
        Console.WriteLine("Waiting for a connection.....");


        s = myList.AcceptSocket();
        Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);
    }
}

       
    
