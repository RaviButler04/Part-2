using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    //reference rigidbody2d
    Rigidbody2D rigidbody;

    //get cannon game object
    public GameObject cannon;

    //set enemy speed
    public float speed = 50f;

    //enemy health
    int health = 3;

    //reference animator
    Animator animator;

    //reference sprite renderer
    SpriteRenderer spriteRenderer;

    //bool for colour calcualations
    bool increasing = true;

    //timer for colour fluctuation
    float colorTimer = 0;

    //reference animation curve
    public AnimationCurve colors;


    // Start is called before the first frame update
    void Start()
    {
        //get all required components
        animator = GetComponent<Animator>();
        rigidbody= GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Vector3 originalScale = transform.localScale;

        //pick spawn area
        int spawnArea = Random.Range(0, 4);
        int spawnx = 0;
        int spawny = 0;


        //randomize spawn positions
        if (spawnArea == 0)
        {
            spawnx = Random.Range(-11, 12);
            spawny = -6;
        }
        if (spawnArea == 1)
        {
            spawnx = Random.Range(-11, 12);
            spawny = 6;
        }
        if (spawnArea == 2)
        {
            spawnx = -11;
            spawny = Random.Range(-6, 7);
        }
        if (spawnArea == 3)
        {
            spawnx = 11;
            spawny = Random.Range(-6, 7);
        }

        //set spawn position
        transform.position = new Vector3(spawnx, spawny, 0);

    }

    // Update is called once per frame
    void Update()
    {
        //alternate bool between true and false based on timer
        if(colorTimer == 0 * Time.deltaTime)
        {
            increasing = true;
        }
        else if (colorTimer == 10 * Time.deltaTime)
        {
            increasing = false;
        }

        //change colour based on bool
        if(increasing == true) 
        {
            colorTimer += 0.1f * Time.deltaTime;
        }
        else if (increasing == false)
        {
            colorTimer -= 0.1f * Time.deltaTime;
        }

        //interpolate colour based on timer
        float interpolation = colors.Evaluate(colorTimer);

        //set sprite colour
        spriteRenderer.color = Color.Lerp(Color.blue, Color.red, interpolation);

        if (health == 0)
        {
            //set dead animation trigger
            animator.SetTrigger("isDead");

            //destroy game object after death animation is played
            float length = animator.GetCurrentAnimatorStateInfo(0).length;
            Destroy(gameObject, length);
        }
    }

    private void FixedUpdate()
    {
        //create vector 2 for direction to the cannon
        Vector2 direction = (Vector2)cannon.transform.position - (Vector2)transform.position;

        //get thte angle between current position and cannon position
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        //set the rotation equal to the neccessary angle
        rigidbody.rotation = -angle;

        //give the object forward velocity
        rigidbody.velocity = transform.up * speed * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //decrease health
        health --;

        if(health > 0)
        {
            //set hurt animation trigger
            animator.SetTrigger("isHurt");
        }
    }
}
