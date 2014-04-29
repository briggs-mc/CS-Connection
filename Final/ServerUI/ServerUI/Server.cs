using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using ServerUI;

public class Server
{
    public static TcpListener serverListenerForClient = new TcpListener(IPAddress.Any, 8001);

    /// <summary>
    /// Create an accept thread to handle clients connecting to server
    /// </summary>
    /// <param name="ServerUI"></param>
    public static void Listeners(serverForm ServerUI)
    {
        while (true)
        {
            Socket clientSocket = serverListenerForClient.AcceptSocket();
            if (clientSocket.Connected)
            {
                ListenerParams listener = new ListenerParams();
                listener.clientTcp = serverListenerForClient;
                listener.serverUI = ServerUI;
                listener.clientSocket = clientSocket;
                Thread clientThread = new Thread(new ParameterizedThreadStart(Start));
                clientThread.Start(listener);
            }
        }

    }

    public static string receiveMessageFromClient(Socket client_socket)
    {
        byte[] Rec_bytes = new byte[255];
        int messageLength = client_socket.Receive(Rec_bytes);
        char[] messageRecv = new char[messageLength];
        for (int i = 0; i < messageLength; i++)
        {
            messageRecv[i] = Convert.ToChar(Rec_bytes[i]);
        }
        string revcString = new string(messageRecv);

        return revcString;
    }

    /// <summary>
    /// Parameters for the Parameterized thread start. Handles messages received and sent to client
    /// </summary>
    /// <param name="parameters"></param>
    static void Start(object parameters)
    {
        ListenerParams listernerParams = (ListenerParams)parameters;

        try
        {
            while (true)
            {
                string clientMessage = receiveMessageFromClient(listernerParams.clientSocket);
                if (clientMessage.ToLower() == "exit")
                {
                    break;
                }
                listernerParams.serverUI.messageIsNew = true;
                listernerParams.serverUI.newMessage = clientMessage;

            }
        }

        catch (SystemException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    /// <summary>
    /// Listener Parameters needed within Parameterized Thread Start for client
    /// </summary>
    class ListenerParams
    {
        public TcpListener clientTcp;
        public serverForm serverUI;
        public Socket clientSocket;
    }
}



