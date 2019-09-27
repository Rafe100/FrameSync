using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System;

public class NetClient
{
    public const Int32 MAX_PACKAGE_LENGTH = 1024 * 64 * 4;
    public bool isConnected;
    protected string host;
    protected int port;
    protected Socket socket;
    protected IPEndPoint endPoint;
    protected Thread thread;
    protected byte[] buffer;

    public NetClient()
    {
        buffer = new byte[MAX_PACKAGE_LENGTH];
    }
    public virtual void Start()
    {

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

    protected virtual void InitSocketAndConnect() {
        Adress();
    }
    

}
