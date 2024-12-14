using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleController: MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move the obstacle
        transform.Translate(0, 0, speed * Time.deltaTime);

        //Destroy the obstacle
        Destroy(gameObject, 6.0f);
    }
}
