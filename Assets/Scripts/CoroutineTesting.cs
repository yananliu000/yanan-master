using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveToTarget(GameObject target, float stopDistance, float detectDistance, float speed)
    {
        //get the distance bewteen self and target
        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

        //not arrive or not detect
        while (distanceToTarget >= stopDistance && distanceToTarget < detectDistance)
        {
            //the units per second to travel
            float step = speed * Time.deltaTime;

            //self will look at the target
            transform.LookAt(target.transform.position);

            //move 
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
            distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            yield return null; //pause until next frame
        }
        yield return null;
    }
}
