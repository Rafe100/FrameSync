using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    public static void Lg(string str) {
        string ex = "<color=cyan>";
        string eb = "</color>";
        Debug.Log(ex + str + eb);
    }

    public static Vector3 FromSyncVec3(this Vector3 v,FSVector3 SyncVec) {
        v.x = SyncVec.X / (FSFloat.precision * 1.0f);
        v.y = SyncVec.Y / (FSFloat.precision * 1.0f);
        v.z = SyncVec.Z / (FSFloat.precision * 1.0f);
        return v;
    }
}
