using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnoptimizeTesting : MonoBehaviour
{
    public bool m_isActivated = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var list = GameObject.FindGameObjectsWithTag("Cube");
        foreach (var a in list)
        {
            if (m_isActivated)
            {
                a.transform.position += new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
                var list2 = GameObject.FindObjectsOfType<CoroutineTesting>();
                foreach (var e in list2)
                {
                    if (e.GetComponent<GizmoTesting>())
                    {
                        BroadcastMessage("BroadcastMe");
                    }
                    else
                    {
                        a.transform.position -= new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
                    }
                }
            }
        }
    }

    public void BroadcastMe()
    {
        Debug.Log("UnoptimizeTesting succeed");
    }

}

