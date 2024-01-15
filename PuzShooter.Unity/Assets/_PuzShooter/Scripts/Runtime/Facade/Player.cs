using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField] private PlayerCharacteristics _characteristics;

    private Movement _movement;
    private Shooting _shooting;
    private Aiming _aiming;
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _movement = GetComponent<Movement>();
        _shooting = GetComponent<Shooting>();
        _aiming = GetComponent<Aiming>();
        _movement.Init(_characterController, _characteristics);

        PlayerFacade.Init(_characterController, _movement, _aiming, _shooting, _characteristics);
    }

    private void OnTriggerEnter(Collider other)
    {
    }
}
