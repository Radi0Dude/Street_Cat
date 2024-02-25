using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningInfinteEnemy : MonoBehaviour
{
    public GameObject EnemyDefece;
    public GameObject EnemyMiddle;
    public GameObject EnemyAttack;
    private int randomNumberStyle;
    private bool spawnToggle;
    [SerializeField]
    private int reeatingSpawn;
    public List<GameObject> enemies = new List<GameObject>();

    private void Start()
    {
        InvokeRepeating("SpawnRandomStyle", 0, reeatingSpawn);
    }

    public void ToggleSpawner()
    {
        spawnToggle = !spawnToggle;
    }
    private void SpawnRandomStyle()
    {
        if (spawnToggle) 
        {
            randomNumberStyle = Random.Range(1, 3);

            if (randomNumberStyle == 1)
            {
                GameObject enemy = Instantiate(EnemyDefece);
                enemies.Add(enemy);

            }
            else if (randomNumberStyle == 2)
            {
                GameObject enemy = Instantiate(EnemyMiddle);
                enemies.Add(enemy);
            }
            else
            {
                GameObject enemy = Instantiate(EnemyAttack);
                enemies.Add(enemy);
            }
        }
    }
    private void Update()
    {
      if ( enemies.Count <= 0)
        {
            SpawnRandomStyle();
        }
    }

}
