using System;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform _bulletsSpawnPoint;
    [SerializeField] private GameObject _bullet;

    [SerializeField] private int _ammo;
    private Controls _controls;

    public int Ammo { get { return _ammo; } }
    public Action OnShoot;

    private void OnEnable()
    {
        _controls.Enable();

        _controls.Gameplay.Shoot.performed += ctx => Shoot(_bullet, _bulletsSpawnPoint);
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void Awake()
    {
        _controls = new Controls();
    }


    public void Shoot(GameObject bullet, Transform bulletsSpawnPoint)
    {
        if (_ammo > 0)
        {
            var newBullet = Instantiate(bullet, bulletsSpawnPoint.position + Vector3.up / 2, Quaternion.identity);
            _ammo--;
            OnShoot.Invoke();
        }
    }

    public void ResetAmmo(int amount)
    {
        _ammo = amount;
    }
}
