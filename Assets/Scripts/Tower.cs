using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    Transform targetEnemy;
    [SerializeField] float attackRange=10f;
    [SerializeField] ParticleSystem projectileParticle;
    public Waypoint baseWaypoint;

    void Update()
    {
        SetTargetEnemy();
        if(targetEnemy){
        objectToPan.LookAt(targetEnemy);
        FireAtEnemy();
        }
        else{
            Shoot(false);
        }
        

    }

    private void SetTargetEnemy()
    {
        var sceneEnemies=FindObjectsOfType<EnemyDamage>();
        if(sceneEnemies.Length==0){
            return;
        }
        Transform closestEnemy=sceneEnemies[0].transform;
        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy=getClosest(closestEnemy,testEnemy.transform);
        }
        targetEnemy=closestEnemy;

    }
    
    private Transform getClosest(Transform transformA, Transform transformB)
    {
        var distanceToA=Vector3.Distance(transform.position,transformA.position);
        var distanceToB=Vector3.Distance(transform.position,transformB.position);
        if(distanceToA<distanceToB){
            return transformA;
        }
        return transformB;

    }
    private void FireAtEnemy()
    {
        float distanceToEnemy=Vector3.Distance(targetEnemy.transform.position,gameObject.transform.position);
        if(distanceToEnemy <= attackRange){
            //print(distanceToEnemy);

            Shoot(true);
        }
        else{
            //print(distanceToEnemy);
            Shoot(false);
        }
        
    }
    

    private void Shoot(bool isActive)
    {
        var emission=projectileParticle.emission;
        emission.enabled=isActive;
    }
}
