using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIAmmoDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ammoText;

    private List<Door> _doors = new List<Door>();

    private void Start()
    {
        PlayerFacade.Shooting.OnShoot += UpdateAmmoText;
        InitDoors();
    }

    private void InitDoors()
    {
        Door[] doors = FindObjectsOfType<Door>();

        _doors.Clear();
        _doors.AddRange(doors);
        _doors.ForEach(door => { door.OnPlayerEnter += UpdateAmmoText; });
    }

    private void UpdateAmmoText()
    {
        _ammoText.text = $"{PlayerFacade.Shooting.Ammo}";
    }

    private void UpdateAmmoText(int amount)
    {
        _ammoText.text = $"{amount}";
    }
}
