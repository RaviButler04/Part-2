using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerPlayer : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    //Color myColor = new Color(0, 0, 0);
    //bool clickedOn = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Selected(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //if (clickedOn)
        //{
        //    Selected(false);
        //}
        //else if (!clickedOn)
        //{
            Selected(true);
        //}
    }

    public void Selected(bool isSelected)
    {
        if(isSelected) 
        {
            spriteRenderer.color = Color.white;
            //clickedOn = true;
        }
        if (!isSelected)
        {
            spriteRenderer.color = Color.black;
            //clickedOn = false;
        }
    }
}
