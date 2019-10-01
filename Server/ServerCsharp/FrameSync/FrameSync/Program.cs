using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameSync {
    class Program {
        static void Main(string[] args) {

            var server = new Server();
            server.RegisterOnce(ClientProtocol.MsgId_connect, server.ConnectTcp);
            server.InitTcp();

            while (true) {

                server.Update();

            }



        }

    
    }
}
