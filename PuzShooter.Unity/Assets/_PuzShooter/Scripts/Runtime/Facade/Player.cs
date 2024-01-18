using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField] private PlayerCharacteristics _characteristics;

    private Movement _movement;
    private Shooting _shooting;
    private Aiming _aiming;
    private PlayerHealth _playerHealth;
    private CharacterController _characterController;

    private RoomsSystem _roomsSystem;
    private SceneLoader _sceneLoader;

    private void Awake()
    {
        InitComponents();

        _roomsSystem = FindObjectOfType<RoomsSystem>();
        _sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End") && _roomsSystem.IsLevelComplete)
        {
            _sceneLoader.LoadNextLevel();
        }
    }

    private void InitComponents()
    {
        _characterController = GetComponent<CharacterController>();
        _movement = GetComponent<Movement>();
        _shooting = GetComponent<Shooting>();
        _aiming = GetComponent<Aiming>();
        _playerHealth = GetComponent<PlayerHealth>();
        _movement.Init(_characterController, _characteristics);
        _playerHealth.OnDead += TurnOffPlayer;

        PlayerFacade.Init(_characterController, _movement, _aiming, _shooting, _playerHealth, _characteristics);
    }

    private void TurnOffPlayer()
    {
        _movement.enabled = false;
        _shooting.enabled = false;
        _aiming.enabled = false;
    }
}
