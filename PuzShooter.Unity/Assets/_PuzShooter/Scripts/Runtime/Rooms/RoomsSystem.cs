using System;
using System.Collections.Generic;
using UnityEngine;

public class RoomsSystem : MonoBehaviour
{
    [SerializeField] private Room _currentRoom;
    [SerializeField] private Room _endRoom;
    [SerializeField] private List<Room> _rooms = new List<Room>();
    [SerializeField] private List<Door> _doors = new List<Door>();

    private bool _isLevelComplete;

    public bool IsLevelComplete { get {  return _isLevelComplete; } }

    public Action OnLevelComplete;


    private void OnEnable()
    {
        OnLevelComplete += CompleteLevel;
    }

    private void Start()
    {
        InitRooms();
        InitDoors();
    }

    private void InitDoors()
    {
        Door[] doors = FindObjectsOfType<Door>();

        _doors.Clear();
        _doors.AddRange(doors);
        _doors.ForEach(door => { door.OnRoomEnter += SetCurrentRoom; door.OnDoorEnter += BlockDoors; });
    }

    private void InitRooms()
    {
        Room[] rooms = FindObjectsOfType<Room>();
        _rooms.Clear();
        _rooms.AddRange(rooms);
        _rooms.ForEach(room => { room.OnRoomClear += OpenDoors; room.OnRoomClear += CheckAllRoomsClear; });
    }

    private void BlockDoors()
    {
        _doors.ForEach(door =>
        {
            if (!door.ItsRoom.IsClear)
            {
                door.GetComponent<MeshRenderer>().enabled = true;
                door.GetComponent<BoxCollider>().isTrigger = false;
            }
        });
    }

    private void OpenDoors()
    {
        _doors.ForEach(door =>
        {
            if (!door.ItsRoom.IsClear)
            {
                door.GetComponent<MeshRenderer>().enabled = false;
                door.GetComponent<BoxCollider>().isTrigger = true;
            }
        });
    }

    private void SetCurrentRoom(Room room)
    {
        _currentRoom = room;
    }

    private void CheckAllRoomsClear()
    {
        foreach (Room room in _rooms)
        {
            if (!room.IsClear)
            {
                _isLevelComplete = false;
                return;
            }
        }

        OnLevelComplete?.Invoke();
    }

    private void CompleteLevel()
    {
        Debug.Log("Level Complete");
        _isLevelComplete = true;
    }
}
