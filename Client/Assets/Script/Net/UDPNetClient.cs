using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class UDPNetClient : NetClient
{
    public UDPNetClient(string netHost, int netPort) {
        this.host = netHost;
        this.port = netPort;
    }

    protected override void InitSocket()
    {
        try {
            base.InitSocket();
            this.socket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }
        catch (Exception e)
        {
            // exception
        }
    }

    protected override void Connect() {
        base.Connect();
        Debug.Log("udp connect");
    }




}
