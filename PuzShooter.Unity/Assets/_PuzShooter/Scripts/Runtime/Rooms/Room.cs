using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private Door _door;
    private BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        _enemies = transform.GetComponentsInChildren<Enemy>();
        _door = GetComponentInChildren<Door>();

        _door.OnDoorEnter += SetEnemiesActive;

        SetEnemiesUnActive();
    }

    private void SetEnemiesActive()
    {
        if (_enemies != null)
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.gameObject.SetActive(true);
            }
        }
    }

    private void SetEnemiesUnActive()
    {
        if (_enemies != null)
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.gameObject.SetActive(false);
            }
        }
    }

}
