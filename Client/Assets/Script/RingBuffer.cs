using CustomProtocol;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingBuffer
{
    const int frameLength = 256;
    C2SPlayerInput[] frames = new C2SPlayerInput[frameLength];

    public int LatestPtr {
        get { return this.latestPtr; }
    }
    //point to the latest
    int latestPtr = -1;
    //point to the checked ptr +1
    int checkedPtr = -1;

    public void PushNewFrame(C2SPlayerInput f) {
        latestPtr++;
        frames[latestPtr % frameLength] = f;
    }

    public bool CheckLatestFrame(int f) {
        return f == latestPtr;
    }

    public C2SPlayerInput GetLatestFrame() {
        return frames[latestPtr];
    }

    public C2SPlayerInput GetFrame(int i) {
        if (i < latestPtr) {
            int index = (i) % frameLength;
            return frames[index];
        } else {
            return null;
        }
    }

    public C2SPlayerInput GetNextFrame(int i) {
        if (i < latestPtr) {
            int index = (i + 1) % frameLength;
            return frames[index];
        } else {
            return null;
        }
    }
}
