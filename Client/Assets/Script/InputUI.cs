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

    public static bool isActive;

    public  bool isUp;
    public  bool isDown;
    public  bool isLeft;
    public  bool isRight;

     bool _isUp;
     bool _isDown;
     bool _isLeft;
     bool _isRight;

    private void Awake() {
        UpBtn.BtnAction = Up;
        DownBtn.BtnAction = Down;
        LeftBtn.BtnAction = Left;
        RightBtn.BtnAction = Right;
    }

    public void Reset() {
        isActive = true;
        isUp = _isUp;
        isDown = _isDown;
        isRight = _isRight;
        isLeft = _isLeft;
    }

    public void ResetInput() {
        isUp = _isUp;
        isDown = _isDown;
        isLeft = _isLeft;
        isRight = _isRight;
    }

    public void Up(bool isOn) {
        _isUp = isOn;
        if (isActive) {
            isActive = false;
            isUp = _isUp;
        }
    }
    public void Down(bool isOn) {
        _isDown = isOn;
        if (isActive) {
            isActive = false;
            isDown = _isDown;
        }
    }
    public void Left(bool isOn) {
        _isLeft = isOn;
        if (isActive) {
            isActive = false;
            isLeft = _isLeft;
        }
    }
    public void Right(bool isOn) {
        _isRight = isOn;
        if (isActive) {
            isActive = false;
            isRight = _isRight;
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
