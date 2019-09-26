using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagHandler 
{
    Dictionary<int, Action<ReceiveData>> handlers = new Dictionary<int, Action<ReceiveData>>();
    Dictionary<int, Action<ReceiveData>> onceHandlers = new Dictionary<int, Action<ReceiveData>>();

    public void Regist(int key,Action<ReceiveData> callBack) {
        if (!handlers.ContainsKey(key)) {
            handlers.Add(key, null);
        }
        handlers[key] += callBack;
    }

    public void Dispatch(ReceiveData rev) {
        if (handlers.ContainsKey(rev.MsgId)) {
            handlers[rev.MsgId](rev);
        }
    }

}
