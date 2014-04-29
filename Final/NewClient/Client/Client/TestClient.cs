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
            /// <summary>
            /// Call the server acceptConnection test first.
            /// Connects to a server and checks the status of the client.
            /// </summary>
            [Test]
            public void connectToServer()
            {
                
                TcpClient tcpClnt = new TcpClient();
                string iP = "127.0.0.1";
                int portNumber = 8001;
             
                bool connection_status = Client.connect(tcpClnt, iP, portNumber);
                Assert.IsTrue(connection_status);
            }

            /// <summary>
            /// Run the receive test on the server before this.
            /// Sends a message to the server and makes sure the length of it is not null.
            /// </summary>
            [Test]
            public void sendMessages()
            {

                TcpClient tcpClnt = new TcpClient();
                string iP = "127.0.0.1";
                int portNumber = 8001;
                Client.connect(tcpClnt, iP, portNumber);

                int nBytes = Client.testSendMessage(tcpClnt);


                Assert.IsNotNull(nBytes);
                
            }

            /// <summary>
            /// Run sever sendMessage test first.
            /// Receives a message from the server and makes sure the number of bytes it gets is not null.
            /// </summary>
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
