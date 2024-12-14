using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform player;

    public GameObject obstaclePrefab;
    public GameObject turningObstaclePrefab;

    private float interval = 1.2f;
    private float rndXRange = 6.0f;
    private int range = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateObstacle());
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    IEnumerator CreateObstacle()
    {
        WaitForSeconds wait = new WaitForSeconds(interval);
        while (true)
        {
           

            int obstacleType = Random.Range(0, range + 1);
            Vector3 origininalPos = transform.position;
            
            if (obstacleType == 0)
            {
                float xPos = Random.Range(-rndXRange, rndXRange);
                transform.position = new Vector3(xPos, transform.position.y, player.position.z + 20);
                Instantiate(turningObstaclePrefab, transform.position, transform.rotation);
                transform.position = origininalPos;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z + 20);
                Instantiate(obstaclePrefab, transform.position, transform.rotation);
            }
            
            yield return wait;
        }
        
    }
}
