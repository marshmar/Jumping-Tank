using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform player;
    public GameObject enemyPrefab;
    private float interval = 2.0f;
    private float range = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateFood());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    IEnumerator CreateFood()
    {
        WaitForSeconds wait = new WaitForSeconds(interval);
        while (true)
        {
            float foodXpos = Random.Range(-range, range);
            transform.position = new Vector3(foodXpos, transform.position.y, player.position.z + 20);

            Instantiate(enemyPrefab, transform.position, transform.rotation);

            yield return wait;
        }

    }

}
