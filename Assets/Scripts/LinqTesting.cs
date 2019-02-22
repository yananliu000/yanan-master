using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //must include to use the functionalities

public class LinqTesting : MonoBehaviour
{
    private AttributeTesting[] others;

    // Start is called before the first frame update
    void Start()
    {
        others = GameObject.FindObjectsOfType<AttributeTesting>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //In LoL, some abilities will cause extra damage to low health characters 
    public void GetHealthLowerThanValue(int value)
    {
        //create query
        var Query =
            from item in others
            where item.health < value
            select item;

        //exe
        foreach (var item in Query)
        {
            Debug.Log("Object: " + item.name + "'s health is below: " + value);
        }
    }

    //is there any shortcut way to get the attribute range of health?
    public void GetHealthHigherThanPercent(float percent)
    {
        //create query
        //var Query =
        //    from item in others
        //    where item.health < 
        //    select item;
        //
        ////exe
        //foreach (var item in Query)
        //{
        //    Debug.Log("Object: " + item.name + "'s health is below: " + value);
        //}
    }
}
