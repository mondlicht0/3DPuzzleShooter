using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading;
using Cysharp.Threading.Tasks;

public class TurnSystem : MonoBehaviour
{
    private Shooting _playerShooting;
    private List<Enemy> _enemyList = new List<Enemy>();

    [SerializeField, Range(1f, 8f)]
    private float _playerTurnTime;
    private bool _isPlayerShot = false;
    private bool _isPlayerTurn = true;
    private bool _isEnemyTurn = false;

    public bool IsPlayerTurn { get { return _isPlayerTurn; } }
    public bool IsEnemyTurn { get { return _isEnemyTurn; } }

    private void Start()
    {
        PlayerFacade.Shooting.OnShoot += EnemyTurn;

        InitEnemies();
    }

    public void PlayerTurn()
    {
        Debug.Log("Player Turn");
    }

    private void EnemyTurn()
    {
        Debug.Log("ENemy Turn");

        _isEnemyTurn = true;

        InitEnemies();

        _enemyList.ForEach(enemy => { enemy.ShootToPlayer(); });

        CheckEnemyShots(_enemyList);
    }

    private void CheckEnemyShots(List<Enemy> _enemyList)
    {
        _enemyList.ForEach(enemy => { if (!enemy.IsShot) return; });

        _isEnemyTurn = false;
        PlayerTurn();
    }

    private void InitEnemies()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        _enemyList.Clear();
        _enemyList.AddRange(enemies);
    }
}
