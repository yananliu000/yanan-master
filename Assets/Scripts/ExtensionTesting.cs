using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExtensionTesting : MonoBehaviour
{
    private Object[] others;

    // Start is called before the first frame update
    void Start()
    {
        others = this.gameObject.FindObjectsOfTypes<AttributeTesting, LinqTesting>();
    }

    void Update()
    {
    }
}

public static class ExtensionMethods
{
    //variadic templates
    //return objects with both the component types
    public static GameObject[] FindObjectsOfTypes<T, U>(this GameObject obj)
    {
        //get all components of the scene
        MonoBehaviour[] all = GameObject.FindObjectsOfType<MonoBehaviour>();

        //add them into the set: avoid multiple adding
        HashSet<GameObject> results = new HashSet<GameObject>();

        foreach(MonoBehaviour mb in all)
        {
            if(mb.GetComponent<T>() != null && mb.GetComponent<U>() != null)
            {
                results.Add(mb.gameObject);
            }
        }
        return results.ToArray();
    }

    //for static methods, cannot extend
    //can make a wrapper class that extends the functionality of static classes ()
}
