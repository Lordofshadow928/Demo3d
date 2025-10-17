using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private bool isLockedValue;
    public bool isLocked
    {
        get => isLockedValue;
        set
        {
            isLockedValue = value;
            enabled = !isLockedValue;
        }
    }
}
