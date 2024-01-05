using UnityEngine;

public class Aiming : MonoBehaviour
{
    [SerializeField] private GameObject _body;
    [SerializeField] private GameObject _target;
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector3 _accuracyOffset;

    private Controls _controls;
    private Vector3 _lookDirection;
    public Vector3 _worldMousePosition;

    public Vector3 LookDirection { get { return _lookDirection; } }
    public Vector3 WorldMousePosition { get { return _worldMousePosition; } }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void Awake()
    {
        _controls = new Controls();
    }

    private void Update()
    {
        Aim();
    }

    private void Aim()
    {
        Vector3 mousePosition = _controls.Gameplay.Aim.ReadValue<Vector2>();

        _worldMousePosition = _camera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, _camera.transform.position.y));

        Ray ray = _camera.ScreenPointToRay(new Vector3(mousePosition.x, mousePosition.y, _camera.transform.position.y));

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            _worldMousePosition = new Vector3(hitInfo.point.x, 0, hitInfo.point.z);
        }

        _lookDirection = _worldMousePosition - transform.position;
        _lookDirection.y = 0;
        _worldMousePosition.y = 0;

        _body.transform.rotation = Quaternion.LookRotation(_lookDirection);
        _target.transform.position = _worldMousePosition;

        if (_lookDirection != Vector3.zero)
        {
        }
    }
}

