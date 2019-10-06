using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputUI : MonoBehaviour
{
    public ButtonEvent UpBtn;
    public ButtonEvent DownBtn;
    public ButtonEvent LeftBtn;
    public ButtonEvent RightBtn;

    public static bool isUp;
    public static bool isDown;
    public static bool isLeft;
    public static bool isRight;

    private void Awake() {
        UpBtn.BtnAction = Up;
        DownBtn.BtnAction = Down;
        LeftBtn.BtnAction = Left;
        RightBtn.BtnAction = Right;
    }

    public void Up(bool isOn) {
        isUp = isOn;
        Debug.Log("up is on:" + isOn);
    }
    public void Down(bool isOn) {
        isDown = isOn;
        Debug.Log("Down is on:" + isOn);
    }
    public void Left(bool isOn) {
        isLeft = isOn;
        Debug.Log("Left is on:" + isOn);
    }
    public void Right(bool isOn) {
        isRight = isOn;
        Debug.Log("Right is on:" + isOn);
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
