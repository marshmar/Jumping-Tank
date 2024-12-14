using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private AudioSource auido;
    public AudioClip cannonSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 4.0f);
    }

    public void shootBullet(Vector3 vecBullet)
    {
        Rigidbody rigBody = GetComponent<Rigidbody>();
        rigBody.AddForce(vecBullet);
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "ENEMY")
        {
            GameObject scoreManagerObj = GameObject.Find("ScoreManager");
            ScoreManager scoreManagerScr = scoreManagerObj.GetComponent<ScoreManager>();
            scoreManagerScr.increaseScore();

            Destroy(gameObject, 0.1f);
            Destroy(coll.gameObject, 0.1f);

            GameObject itemManagerObj = GameObject.Find("ItemSpawner");
            ItemSpawner itemManagerScr = itemManagerObj.GetComponent<ItemSpawner>();
            itemManagerScr.itemSpawn(coll.transform);
        }
    }
}
