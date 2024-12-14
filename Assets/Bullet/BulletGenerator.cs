using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int bulletPower;
    private int fireCount;
    private bool isReload = false;
    private float reloadTime = 0;
    private Text bulletText;

    private AudioSource audio;
    public AudioClip cannonSound;
    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        audio.clip = this.cannonSound;
        audio.loop = false;

        GameObject bulletObj = GameObject.Find("Bullet");
        this.bulletText = bulletObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isReload)
        {
            reloadTime += Time.deltaTime;
            if (reloadTime >= 3)
            {
                reloadTime = 0;
                isReload = false;
            }
            this.bulletText.text = "Reloading...";
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {   
                audio.Play();
                GameObject bulletObj = Instantiate(bulletPrefab, transform.position, transform.rotation);

                Vector3 vecBullet = new Vector3(0, 0, bulletPower);
                BulletController bulletControllerScr = bulletObj.GetComponent<BulletController>();
                bulletControllerScr.shootBullet(vecBullet);

                fireCount++;
                
                if (fireCount == 5)
                {
                    isReload = true;
                    fireCount = 0;
                }
                    
            }
            this.bulletText.text = "Bullets: " + (5 - fireCount).ToString();
        }


    }
}
