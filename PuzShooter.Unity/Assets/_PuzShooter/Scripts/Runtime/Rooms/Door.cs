using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Action OnDoorEnter;

    private void OnTriggerEnter(Collider other)
    {
        OnDoorEnter?.Invoke();
    }
}
