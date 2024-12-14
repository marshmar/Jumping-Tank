using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Player's status
    public int playerHealth;
    public float speed;
    public float jumpPower;
    public float dashPower;
    private bool isJumping = true;

    //Player's Audio
    private AudioSource jumpAudio;
    public AudioClip jumpSound;
    private AudioSource dashAudio;
    public AudioClip dashSound;
    private AudioSource itemAudio;
    public AudioClip itemSound;
    private AudioSource damageAudio;
    public AudioClip damageSound;

    //Dash variable
    private float dashCoolTime;
    bool isDashed = false;
    private Text dashCoolTimeText;
    private Text playerHealthText;

    // Start is called before the first frame update
    void Start()
    {
        jumpAudio = gameObject.AddComponent<AudioSource>();
        jumpAudio.clip = jumpSound;
        jumpAudio.loop = false;

        dashAudio = gameObject.AddComponent<AudioSource>();
        dashAudio.clip = dashSound;
        dashAudio.loop = false;

        damageAudio = gameObject.AddComponent<AudioSource>();
        damageAudio.clip = damageSound;
        damageAudio.loop = false;

        itemAudio = gameObject.AddComponent<AudioSource>();
        itemAudio.clip = itemSound;
        itemAudio.loop = false;

        GameObject dashCoolTimeObj = GameObject.Find("DashCoolTime");
        this.dashCoolTimeText = dashCoolTimeObj.GetComponent<Text>();
        dashCoolTime = 0;

        GameObject playerHealthObj = GameObject.Find("Health");
        this.playerHealthText = playerHealthObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newVec;
        //Move Player forward
        if (Input.GetKey(KeyCode.W))
        {
            newVec = Vector3.forward;
            //Dash
            if (Input.GetMouseButtonDown(1) && isDashed == false)
            {
                dashAudio.Play();
                Dash(newVec);
                isDashed = true;
                dashCoolTime = 3.0f;
            }
            else
                transform.Translate(newVec * speed * Time.deltaTime);
        }
        //Move Player left
        if (Input.GetKey(KeyCode.A))
        {
            newVec = Vector3.left;
            //Dash
            if (Input.GetMouseButtonDown(1) && isDashed == false)
            {
                dashAudio.Play();
                Dash(newVec);
                isDashed = true;
                dashCoolTime = 3.0f;
            }
            else
                transform.Translate(newVec * speed * Time.deltaTime);
        }
        //Move Player back
        if (Input.GetKey(KeyCode.S))
        {
            newVec = Vector3.back;
            //Dash
            if (Input.GetMouseButtonDown(1) && isDashed == false)
            {
                dashAudio.Play();
                Dash(newVec);
                isDashed = true;
                dashCoolTime = 3.0f;
            }
            else
                transform.Translate(newVec * speed * Time.deltaTime);
        }
        //Move Player right
        if (Input.GetKey(KeyCode.D))
        {
            newVec = Vector3.right;
            //Dash
            if (Input.GetMouseButtonDown(1) && isDashed == false)
            {
                dashAudio.Play();
                Dash(newVec);
                isDashed = true;
                dashCoolTime = 3.0f;
            }
            else
                transform.Translate(newVec * speed * Time.deltaTime);
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Avoid multiple jumps
            if (isJumping == false)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
                jumpAudio.Play();
                isJumping = true;
            }
            
        }

        //Set DashCoolTime
        if(dashCoolTime > 0)
        {
            dashCoolTime -= Time.deltaTime;
            if (dashCoolTime <= 0)
            {
                isDashed = false;
                dashCoolTime = 0;
            }
                
        }
        //Set dash cool time text
        this.dashCoolTimeText.text = "Dash Cool Time: " + (dashCoolTime).ToString();

        //Set Player's health text
        this.playerHealthText.text = "Health: " + playerHealth.ToString();

        //Game over if the player leaves the map
        if (transform.position.y < -2)
            SceneManager.LoadScene("Fail");
    }
    
    //Dash method
    void Dash(Vector3 newVec)
    {
        transform.Translate(newVec * dashPower * Time.deltaTime);

        //Prevent players from going off the map
        if (transform.position.x < -9)
            transform.position = new Vector3(-9, transform.position.y, transform.position.z);
        else if(transform.position.x > 9)
            transform.position = new Vector3(9, transform.position.y, transform.position.z);
    }

    void OnCollisionEnter(Collision coll)
    {
        
        if (coll.collider.tag == "GROUND")
        {
            isJumping = false;
        }

        if(coll.collider.tag == "OBSTACLE")
        {
            damageAudio.Play();
            playerHealth -= 10;
            Destroy(coll.gameObject, 0.0f);
            if (playerHealth <= 0)
                SceneManager.LoadScene("Fail");
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        
        if (coll.gameObject.tag == "ITEM")
        {
            itemAudio.Play();
            playerHealth += 1;
            Destroy(coll.gameObject, 0.0f);   
        }

        if(coll.gameObject.tag == "ENEMY")
        {
            damageAudio.Play();
            playerHealth -= 10;
            Destroy(coll.gameObject, 0.0f);
            if (playerHealth <= 0)
                SceneManager.LoadScene("Fail");
        }
    }
}
