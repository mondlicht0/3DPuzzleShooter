using UnityEngine;

public class Player : MonoBehaviour, IHealth
{   
    [SerializeField] private PlayerCharacteristics _characteristics;

    private Movement _movement;
    private Shooting _shooting;
    private Aiming _aiming;
    private CharacterController _characterController;

    private RoomsSystem _roomsSystem;
    private SceneLoader _sceneLoader;

    public void DestroyUnit()
    {
        
    }

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _movement = GetComponent<Movement>();
        _shooting = GetComponent<Shooting>();
        _aiming = GetComponent<Aiming>();
        _movement.Init(_characterController, _characteristics);

        _roomsSystem = FindObjectOfType<RoomsSystem>();
        _sceneLoader = FindObjectOfType<SceneLoader>();

        PlayerFacade.Init(_characterController, _movement, _aiming, _shooting, _characteristics);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End") && _roomsSystem.IsLevelComplete)z   
        {
            _sceneLoader.LoadNextLevel();
        }
    }
}
