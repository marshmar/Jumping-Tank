using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningObstacle : MonoBehaviour
{
    public int speed;
    public int turingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        this.transform.Rotate(0.0f, 0.0f, turingSpeed * Time.deltaTime);
        Destroy(gameObject, 10.0f);
    }
}
