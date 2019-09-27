using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleInstance<GameManager> {
    public string playerId;

    private void Awake() {
        NetWorkManager.Instance.Register(ClientProtocol.MsgId_connectRsp, ConnectRsp);
        NetWorkManager.Instance.Register(ClientProtocol.MsgId_connect, SocketConnected);

    }

    void SocketConnected(ReceiveData rev) {
        Debug.Log("SocketConnected" + rev.MsgId);
    }

    void ConnectRsp(ReceiveData rev) {
        var revData = rev.MsgObject as CustomProtocol.PlayerConnectRsp;
        playerId = revData.playId;
        Debug.Log("ConnectRsp" + playerId);
    }


}
