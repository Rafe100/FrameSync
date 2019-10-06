using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomProtocol;

public class GameManager : SingleInstance<GameManager> {
    public int playerId;
    public InputUI PlayerInputUI;
    public GameObject PlayerGameObject;
    public CameraFollow FollowCamera;
    public Dictionary<int, PlayerEntity> allPlayerEntity = new Dictionary<int, PlayerEntity>();

    bool serverGameStart = false;
    float timeInterval = 0;
    public const int FrameInterval = 30;
    int localFrameTick = 0;
    EntityManager entityMgr = new EntityManager();
    MoveSystem moveSys = new MoveSystem();
    public PlayerEntity curPlayer;
    Dictionary<int, Frame> allPlayerServerFrame = new Dictionary<int, Frame>();

    CustomProtocol.Vec3 curPlayerPos = new Vec3();
    private void Awake() {
        NetWorkManager.Instance.Register(ClientProtocol.MsgId_connect, SocketConnected);
        NetWorkManager.Instance.Register(MSG.Msgid_ServerFrame, ServerFrame);
        NetWorkManager.Instance.RegisterOnce(MSG.Msgid_GameStart, GameStart);
        NetWorkManager.Instance.InitTcp();
    }

    void SocketConnected(ReceiveData rev) {
        Debug.Log("SocketConnected" + rev.MsgId);
    }

    void GameStart(ReceiveData rev) {
        var revData = rev.MsgObject as CustomProtocol.GameStart;
        playerId = revData.playId;
        localFrameTick = revData.serverTick;
        localFrameTick++;
        Debug.Log("the server playerid :" + playerId + "udpPort:" + revData.udpPort + "playerCount:" + revData.playerList.Count);
        foreach (var x in revData.playerList) {
            Debug.Log("当前场景里得玩家:" + x.playId);
            var entity = this.entityMgr.CreatePlayerEntity(x);
            if (x.playId == playerId) {
                //currenty player
                curPlayer = entity;
            }
        }
        NetWorkManager.Instance.CloseTcp();
        NetWorkManager.Instance.InitUdp(revData.udpPort);
        serverGameStart = true;
        timeInterval = 0;


        FollowCamera.target = curPlayer.UnityTransform;
        //test
        //var o = new CustomProtocol.PlayerConnectRsp();
        //o.playId = playerId + 1;
        //NetWorkManager.Instance.SendUDP(o);
    }

    void ServerFrame(ReceiveData rev) {

    }

    private void FixedUpdate() {
        if (!serverGameStart) {
            return;
        }
        timeInterval += (Time.fixedDeltaTime * 1000);
        float interval = (FrameInterval);
        if (timeInterval >= interval){
            timeInterval -= interval;
            SendPlayerInput();
        }
        this.moveSys.DoFixUpdate();
    }

    void SendPlayerInput() {
        var pInput = new C2SPlayerInput();
        pInput.tick = this.localFrameTick;
        pInput.isUp = InputUI.isUp;
        pInput.isDown = InputUI.isDown;
        pInput.isLeft = InputUI.isLeft;
        pInput.isRight = InputUI.isRight;
        pInput.hashCode = 1011;
        curPlayerPos.x = curPlayer.FSyncTransform.pos.X;
        curPlayerPos.y = curPlayer.FSyncTransform.pos.Y;
        curPlayerPos.z = curPlayer.FSyncTransform.pos.Z;
        pInput.pos = curPlayerPos;
        pInput.playerId = this.playerId;

        var localInput = new FrameInput();
        localInput.Copy(pInput);
        PushLocalFrameInput(localInput);
        NetWorkManager.Instance.SendUDP(pInput);
        localFrameTick++;
    }


    void PushLocalFrameInput(FrameInput localInput) {
        if (!allPlayerServerFrame.ContainsKey(this.playerId)) {
            Debug.Log("the allPlayerServerFrame do not contain local player id:" + playerId);
            return;
        }
        var lframe =  allPlayerServerFrame[this.playerId];
        lframe.PushFrame(localInput);
    }

    public static  FSVector3 Input2Dir(FrameInput localInput, FSVector3 v3) {
        if (localInput.isUp) {
            v3.SetFSVector3(0, 0, 1);
        } else if (localInput.isRight) {
            v3.SetFSVector3(1, 0, 0);
        } else if (localInput.isLeft) {
            v3.SetFSVector3(-1, 0, 0);
        } else if (localInput.isDown) {
            v3.SetFSVector3(0, 0, -1);
        }else {
            v3.SetFSVector3(0, 0, 0);
        }
        return v3;
    }



}
