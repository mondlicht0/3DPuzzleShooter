using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private bool _isAlive = false;
    [SerializeField] private Transform _bulletsSpawnPoint;
    [SerializeField] private GameObject _bulletPrefab;

    private Player _player;
    private TurnSystem _turnSystem;

    private float _fireRate = 2f;
    private float _lastShootTime;

    public bool IsShot;

    public Action OnDead;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _turnSystem = FindObjectOfType<TurnSystem>();
    }

    private void Update()
    {
/*        if (Time.time > _fireRate + _lastShootTime && _turnSystem.IsEnemyTurn)
        {
            _lastShootTime = Time.time;

            ShootToPlayer();
        }*/
    }

    public void ShootToPlayer()
    {
        var newBullet = Instantiate(_bulletPrefab, _bulletsSpawnPoint.position + Vector3.up, Quaternion.identity);

        _turnSystem.PlayerTurn();

        IsShot = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == 6)
        {
            OnDead?.Invoke();

            gameObject.SetActive(false);
        }
    }
}
