using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    [SerializeField] private LineRenderer _laser;

    private void Start()
    {
        _laser.SetPosition(1, gameObject.transform.position);
        PlayerFacade.Shooting.OnShoot += TurnOffLaser;
    }

    private void Update()
    {
        if (PlayerFacade.PlayerController != null)
        {
            _laser.SetPosition(0, PlayerFacade.PlayerController.transform.position);
            Aim();
        }

    }

    private void TurnOffLaser()
    {
        if (_laser != null)
        {
            _laser.enabled = false;
        }
    }

    private void Aim()
    {
        Vector3 _lookDirection = PlayerFacade.PlayerController.transform.position - transform.position;
        _lookDirection.y = 0;

        transform.rotation = Quaternion.LookRotation(_lookDirection);

    }
}
