using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform newEnemyParent;
    [SerializeField] Text enemyCountText;
    [SerializeField] AudioClip enemySpawnSFX;
    int enemyCount;
    void Start()
    {
        StartCoroutine(spawnEnemies());
        enemyCountText.text="Sahadaki düsman sayisi: "+enemyCount.ToString();
    }
    IEnumerator spawnEnemies(){

        while (true)
        {
            var newEnemy=Instantiate(enemyPrefab,transform.position,Quaternion.identity);
            enemyCount++;
            GetComponent<AudioSource>().PlayOneShot(enemySpawnSFX);
            enemyCountText.text="Sahadaki düsman sayisi: "+enemyCount.ToString();
            yield return new WaitForSeconds(secondsBetweenSpawns);
            newEnemy.transform.parent=newEnemyParent;
        }
    }
    public void decreaseEnemy()
    {
        enemyCount--;
    }

}
