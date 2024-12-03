using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters()); // Start the coroutine
    }

    IEnumerator SpawnMonsters()
    {
        yield return new WaitForSeconds(Random.Range(1, 5));

        randomIndex = Random.Range(0, monsterReference.Length);
        randomSide = Random.Range(0, 2);

        spawnedMonster = Instantiate(monsterReference[randomIndex]); // Spawn the monster

        if (randomSide == 0) // Spawn on the left side
        {
            spawnedMonster.transform.position = leftPos.position;
            spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10); // Move right
            spawnedMonster.transform.localScale = new Vector3(1f, 1f, 1f); // Face right
        }
        else // Spawn on the right side
        {
            spawnedMonster.transform.position = rightPos.position;
            spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10); // Move left
            spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f); // Face left
        }

        // Restart the coroutine for continuous spawning
        StartCoroutine(SpawnMonsters());
    }

    // Update is called once per frame
    void Update()
    {

    }
}