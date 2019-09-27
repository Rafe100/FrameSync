using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetWorkManager : SingleInstance<NetWorkManager> {
    public string Host = "127.0.0.1";
    public int tcpPort = 10083;
    public int udpPort = 10082;
    MessagHandler message;
    NetClient tcpClient;
    NetClient udpClinet;

    public NetWorkManager() {
        udpClinet = new UDPNetClient(Host, udpPort);
        //tcpClient = new TCPNetClient(Host, tcpPort);
        message = new MessagHandler();
    }

    private void Awake() {
        
        udpClinet?.Start();
        tcpClient?.Start();
    }

    private void Update() {
        if (tcpClient != null) {
            ReceiveData revData = tcpClient.NetWorkMessageDequeue();
            if (revData != null) {
                Debug.Log("tcp接收到消息" + revData.MsgId);
                message.Dispatch(revData);
            }
        }
        if (udpClinet != null) {
            ReceiveData revData = udpClinet.NetWorkMessageDequeue();
            if (revData != null) {
                Debug.Log("udp接收到消息" + revData.MsgId);
                message.Dispatch(revData);
            }
        }
    }


    public void Register(int key,Action<ReceiveData> callBack) {
        this.message.Regist(key, callBack);
    }

    private void OnDestroy() {
        this.tcpClient?.Dispose();
        this.udpClinet?.Dispose();
    }

}
