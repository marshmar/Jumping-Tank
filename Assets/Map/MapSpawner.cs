using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public Transform player;
    public GameObject mapPrefab;
    public GameObject finishLinePrefab;
    private int mapSpawnCount = 0;
    private bool existFinishLine = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateMap());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CreateMap()
    {
        while (true)
        {
            if (player.position.z - 10 > transform.position.z && existFinishLine == false)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 40);

                Instantiate(mapPrefab, transform.position, transform.rotation);

                mapSpawnCount++;
            }

            if (mapSpawnCount == 7 && existFinishLine == false)
            {
                transform.position = new Vector3(transform.position.x, 4, transform.position.z);
                Instantiate(finishLinePrefab, transform.position, transform.rotation);
                existFinishLine = true;
            }

            yield return null;
        }

    }
}
