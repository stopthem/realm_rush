using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]ParticleSystem goalExplosion;
    [SerializeField]float spawnTime=.5f;

    void Start()
    {
        PathFinder pathfinder=FindObjectOfType<PathFinder>();
        var path=pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position=waypoint.transform.position;
            yield return new WaitForSeconds(spawnTime);

        }

        ParticleSystem goalfx = Instantiate(goalExplosion, transform.position, Quaternion.identity);
        Destroy(goalfx.gameObject,1f);
        Destroy(gameObject);
        
    }
}
