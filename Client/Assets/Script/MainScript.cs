using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{

    private void Awake() {
        GameManager.Instance.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
