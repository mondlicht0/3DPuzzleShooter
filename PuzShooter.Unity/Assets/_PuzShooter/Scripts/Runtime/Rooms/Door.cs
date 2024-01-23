using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    private BoxCollider _collider;
    private MeshRenderer _mesh;
    private Room _itsRoom;
    public Action OnDoorEnter;
    public Action<Room> OnRoomEnter;
    public Action<int> OnPlayerEnter;

    public Room ItsRoom {  get { return _itsRoom; } }

    private void Awake()
    {
        _itsRoom = GetComponentInParent<Room>();
        _collider = GetComponent<BoxCollider>();
        _mesh = GetComponent<MeshRenderer>();

        _itsRoom.OnRoomClear += ClearTrigger;
    }

    private void OnTriggerEnter(Collider other)
    {
        OnDoorEnter?.Invoke();
        OnRoomEnter?.Invoke(_itsRoom);
        OnPlayerEnter?.Invoke(_itsRoom.AmmoGainCount);
    }

    private void ClearTrigger()
    {
        _collider.enabled = false;
        _mesh.enabled = false;
    }
}
