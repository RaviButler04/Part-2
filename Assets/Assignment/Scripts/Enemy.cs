using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public GameObject cannon;
    public float speed = 50f;
    int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody= GetComponent<Rigidbody2D>();

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
        if(health == 0)
        {
            Destroy(gameObject);
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
        //SendMessage("takeDamage");
    }

}
