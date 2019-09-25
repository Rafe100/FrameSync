using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector2 a = new Vector2(0f, 0f);
        Vector2 b = new Vector2(1.0f, 1.0f);

        var v = Vector2.Lerp(a, b,0.3f);
        FSFloat t = 1;
        Debug.Log(v.ToString());
        FSQuaternion r = new FSVector4(1,1,1,1);
        //Quaternion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
