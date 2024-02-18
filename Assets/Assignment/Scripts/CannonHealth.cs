using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonHealth : MonoBehaviour
{
    public Slider slider;

    public void TakeDamage(float damage)
    {
        slider.value -= damage;
    }
}
