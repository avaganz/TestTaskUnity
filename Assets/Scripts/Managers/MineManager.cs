using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineManager : MonoBehaviour
{
    [SerializeField]
    private Mine _minePrefab;

    [SerializeField]
    private GameObject _playground;

    [SerializeField]
    private int _amount = 10;

    private List<Mine> _mines = new List<Mine>();

    public static MineManager Instance { get; private set; }

    public void Restart()
    {
        foreach (var mine in _mines)
        {
            if (mine != null)
                Destroy(mine.gameObject);
        }

        _mines.Clear();

        FillUpPlayground();
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        FillUpPlayground();
    }

    private void SpawnMine(Vector2 area)
    {
        if (_minePrefab)
        {            
            var x = Random.Range(-area.x, area.x);
            var z = Random.Range(-area.y, area.y);

            var mine = Instantiate(_minePrefab, new Vector3(x, 0f, z), Quaternion.identity, transform);

            _mines.Add(mine);
        }
    }

    private void FillUpPlayground()
    {
        var collider = _playground.GetComponent<Collider>();

        if (collider)
        {
            var area = new Vector2(collider.bounds.extents.x, collider.bounds.extents.z);

            for (int i = 0; i < _amount; i++)
                SpawnMine(area);
        }
    }
}
