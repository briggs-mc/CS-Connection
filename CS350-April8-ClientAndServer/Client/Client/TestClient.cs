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
             
                bool connection_status = Client.connect(tcpClnt, iP, portNumber);
                Assert.IsTrue(connection_status);
            }

            [Test]
            public void sendMessages()
            {
                //Client theClient = new Client();

                TcpClient tcpClnt = new TcpClient();
                string iP = "127.0.0.1";
                int portNumber = 8001;
                Client.connect(tcpClnt, iP, portNumber);

                int nBytes = Client.testSendMessage(tcpClnt);


                Assert.IsNotNull(nBytes);
                
            }

            [Test]
            public void receiveMessage()
            {
                TcpClient tcpClnt = new TcpClient();
                string iP = "127.0.0.1";
                int portNumber = 8001;
                Client.connect(tcpClnt, iP, portNumber);
                int nBytes = Client.testSendMessage(tcpClnt);
                int bytesRecv = Client.receiveMessage(tcpClnt);
                Assert.IsNotNull(bytesRecv);
            }

        }







    }
}
