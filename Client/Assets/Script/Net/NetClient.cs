using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System;

public class NetClient : IDisposable
{
    public const Int32 MAX_PACKAGE_LENGTH = 1024 * 64 * 4;
    public bool isConnected;
    public ClientProtocol cProto {
        get { return clientProto; }
    }
    protected string host;
    protected int port;
    protected Socket socket;
    protected IPEndPoint endPoint;
    protected Thread thread;
    protected byte[] buffer;
    protected Transporter transporter;
    ClientProtocol clientProto;
    Queue<System.Object> revQueue = new Queue<object>(29);

   

    public NetClient()
    {
        clientProto = new ClientProtocol();
        buffer = new byte[MAX_PACKAGE_LENGTH];
    }

    public virtual void Start()
    {
        InitSocket();
        Connect();
    }

    public void NetWorkMessageEnqueue(ReceiveData revData) {
        if(revData == null) {
            return;
        }
        this.revQueue.Enqueue(revData);
    }

    public ReceiveData NetWorkMessageDequeue() {
        if (revQueue.Count <= 0) {
            return null;
        }
        return this.revQueue.Dequeue() as ReceiveData;
    }

    public Socket GetSocket() {
        return socket;
    }


    void Adress()
    {
        IPAddress address;
        if (!IPAddress.TryParse(this.host, out address))
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(this.host);
            IPAddress[] ipAddrs = hostEntry.AddressList;
            address = ipAddrs[0];
        }
        host = address.ToString();
        endPoint = new IPEndPoint(address, port);
    }

    protected virtual void InitSocket() {
        Adress();
    }
    
    protected virtual void InitTransporter() {
        this.transporter = new Transporter(this, this.socket);
    }

    protected virtual void Connect() {
        try {
            InitTransporter();
            this.socket.Connect(endPoint);
            isConnected = true;
            var connecMsg = new ReceiveData(ClientProtocol.MsgId_connect, new CusNetMesConnected());
            NetWorkMessageEnqueue(connecMsg);
        } catch(Exception e) {
            Debug.Log("connect exception:" + e.ToString());
        }
    }

    public virtual void Dispose() {
        this.socket.Shutdown(SocketShutdown.Both);
        this.socket.Close();
        this.socket = null;
        Debug.Log("socket is close");
    }

}
