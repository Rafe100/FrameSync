using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEvent : Button
{
    public Action<bool> BtnAction;
    public override void OnPointerDown(PointerEventData eventData) {
        base.OnPointerDown(eventData);
        if (BtnAction != null) {
            BtnAction(true);
        }
    }

    public override void OnPointerUp(PointerEventData eventData) {
        base.OnPointerUp(eventData);
        if (BtnAction != null) {
            BtnAction(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
