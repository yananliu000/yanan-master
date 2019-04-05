using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnDrawGizmos()
    {
        DrawVisionFrustum();

    }

    void OnDrawGizmosSelected()
    {
        //DrawVisionLines();
    }

    void DrawVisionLines()
    {
        float totalFOV = 70.0f;
        float rayRange = 10.0f;
        float halfFOV = totalFOV / 2.0f;
        Quaternion leftRayRotation = Quaternion.AngleAxis(-halfFOV, Vector3.up);
        Quaternion rightRayRotation = Quaternion.AngleAxis(halfFOV, Vector3.up);
        Vector3 leftRayDirection = leftRayRotation * transform.forward;
        Vector3 rightRayDirection = rightRayRotation * transform.forward;
        Gizmos.DrawRay(transform.position, leftRayDirection * rayRange);
        Gizmos.DrawRay(transform.position, rightRayDirection * rayRange);
    }

    void DrawVisionFrustum()
    {
        float fov = 50.0f;
        float aspect = 1.5f;
        float maxRange = 7.5f;
        float minRange = 1.0f;

        Gizmos.color = Color.cyan;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.DrawFrustum(Vector3.zero, fov, maxRange, minRange, aspect);

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Gizmos.matrix);
        
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Cube");
        foreach (GameObject go in allObjects)
        {
            Collider coll = go.GetComponent<Collider>();
            if (coll)
            {
                bool pass = true;
                for(int i = 0; i < planes.Length; ++i)
                {
                    if (!planes[i].GetSide(go.transform.position))
                    {
                        pass = false;
                    }
                }

                if(pass)
                {
                    Gizmos.color = Color.red;
                    Vector3 higher = new Vector3(0, 1.0f, 0);
                    Gizmos.DrawSphere(go.transform.position - this.transform.position + higher , 0.2f);
                    Debug.Log(go.name);
                }
            }
        }
    }
}


