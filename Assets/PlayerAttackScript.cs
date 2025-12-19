using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{

    public GameObject attackPrefab;
    public float attackInterval = 1.0f;
    public float attackrange = 5.0f;

    private float attackTimer;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += attackInterval;

        if (attackTimer >= attackInterval)
        {
            attackTimer = 0f;

        }
    }

    void Attack()
    {
        EnemyScript target = FindNearestEnemy();
        
        if (target == null) return;

        Vector3 dir = (target.transform.position - transform.position).normalized;

        GameObject attack = Instantiate(
            attackPrefab,
            transform.position + dir,
            Quaternion.identity
            );
    }

    EnemyScript FindNearestEnemy()
    {
        EnemyScript[] enemyes = FindObjectsOfType<EnemyScript>();

        EnemyScript nearest = null;
        float minDistance = attackrange;

        foreach(EnemyScript enemy in enemyes)
        {
            float dist = Vector3.Distance(
                transform.position,
                enemy.transform.position
                );
            if(dist<minDistance)
            {
                minDistance = dist;
                nearest = enemy;
            }
        }

        return nearest;
    }
}
