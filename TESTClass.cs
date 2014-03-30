using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using NUnit.Framework;



namespace testServer
{
    
    class TestServer
    {


        [TestFixture]
        public class Test_Server
        {
            [Test]
            public void AcceptConnection()
            {
                //server theServer = new server();
                TcpListener Test_Listener;
                Socket test_socket;
                server.acceptconnection(out Test_Listener, out test_socket);
                Assert.NotNull(Test_Listener);

            }

            [Test]
            public void ReceiveMesage()
            {
                TcpListener Test_listener;
                Socket test_socket;
                server.acceptconnection(out Test_listener, out test_socket);
                Assert.NotNull(Test_listener);
                int testMessage = server.testReceive(test_socket);
                Assert.Greater(testMessage, 0);
            }

            
        }
    }
}
