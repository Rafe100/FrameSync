using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewBase : MonoBehaviour,ILife, IView {

    public Entity entity;

    public virtual void DoAwake() {

    }

    public virtual void DoUpdate() {

    }

    public virtual void DoFixUpdate() {

    }

    public virtual void BindEntity(Entity e) {
        entity = e;
    }

}

public interface ILife {

    void DoAwake();

    void DoUpdate();

    void DoFixUpdate();
    
}

public interface IView {
    void BindEntity(Entity e);
}