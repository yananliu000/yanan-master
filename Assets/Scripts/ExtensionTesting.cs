using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtensionTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.ResetTransformation();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

//Extension Methods!
//must be static: both class and function
//this representes where the original function come from 
public static class ExtensionMethods
{
    //reset the obj position to user-defined v3
    public static void ResetTransformation(this Transform trans)
    {
        Debug.Log("extented");
        trans.position = Vector3.zero;
        trans.localRotation = Quaternion.identity;

        trans.localScale = new Vector3 (1,1,1);
    }
}
