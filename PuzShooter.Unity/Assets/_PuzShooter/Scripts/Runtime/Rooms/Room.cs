using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    # region FIELDS
    public RoomType RoomType;

    [SerializeField] private List<EnemyHealth> _enemyList = new List<EnemyHealth>();
    [SerializeField] private int _ammoGainCount;
    [SerializeField] private bool _isClear;

    private Door _door;
    private Shooting _playerShooting;
    private BoxCollider _boxCollider;
    #endregion

    #region PROPERTIES
    public bool IsClear { get { return _isClear; } }
    public int AmmoGainCount { get { return _ammoGainCount; } } 
    public Door ItsDoor { get { return _door; } }
    #endregion

    public Action OnRoomClear;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _playerShooting = FindObjectOfType<Shooting>();
        _door = GetComponentInChildren<Door>();

        _door.OnPlayerEnter += _playerShooting.ResetAmmo;
        _door.OnDoorEnter += SetEnemiesActive;
    }

    private void Start()
    {
        InitEnemies(true);

        _enemyList.ForEach(enemy => { enemy.OnDead += CheckAliveEnemies; });


        SetEnemiesUnActive();
    }

    private void SetEnemiesActive()
    {
        InitEnemies(true);
        if (_enemyList != null)
        {
            _enemyList.ForEach(enemy => { enemy.gameObject.SetActive(true); enemy.GetComponentInChildren<LineRenderer>().enabled = true; });
        }
    }
    private void SetEnemiesUnActive()
    {
        InitEnemies(true);
        if (_enemyList != null)
        {
            _enemyList.ForEach(enemy => { enemy.gameObject.SetActive(false); enemy.GetComponentInChildren<LineRenderer>().enabled = false; });
        }
    }

    private void CheckAliveEnemies()
    {
        InitEnemies(false);
        Debug.Log("KIll");
        if (_enemyList.Count <= 1)
        {
            Debug.Log("Lol");
            _isClear = true;
            OnRoomClear?.Invoke();
        }
    }


    private void InitEnemies(bool includeInActive)
    {
        EnemyHealth[] enemies = transform.GetComponentsInChildren<EnemyHealth>(includeInActive);
        _enemyList.Clear();
        _enemyList.AddRange(enemies);
    }

}

public enum RoomType
{
    Default,
    EndRoom
}
