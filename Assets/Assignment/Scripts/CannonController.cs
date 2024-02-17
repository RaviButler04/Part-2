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
        }
    
    }

    private void FixedUpdate()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        rigidbody.rotation = -angle;
    }
        
}
