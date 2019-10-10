using CustomProtocol;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Frame : ILife
{
    public int PlayerId;
    public PlayerEntity playerEntity;
    RingBuffer rbuffer = new RingBuffer();
    bool isFirstFrame;
    int curFrameTick = -1;
    float passTime = 0f;
    FSVector3 v3Dir = new FSVector3();
    FSVector3 endState = new FSVector3();
    int speed = 1000;
    bool calculateNextState;
    public void PushFrame(FrameInput f) {
        if (!isFirstFrame) {
            isFirstFrame = true;
            curFrameTick = f.tick;
        }
        rbuffer.PushNewFrame(f);
    }

    public virtual void DoAwake() {

    }

    public virtual void DoUpdate() {

    }

    public virtual void DoFixUpdate() {
        if(rbuffer.LatestPtr < 0) {
            //no frame
            Debug.Log(this.PlayerId + " the player current frame is null" );
            return;
        }
        FrameInput fi = rbuffer.GetFrame(curFrameTick);
        if (fi == null) {
            //need predict
            Debug.Log(this.PlayerId + " the player current frame " + curFrameTick + "is null");
            return;
        }


        if (!calculateNextState) {
            calculateNextState = true;
            v3Dir = GameManager.Input2Dir(fi, v3Dir);
            this.endState = this.playerEntity.FSyncTransform.pos + v3Dir * speed;
            //the endstate need to be save
            if(v3Dir != FSVector3.Zero) {
                int x = 9;
            }
        }
        if(passTime < 0 || passTime > GameManager.FrameInterval) {
            Debug.LogError("the pass time is out of range :" + passTime);
        }
        passTime += (Time.fixedDeltaTime * 1000);
        passTime = Mathf.Min(passTime, GameManager.FrameInterval);
        float p = passTime / GameManager.FrameInterval;
        this.playerEntity.FSyncTransform.pos = FSVector3.Lerp(this.playerEntity.FSyncTransform.pos, endState, p);
        if (passTime >= GameManager.FrameInterval) {
            calculateNextState = false;
            passTime -= GameManager.FrameInterval;
            //passTime = 0;

            curFrameTick++;
        }
        
    }

}

public class FrameInput : ICloneable{
    public int tick;
    public bool isUp;
    public bool isDown;
    public bool isLeft;
    public bool isRight;
    public long hashCode;
    public FSVector3 pos;
    public int playerId;
    public bool isSimulate;

    public void Copy(C2SPlayerInput pInput) {
        this.tick = pInput.tick;
        this.isUp = pInput.isUp;
        this.isDown = pInput.isDown;
        this.isLeft = pInput.isLeft;
        this.isRight = pInput.isRight;
        this.hashCode = 1011;
        this.pos = new FSVector3((int)pInput.pos.x, (int)pInput.pos.y, (int)pInput.pos.z);
        this.playerId = pInput.playerId;
    }

    public object Clone() {
        FrameInput pInput = new FrameInput();
        pInput.tick = this.tick;
        pInput.isUp = this.isUp;
        pInput.isDown = this.isDown;
        pInput.isLeft = this.isLeft;
        pInput.isRight = this.isRight;
        pInput.hashCode = 1011;
        pInput.pos = new FSVector3((int)this.pos.X, (int)this.pos.Y, (int)this.pos.Z);
        pInput.playerId = this.playerId;
        return pInput;
    }
}