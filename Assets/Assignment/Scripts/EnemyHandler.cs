using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    //create timer to spawn enemies
    float timer = 0;

    //get enemy game object
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.5)
        {
            Instantiate(enemy);
            timer = 0;
        }
    }
}
