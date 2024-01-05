using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform _spawnPointBullet;
    [SerializeField] private GameObject _bullet;
    private Controls _controls;

    private void OnEnable()
    {
        _controls.Enable();

        _controls.Gameplay.Shoot.performed += ctx => Shoot();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void Awake()
    {
        _controls = new Controls();
    }


    private void Shoot()
    {
        var bullet = Instantiate(_bullet, _spawnPointBullet.position + Vector3.up, Quaternion.identity);
    }
}
