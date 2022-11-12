using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {

            float randomX = Random.Range(-7, 7);

            Instantiate(enemy, new Vector3(randomX, transform.position.y, 0), Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(1,3));
        }
    }
    
}
