using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class CannonController : MonoBehaviour
{
    //reference rigidody
    Rigidbody2D rigidbody;

    //reference cannonball game object
    public GameObject cannonBall;

    //reference cannon location game object
    public GameObject cannonLoc;

    //set player health
    float health = 5;

    //set boolean to check if cannon is upgraded
    Boolean isUpgraded = false;

    // Start is called before the first frame update
    void Start()
    {
        //get rigid body game object
        rigidbody = GetComponent<Rigidbody2D>();

        //create the cannon location for enemies to move towards
        Instantiate(cannonLoc, transform.position, transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //create cannon ball
            Instantiate(cannonBall, transform.position, transform.rotation);
            if (isUpgraded == true)
            {
                //if upgraded is true, create 3 more cannon balls angled in 90 degrees
                Quaternion rotationAngle = transform.rotation;
                Quaternion rotationLeft = rotationAngle *= Quaternion.Euler(Vector3.forward * 90);
                Quaternion rotationRight = rotationAngle *= Quaternion.Euler(Vector3.forward * 180);
                Quaternion rotationBack = rotationAngle *= Quaternion.Euler(Vector3.forward * 270);

                Instantiate(cannonBall, transform.position, rotationLeft);
                Instantiate(cannonBall, transform.position, rotationRight);
                Instantiate(cannonBall, transform.position, rotationBack);
            }
        }

        if (health == 0)
        {
            //move to game over screen if health is at 0
            int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = (CurrentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadScene(nextSceneIndex);
        }
    
    }

    private void FixedUpdate()
    {
        //create 2d vector for direction between the current position and the mouse position
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //create angle between position and mouse position
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        //rotate rigid body towards mouse
        rigidbody.rotation = -angle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //decrease health on collision
        health--;

        //destroy colliding enemy 
        Destroy(collision.gameObject);

        //send message to the health bar to take 1 damage
        SendMessage("TakeDamage", 1);
    }

    public void Upgrade()
    {
        //manage upgrade boolean
        if(isUpgraded == true)
        { 
            isUpgraded = false;
        }
        else if(isUpgraded == false)
        {
            isUpgraded = true;
        }
    }

}
