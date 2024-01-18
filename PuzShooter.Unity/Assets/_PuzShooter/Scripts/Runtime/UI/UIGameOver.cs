using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private Animator _gameOverAnimator;
    private PlayerHealth _health;

    private void Start()
    {
        _health = FindObjectOfType<PlayerHealth>();
        _health.OnDead += SetActive;

        gameObject.SetActive(false);
    }

    private void SetActive()
    {
        gameObject.SetActive(true);
    }

}
