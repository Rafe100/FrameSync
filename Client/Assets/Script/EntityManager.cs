using CustomProtocol;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager 
{
    public PlayerEntity CreatePlayerEntity(PlayerInfo pinfo) {
        PlayerEntity e = new PlayerEntity();
        var obj = GameObject.Instantiate(GameManager.Instance.PlayerGameObject) as GameObject;
        e.UnityTransform = obj.transform;
        var view = obj.GetComponent<ViewBase>();
        view.BindEntity(e);
        return e;
    }
}

public class PlayerEntity : Entity {
    public PlayerEntity():base(){
        FSyncTransform = new FSTransform();
    }
    public Transform UnityTransform;
    public FSTransform FSyncTransform;
}