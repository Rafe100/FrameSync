﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FrameSync {
    class Server {

        public const string Host = "127.0.0.1";
        public int tcpPort = 3001;
        public int udpPort = 3004;
        public const int removeUdpPort = 3003;
        MessagHandler message;
        NetClient tcpClient;
        NetClient udpClinet;
        TcpListener tcpListen;
        int playerId = 1000;

        public Server() {
            message = new MessagHandler();
        }


        public void Update() {
            if (tcpClient != null) {
                ReceiveData revData = tcpClient.NetWorkMessageDequeue();
                if (revData != null) {
                    Console.WriteLine("tcp接收到消息" + revData.MsgId + " " + revData.MsgObject.GetType().ToString());
                    message.Dispatch(revData);
                }
            }
            if (udpClinet != null) {
                ReceiveData revData = udpClinet.NetWorkMessageDequeue();
                if (revData != null) {
                    Console.WriteLine("udp接收到消息" + revData.MsgId + " " + revData.MsgObject.GetType().ToString());
                    message.Dispatch(revData);
                }
            }
        }

        public void InitTcp() {
            tcpClient = new TCPNetClient(Host, tcpPort);
            tcpClient?.Start();
        }

        public void InitUdp(int rUdpP = removeUdpPort, string udpH = Host) {
            udpClinet = new UDPNetClient(Host, udpPort, Host, rUdpP);
            udpClinet?.Start();
        }


        public void Register(int key, Action<ReceiveData> callBack) {
            this.message.Regist(key, callBack);
        }

        public void RegisterOnce(int key, Action<ReceiveData> callBack) {
            this.message.RegistOnce(key, callBack);
        }

        private void OnDestroy() {
            this.tcpClient?.Dispose();
            this.udpClinet?.Dispose();
        }

        public void CloseTcp() {
            this.tcpClient?.Dispose();
        }

        public void CloseUdp() {
            this.udpClinet?.Dispose();
        }

        public void SendTCP(object obj) {
            this.tcpClient.Send(obj);
        }

        public void SendUDP(object obj) {
            this.udpClinet.Send(obj);
        }

        public void StartRev() {
            this.tcpClient?.StartRev();
            this.udpClinet?.StartRev();
        }



        public void ConnectTcp(ReceiveData rev) {
            Console.Write("a new connection");
            var rsp = new  CustomProtocol.PlayerConnectRsp();
            rsp.playId = this.playerId;
            this.playerId++;
            Debug.Log("the server playerid :" + playerId + "udpPort:" + revData.udpPort);
            NetWorkManager.Instance.CloseTcp();
            NetWorkManager.Instance.InitUdp(revData.udpPort);
            //test
            var o = new CustomProtocol.PlayerConnectRsp();
            o.playId = playerId + 1;
            NetWorkManager.Instance.SendUDP(o);
        }

    }
}
