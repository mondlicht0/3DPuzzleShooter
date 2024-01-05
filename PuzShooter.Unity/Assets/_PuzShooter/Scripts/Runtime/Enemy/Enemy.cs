using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private bool _isAlive = false;
    [SerializeField] private Transform _bulletsSpawnPoint;
    [SerializeField] private GameObject _bulletPrefab;

    private Player _player;

    private float _fireRate = 2f;
    private float _lastShootTime;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (Time.time > _fireRate + _lastShootTime)
        {
            _lastShootTime = Time.time;

            ShootToPlayer(_bulletPrefab, _bulletsSpawnPoint);
        }
    }

    public void ShootToPlayer(GameObject bullet, Transform bulletsSpawnPoint)
    {
        var newBullet = Instantiate(bullet, bulletsSpawnPoint.position + Vector3.up, Quaternion.identity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Bullet>().Characteristics.IsPlayersBullet)
        {
            Destroy(gameObject);
        }
    }
}
