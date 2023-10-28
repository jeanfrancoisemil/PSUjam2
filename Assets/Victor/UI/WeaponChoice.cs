using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponChoice : MonoBehaviour
{
    public Image[] choices;
    public void Start()
    {
        choices = GetComponentsInChildren<Image>(true);
    }
    
}
