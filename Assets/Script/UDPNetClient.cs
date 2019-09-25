using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class UDPNetClient : NetClient
{

    public override void Start()
    {
        thread = new Thread(new ThreadStart(InitSocketAndConnect));
        thread.Start();
    }

    protected override void InitSocketAndConnect()
    {
        try {
            base.InitSocketAndConnect();
            this.socket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            this.socket.Connect(endPoint);
            isConnected = true;
        }
        catch (Exception e)
        {
            // exception
        }
    }


    void Rev()
    {
        while (true)
        {
            this.socket.Receive(buffer);
        }
    }

}
