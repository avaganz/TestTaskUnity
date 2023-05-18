using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player _playerPrefab;

    [SerializeField]
    private Transform _spawnPoint;

    public static GameManager Instance { get; private set; }

    public float RoundTime { get; private set; }

    public Player CurrentPlayer { get; private set; }

    public void Restart()
    {
        RoundTime = 0f;

        if (CurrentPlayer)
            Destroy(CurrentPlayer.gameObject);

        SpawnPlayer();

        if (UIManager.Instance.IsGameOverUIVisible)
            UIManager.Instance.IsGameOverUIVisible = false;

        EnemyManager.Instance.Restart();
        MineManager.Instance.Restart();
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnPlayer();
    }

    private void Update()
    {
        RoundTime += Time.deltaTime;
    }

    private void OnPlayerDied()
    {
        UIManager.Instance.IsGameOverUIVisible = true;
    }

    private void SpawnPlayer()
    {
        if (_spawnPoint)
            CurrentPlayer = Instantiate(_playerPrefab, _spawnPoint.position, _spawnPoint.rotation);
        else
            CurrentPlayer = Instantiate(_playerPrefab);

        if (CurrentPlayer)
            CurrentPlayer.Died += OnPlayerDied;
    }
}
