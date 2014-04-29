using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using NUnit.Framework;
using System.Threading;




namespace testServer
{
    class TestServer
    {


        [TestFixture]
        public class Test_Server
        {
            /// <summary>
            /// Tests the connect to a client and returns if the listener is null or not.
            /// </summary>
            [Test]
            public void AcceptConnection()
            {
                
                TcpListener Test_Listener;
                Socket test_socket;
                server.acceptConnection(out Test_Listener, out test_socket);
                Assert.NotNull(Test_Listener);

            }

            /// <summary>
            /// Receives a message from a client and tests if the length of it is greater than 0.
            /// </summary>
            [Test]
            public void ReceiveMesage()
            {
                TcpListener Test_listener;
                Socket test_socket;
                server.acceptConnection(out Test_listener, out test_socket);
                Assert.NotNull(Test_listener);
                string testMessage = server.testReceive(test_socket);
                Assert.Greater(testMessage.Length, 0);
            }

            /// <summary>
            /// Sends a message to the Client.
            /// </summary>
            [Test]
            public void SendMessage()
            {
                TcpListener Test_Listener;
                Socket test_socket;
                server.acceptConnection(out Test_Listener, out test_socket);
                Assert.NotNull(Test_Listener);
                int lengthOfMessage = server.echoMessage(test_socket);
                Assert.Greater(lengthOfMessage, 0);
            }

            /// <summary>
            /// Tests to see if the threads are alive and available to handle mutiple clients.
            /// </summary>
            [Test]
            public void handleMutipleClientTest()
            {
                //Threading Test
                //TcpListener tcpListener = new TcpListener(8001);
                //tcpListener.Start();

                int numberOfClientsYouNeedToConnect = 2;
                //Console.WriteLine("You have allowed: " + numberOfClientsYouNeedToConnect + " to connect");
                for (int i = 0; i < numberOfClientsYouNeedToConnect; i++)
                {
                    Thread newThread = new Thread(new ThreadStart(server.Listeners));
                    newThread.Start();
                    Assert.IsTrue(newThread.IsAlive, "Failed Test Handle Mutiple Client");
                }

            }

        }
    }
}
