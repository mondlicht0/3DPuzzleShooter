using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletCharacteristics _characteristics;

    private Rigidbody _bulletRigidbody;

    private Vector3 _lastVelocity;
    private Vector3 _direction;
    private float _currentSpeed;
    private int _currentBounces = 0;

    public BulletCharacteristics Characteristics { get { return _characteristics; } }

    private void Awake()
    {
        _bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        InitBullet(PlayerFacade.PlayerController.transform);
    }

    private void LateUpdate()
    {
        _lastVelocity = _bulletRigidbody.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_characteristics.IsBouncy)
        {
            Bounce(collision);

            return;
        }

        Destroy(gameObject);
    }

    private void InitBullet(Transform player = null)
    {
        if (_characteristics.IsPlayersBullet)
        {
            _bulletRigidbody.velocity = (PlayerFacade.Aiming.WorldMousePosition - transform.position).normalized * _characteristics.Speed;
        }

        else
        {
            _bulletRigidbody.velocity = (player.position - transform.position).normalized * _characteristics.Speed;
        }
    }

    private void Bounce(Collision collision)
    {
        if (_currentBounces >= _characteristics.MaxNumOfBounces) Destroy(gameObject);

        _currentSpeed = _lastVelocity.magnitude;
        _direction = Vector3.Reflect(_lastVelocity.normalized, new Vector3(collision.contacts[0].normal.x, 0, collision.contacts[0].normal.z));

        _bulletRigidbody.velocity = _direction * Mathf.Max(_currentSpeed, 1);
        _currentBounces++;
    }

/*    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }*/
}
