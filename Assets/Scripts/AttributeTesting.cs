using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AddComponentMenu Attribute:enable to add the script in the Component menu, input hello to find the script
[AddComponentMenu("hello")]

public class AttributeTesting : MonoBehaviour
{
    [Header("Attribute Testing")] //Header Attribute
    [Tooltip("Health value between 0 and 100.")] //tooltip Attribute: will show the tooltip when hover it in the editor menu
    [Range(0,100)]  //Range Attribute: make the variable have range
    public int health = 0;

    [Space(10)] // Space Attribute: 10 pixels of spacing here.
    public int damage = 0;

    [SerializeField] //SerializeField Attribute: force it to serialize a private variable
    private bool hasHealthPotion = true;

    [HideInInspector]// HideInInspector Attribute: Make the variable p not show up in the inspector, but be serialized. hide for the designer
    public int hidden = 5;

    [TextArea] //TextArea Attribute: to make a string be edited with a height-flexible and scrollable text area.
    public string MyTextArea;

    [Multiline] //Multiline Attribute:  to make a string be edited with a multi-line textfield
    public string MultilineTextArea;

    void Start()
    {
    }

    void Update()
    {
        
    }

    //ContextMenu Attribute: run the function in the context menu, used to quickly load scene data
    [ContextMenu("ContextMenu Attribute")]
    public void ContextMenuFunction()
    {
        Debug.Log("Perform ContextMenu Attribute");
    }

  
}
