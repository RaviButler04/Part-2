using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    //reference rigidbody
    Rigidbody2D rigidbody;

    //set speed
    public float speed = 2000f;

    // Start is called before the first frame update
    void Start()
    {
        //get rigid body component
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //give the ball forward velocity
        rigidbody.velocity = transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //destroy self when colliding
        Destroy(gameObject);
    }
}
