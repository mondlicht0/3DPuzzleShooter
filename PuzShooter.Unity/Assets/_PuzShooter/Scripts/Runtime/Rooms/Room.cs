using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    # region FIELDS
    [SerializeField] private List<Enemy> _enemyList = new List<Enemy>();
    [SerializeField] private Door _door;
    [SerializeField] private float _ammoGainCount;

    private BoxCollider _boxCollider;
    private bool _isClear;
    #endregion

    #region PROPERTIES
    public bool IsClear { get { return _isClear; } }
    #endregion

    public Action OnRoomClear;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        InitEnemies();

        _enemyList.ForEach(enemy => { enemy.OnDead += CheckAliveEnemies; });

        _door = GetComponentInChildren<Door>();

        _door.OnDoorEnter += SetEnemiesActive;

        SetEnemiesUnActive();
    }

    private void SetEnemiesActive()
    {
        if (_enemyList != null)
        {
            foreach (Enemy enemy in _enemyList)
            {
                enemy.gameObject.SetActive(true);
            }
        }
    }
    private void SetEnemiesUnActive()
    {
        if (_enemyList != null)
        {
            foreach (Enemy enemy in _enemyList)
            {
                enemy.gameObject.SetActive(false);
            }
        }
    }

    private void CheckAliveEnemies()
    {
        InitEnemies();
        Debug.Log("KIll");
        if (_enemyList.Count <= 1)
        {
            Debug.Log("Lol");
            OnRoomClear?.Invoke();
        }
    }

    private void InitEnemies()
    {
        Enemy[] enemies = transform.GetComponentsInChildren<Enemy>();
        _enemyList.Clear();
        _enemyList.AddRange(enemies);
    }

}
