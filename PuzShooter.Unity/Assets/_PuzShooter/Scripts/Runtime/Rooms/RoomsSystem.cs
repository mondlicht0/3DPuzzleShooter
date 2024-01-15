using System.Collections.Generic;
using UnityEngine;

public class RoomsSystem : MonoBehaviour
{
    [SerializeField] private Room _currentRoom;
    [SerializeField] private List<Room> _rooms = new List<Room>();
    [SerializeField] private List<Door> _doors = new List<Door>();

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
        _rooms.ForEach(room => { room.OnRoomClear += OpenDoors; });
    }

    private void BlockDoors()
    {
        _doors.ForEach(door => { door.GetComponent<MeshRenderer>().enabled = true; door.GetComponent<BoxCollider>().isTrigger = false; });
    }

    private void OpenDoors()
    {
        _doors.ForEach(door => { door.GetComponent<MeshRenderer>().enabled = false; door.GetComponent<BoxCollider>().isTrigger = true; });
    }

    private void ClearTrigger()
    {

    }

    private void SetCurrentRoom(Room room)
    {
        _currentRoom = room;
    }
}
