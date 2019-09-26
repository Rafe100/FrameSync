using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class TCPNetClient : NetClient {

    public TCPNetClient(string netHost,int netPort) {
        this.host = netHost;
        this.port = netPort;
    }

    protected override void InitSocket() {
        try {
            base.InitSocket();
            this.socket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        } catch (Exception e) {
            // exception
        }
    }

    protected override void Connect() {
        base.Connect();
    }
}
