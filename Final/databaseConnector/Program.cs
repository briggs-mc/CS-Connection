using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;

namespace UserInterface
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        
            Client theClient = new Client();
            TcpClient serverSocket;
            userForm ui = new userForm();
            paramsForThread parameters= new paramsForThread();
            parameters.IPAddress= args[0];
            parameters.portNumber = Convert.ToInt32(args[1]);
            //new ParameterizedThreadStart((object) args)
            ParameterizedThreadStart initialize = new ParameterizedThreadStart(Start);
            Thread newThread = new Thread(initialize);
           // Client.startInit();
            newThread.Start(parameters);
     
            Application.Run(new splashScreen());

        }
        static void Start(object serverParameters)
        {

            paramsForThread server = (paramsForThread)serverParameters;
            TcpClient theClient = new TcpClient();
            theClient = Client.connect(theClient, server.IPAddress, server.portNumber);
            Client.startInit(theClient);
        }
    }

    class paramsForThread
    {   
        public string IPAddress;
        public int portNumber;
    }
   
}
