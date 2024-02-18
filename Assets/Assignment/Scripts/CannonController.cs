using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CannonController : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public GameObject cannonBall;
    public GameObject cannonLoc;
    float health = 5;
    Boolean isUpgraded = false;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Instantiate(cannonLoc, transform.position, transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(cannonBall, transform.position, transform.rotation);
            if (isUpgraded == true)
            {
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
            Destroy(gameObject);
        }
    
    }

    private void FixedUpdate()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        rigidbody.rotation = -angle;
    }

    public void takeDamage()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        health--;
        Destroy(collision.gameObject);
    }

    public void Upgrade()
    {
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
