using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;

namespace UserInterface
{
    /// <summary>
    /// Server must be started before client is ran.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        //Main starting the threads for the UI
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        
            Client theClient = new Client();
           // TcpClient serverSocket;
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
        /// <summary>
        /// Takes in the paramters and adds them to a paramsForThread.
        /// </summary>
        /// <param name="serverParameters"></param>
        static void Start(object serverParameters)
        {

            paramsForThread server = (paramsForThread)serverParameters;
            TcpClient theClient = new TcpClient();
            theClient = Client.connect(theClient, server.IPAddress, server.portNumber);
            Client.startInit(theClient);
        }
    }
    /// <summary>
    /// Hold the Ip and Port number.
    /// </summary>
    class paramsForThread
    {   
        public string IPAddress;
        public int portNumber;
    }
   
}
