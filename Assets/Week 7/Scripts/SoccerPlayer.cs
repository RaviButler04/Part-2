using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerPlayer : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    //Color myColor = new Color(0, 0, 0);

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
            Selected(true);
    }

    public void Selected(bool isSelected)
    {
        if(isSelected) 
        {
            spriteRenderer.color = Color.white;
        }
        if (!isSelected)
        {
            spriteRenderer.color = Color.black;
        }
    }
}
