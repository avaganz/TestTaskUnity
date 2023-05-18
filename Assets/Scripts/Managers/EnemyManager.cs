using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private Enemy _enemyPrefab;

    [SerializeField]
    private GameObject _playground;

    [SerializeField]
    private float _spawnTime = 10f;

    private float _timeout = 0f;

    private Vector2 _playGroundArea = Vector2.one;

    private List<Enemy> _enemies = new List<Enemy>();

    public static EnemyManager Instance { get; private set; }

    public void SpawnEnemy(Vector2 area)
    {
        if (_enemyPrefab)
        {
            var x = Random.Range(-area.x, area.x);
            var z = Random.Range(-area.y, area.y);

            var enemy = Instantiate(_enemyPrefab, new Vector3(x, 0f, z), Quaternion.identity, transform);
            enemy.HitTarget = GameManager.Instance.CurrentPlayer;

            _enemies.Add(enemy);
        }
    }

    public void Restart()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy != null)
                Destroy(enemy.gameObject);
        }

        _enemies.Clear();
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _timeout = _spawnTime;

        var playgroundCollider = _playground.GetComponent<Collider>();

        if (playgroundCollider)
            _playGroundArea = new Vector2(playgroundCollider.bounds.extents.x,
                                          playgroundCollider.bounds.extents.z);
    }

    private void Update()
    {
        if (_timeout > 0f)
        {
            _timeout -= Time.deltaTime;
        }
        else
        {
            _timeout = _spawnTime;

            SpawnEnemy(_playGroundArea);
        }
    }
}
