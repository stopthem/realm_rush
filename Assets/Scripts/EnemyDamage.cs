using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] ParticleSystem deathFX;
    [SerializeField] int scorePerHit = 1;
    [SerializeField] int health = 10;
    [SerializeField] ParticleSystem hitFX;
    [SerializeField] AudioClip enemyDamageSFX;
    [SerializeField] AudioClip enemyDeathsSFX;
    public void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        ParticleSystem hitfx = Instantiate(hitFX, transform.position, Quaternion.identity);
        Destroy(hitfx.gameObject,1f);
        if (health <= 0)
        {
            KillEnemy();
        }
        
    }
    private void ProcessHit()
    {
        GetComponent<AudioSource>().PlayOneShot(enemyDamageSFX);
        health-=scorePerHit;
    }

    private void KillEnemy()
    {
        ParticleSystem deathfx = Instantiate(deathFX, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(enemyDeathsSFX,Camera.main.transform.position);
        FindObjectOfType<EnemySpawner>().decreaseEnemy();
        Destroy(deathfx.gameObject,deathfx.main.duration);
        Destroy(gameObject);
        
    }

}
