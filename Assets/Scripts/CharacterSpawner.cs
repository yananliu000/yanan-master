using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    private Object[] textures;

    // Start is called before the first frame update
    void Start()
    {
        textures = Resources.LoadAll("", typeof(Texture2D));

        foreach (var t in textures)
        {
            Debug.Log(t.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCharacter();
        }
    }

    void SpawnCharacter()
    {
        //spawn pieces
        List<GameObject> bodyPieces = new List<GameObject>();
        Debug.Log("Spawn New!");
        bodyPieces.Add(GameObject.CreatePrimitive(PrimitiveType.Sphere)); //head
        bodyPieces.Add(GameObject.CreatePrimitive(PrimitiveType.Cube)); //body
        bodyPieces.Add(GameObject.CreatePrimitive(PrimitiveType.Cylinder)); //arm
        bodyPieces.Add(GameObject.CreatePrimitive(PrimitiveType.Cylinder)); //arm
        bodyPieces.Add(GameObject.CreatePrimitive(PrimitiveType.Capsule)); //leg
        bodyPieces.Add(GameObject.CreatePrimitive(PrimitiveType.Capsule)); //leg

        //change the overall position && adjust size 
        Vector3 range = new Vector3(Random.Range(-4.5f, 4.5f), 0, Random.Range(-4.5f, 4.5f));
        foreach (var t in bodyPieces)
        {
            t.GetComponent<Renderer>().material.mainTexture = (Texture2D)textures[Random.Range(0, textures.Length)];
            t.transform.position += range;
            t.transform.localScale -= new Vector3(0.5f,0.5f,0.5f);
        }

        //adjust each one' size and position
        bodyPieces[0].transform.position += new Vector3(0, 0.5f, 0);

        bodyPieces[1].transform.position += new Vector3(0, 0.2f, 0);

        bodyPieces[2].transform.position += new Vector3(0, 0.1f, 0.25f);
        bodyPieces[3].transform.position += new Vector3(0, 0.1f, -0.25f);
        bodyPieces[2].transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
        bodyPieces[3].transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);

        bodyPieces[4].transform.position += new Vector3(0, -0.3f, 0.1f);
        bodyPieces[5].transform.position += new Vector3(0, -0.3f, -0.1f);
        bodyPieces[4].transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
        bodyPieces[5].transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
    }
}
