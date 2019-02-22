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
        GetHealthLowerThanValue(100);
        GetHealthHigherThanPercent(80);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //In LoL, some abilities will cause extra damage to low health characters 
    //A new thing i learn is that if the object has two of the attribute component, the message will print twice
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

    // can i use a variable to set the range?   
    //is there any way to get the attribute range number?
    public void GetHealthHigherThanPercent(int percentage)
    {
        //create query
        var Query =
            from item in others
            where item.health < item.maxHealth* percentage/100
            select item;
        
        ////exe
        foreach (var item in Query)
        {
            Debug.Log("Object: " + item.name + "'s health percent is above: " + percentage + "%");
        }
    }
}
