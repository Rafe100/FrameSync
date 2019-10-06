using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity {


    Dictionary<string, ComponentBase> components = new Dictionary<string, ComponentBase>();


    public T GetComponent<T>() where T : ComponentBase {
        T res = null;
        if (components.ContainsKey(typeof(T).Name)) {
            res = components[typeof(T).Name] as T;
        }
        return res;
    }


}
