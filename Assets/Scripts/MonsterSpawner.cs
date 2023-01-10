using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnMonster;

    [SerializeField]
    private Transform

            leftPos,
            rightPos;

    private int randomIndex;

    private int randomSide;

    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {

            randomIndex = Random.Range(0, monsterReference.Length);

            randomSide = Random.Range(0, 2);

            spawnMonster = Instantiate(monsterReference[randomIndex]);

            if (randomSide == 0)
            {
                spawnMonster.transform.position = leftPos.position;
                spawnMonster.GetComponent<Monster>().speed =
                    Random.Range(4, 6);
            }
            else
            {
                spawnMonster.transform.position = rightPos.position;
                spawnMonster.GetComponent<Monster>().speed =
                    -Random.Range(4, 6);
                spawnMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }

            yield return new WaitForSeconds(Random.Range(1, 3));

        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
