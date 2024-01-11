using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Room _itsRoom;
    public Action OnDoorEnter;
    public Action<Room> OnRoomEnter;

    public Room ItsRoom {  get { return _itsRoom; } }

    private void Awake()
    {
        _itsRoom = GetComponentInParent<Room>();
    }

    private void OnTriggerEnter(Collider other)
    {
        OnDoorEnter?.Invoke();
        OnRoomEnter?.Invoke(_itsRoom);
    }
}
