using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonHealth : MonoBehaviour
{
    //reference slider component
    public Slider slider;

    public void TakeDamage(float damage)
    {
        //decrease slider value
        slider.value -= damage;
    }
}
