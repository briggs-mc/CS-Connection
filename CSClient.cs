using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using NUnit.Framework;

[TestFixture]
public class TestClient
{
    [Test]
    public void connectToServer()
    {

        Client.connect();

    }

    [Test]
    public void sendMessages()
    {
        Client.messageMethod();
        Assert.IsNotNullOrEmpty(message);
    }
}







// CS 350 Spring 2014 Software Design
// Team 3 Adam Piersa, Erik Johnson, Marisa Briggs
// reference: http://www.codeproject.com/Articles/1415/Introduction-to-TCP-client-server-in-C
// client software
public class Client {

  

 

    public static void Main() {






        
        try {
            TcpClient tcpclnt = new TcpClient();
            //Console.WriteLine("Connecting.....");
            
            tcpclnt.Connect("161.115.86.57",8001);
            // use the ipaddress as in the server program
            
            //Console.WriteLine("Connected");
            //Console.Write("Enter the string to be transmitted : ");

            String sendString = Console.ReadLine();
            Stream serverSendStream = tcpclnt.GetStream();

            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] bytesInSend = asen.GetBytes(sendString);
            //Console.WriteLine("Transmitting.....");


            // send length then string to read to length+1
            serverSendStream.Write(bytesInSend, 0, bytesInSend.Length);




            byte[] bytesToRead = new byte[100];
            int numberOfBytesRead = serverSendStream.Read(bytesToRead, 0, bytesToRead.Length);

            for (int i = 0; i < numberOfBytesRead; i++)
                Console.Write(Convert.ToChar(bytesToRead[i]));
            
            tcpclnt.Close();
        }
        
        catch (Exception e) {
            Console.WriteLine("Error..... " + e.StackTrace);
        }
    }


   public static void connect()
    {
        TcpClient tcpclnt = new TcpClient();
        //Console.WriteLine("Connecting.....");

        tcpclnt.Connect("161.115.86.57", 8001);
    }




   public static string sendMessageToAServer(int ipAddress, int portNumber)
   {
       TcpClient tcpclnt = new TcpClient();
       //Console.WriteLine("Connecting.....");

       tcpclnt.Connect("161.115.86.57", 8001);

       String str = Console.ReadLine();
       Stream stm = tcpclnt.GetStream();

       ASCIIEncoding asen = new ASCIIEncoding();
       byte[] ba = asen.GetBytes(str);
       //Console.WriteLine("Transmitting.....");

       stm.Write(ba, 0, ba.Length);

       byte[] bb = new byte[100];
       int k = stm.Read(bb, 0, 100);

       for (int i = 0; i < k; i++)
           Console.Write(Convert.ToChar(bb[i]));
   }


}
