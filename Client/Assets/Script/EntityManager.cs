using CustomProtocol;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager 
{

    public PlayerEntity CreatePlayerEntity(PlayerInfo pinfo) {
        return CreatePlayerEntity();
    }

    public PlayerEntity CreatePlayerEntity() {
        PlayerEntity e = new PlayerEntity();
        var obj = GameObject.Instantiate(GameManager.Instance.PlayerGameObject) as GameObject;
        e.UnityTransform = obj.transform;
        var view = obj.GetComponent<ViewBase>();
        if(view == null) {
            Debug.Log("EntityManager CreatePlayerEntity the player viewBase is null");
            return null;
        }
        view.BindEntity(e);
        return e;
    }
}

public class PlayerEntity : Entity {

  
}