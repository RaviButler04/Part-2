using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public GameObject cannon;
    public float speed = 50f;
    int health = 3;
    Animator animator;
    SpriteRenderer spriteRenderer;
    bool increasing = true;
    float colorTimer = 0;

    public AnimationCurve colors;
    //public float hitTimer = 3;
    //bool isHit = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody= GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Vector3 originalScale = transform.localScale;

        int spawnArea = Random.Range(0, 4);
        int spawnx = 0;
        int spawny = 0;

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

        transform.position = new Vector3(spawnx, spawny, 0);

    }

    // Update is called once per frame
    void Update()
    {

        if(colorTimer == 0 * Time.deltaTime)
        {
            increasing = true;
        }
        else if (colorTimer == 10 * Time.deltaTime)
        {
            increasing = false;
        }

        if(increasing == true) 
        {
            colorTimer += 0.1f * Time.deltaTime;
        }
        else if (increasing == false)
        {
            colorTimer -= 0.1f * Time.deltaTime;
        }

        float interpolation = colors.Evaluate(colorTimer);

        spriteRenderer.color = Color.Lerp(Color.blue, Color.red, interpolation);

        if (health == 0)
        {
            animator.SetTrigger("isDead");
            float length = animator.GetCurrentAnimatorStateInfo(0).length;

            Destroy(gameObject, length);
        }
    }

    private void FixedUpdate()
    {
        //Vector2 direction = (Vector2)cannon.transform.position - (Vector2)transform.position;
        //rigidbody.MovePosition(rigidbody.position + direction * speed * Time.deltaTime);

        Vector2 direction = (Vector2)cannon.transform.position - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        rigidbody.rotation = -angle;

        rigidbody.velocity = transform.up * speed * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        health --;

        if(health > 0)
        {
            animator.SetTrigger("isHurt");
        }
        //SendMessage("takeDamage");
    }
}
