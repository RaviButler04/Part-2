using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    //create timer to spawn enemies
    float timer = 0;

    //reference game object
    public GameObject enemy;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.5)
        {
            //create enemy every 0.5 seconds
            Instantiate(enemy);

            //reset timer
            timer = 0;
        }
    }
}
