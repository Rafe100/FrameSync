using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : ViewBase
{
    Vector3 pos = new Vector3();
    private void Update() {
        this.transform.position = pos.FromSyncVec3(this.entity.FSyncTransform.pos);
    }

}
