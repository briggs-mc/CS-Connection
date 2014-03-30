using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using NUnit.Framework;

namespace testClient
{
    class TestClient
    {


        [TestFixture]
        public class Test_Client
        {

            //[SetUp]
            //public void Setup()
            //{

            //}


            [Test]
            public void connectToServer()
            {
                //Client theClient = new Client();
                //bool status = theClient.connect();
                //Assert.IsTrue(status);
                TcpClient tcpClnt = new TcpClient();
                string iP = "127.0.0.1";
                int portNumber = 8001;
             
                bool status = Client.connect(tcpClnt, iP, portNumber);
                Assert.IsTrue(status);


                

            }

            [Test]
            public void sendMessages()
            {
                //Client theClient = new Client();

                TcpClient tcpClnt = new TcpClient();
                string iP = "127.0.0.1";
                int portNumber = 8001;
                Client.connect(tcpClnt, iP, portNumber);

                int nBytes = Client.sendMessage(tcpClnt);


               // Assert.IsNotNull(nBytes);
               // theClient.connect();
                //theClient.sendMessage();

          //      Client.sendMessageToAServer();
           //     Assert.IsNotNullOrEmpty(message);
            }
        }







    }
}
