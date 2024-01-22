using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private bool _isAlive = false;
    [SerializeField] private Transform _bulletsSpawnPoint;
    [SerializeField] private GameObject _bulletPrefab;
    private LineRenderer _laser;

    public bool IsShot;

    private void Awake()
    {
        _laser = GetComponentInChildren<LineRenderer>();
    }

    private void Update()
    {

    }

    public async UniTask ShootToPlayer()
    {
        var newBullet = Instantiate(_bulletPrefab, _bulletsSpawnPoint.position + Vector3.up, Quaternion.identity);
        await UniTask.Delay(TimeSpan.FromSeconds(0.5f));

        IsShot = true;
    }
}
