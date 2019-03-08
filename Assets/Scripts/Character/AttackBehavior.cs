using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : MonoBehaviour
{
    float totalDamge = 0;
    float totalTakenDamge = 0;
    AttackBehavior[] m_gameObjects;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartAttacking());
    }

    IEnumerator StartAttacking()
    {
        while(true)
        {
            float testnumber = 100;
            AttackBehavior enemy = FindObjectOfType<AttackBehavior>();
            Attack(Random.Range(0.0f, 10.0f), testnumber);
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float Attack(float damage, float enemyHp)
    {
        totalDamge += damage;
        return enemyHp - damage;
    }
    
    public float GetTotalDamge()
    {
        return totalDamge;
    }

    public float GetAttack(float damage, float hp)
    {
        totalTakenDamge += damage;
        return hp - damage;
    }

    public AttackBehavior[] GetAttackObjects()
    {
        m_gameObjects = FindObjectsOfType<AttackBehavior>();
        return m_gameObjects;
    }


}
