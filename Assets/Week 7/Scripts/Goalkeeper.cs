using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalkeeper : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject goalPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, goalPosition.transform.position);
        Debug.Log(distance);
        float maxDistance = 2;

        //tried minus but then the goalkeeper was at the bottom of the screen. For some reason plus works
        Vector2 direction = (SoccerController.SelectedPlayer.transform.position + goalPosition.transform.position);

        float magnitude = direction.magnitude;
        //Debug.Log(magnitude);
        Vector2 normal = direction.normalized;

        rb.MovePosition(normal * magnitude / 2);
        //Vector2 targetPos = (normal * magnitude / 2);
        //Vector2 moving = Vector3.MoveTowards(rb.transform.position, targetPos, 4);
        //rb.transform.position += (Vector3)moving;

    }
}
