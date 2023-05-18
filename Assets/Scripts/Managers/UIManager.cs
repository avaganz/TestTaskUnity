using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameOverUI _gameOverUI;

    public static UIManager Instance { get; private set; }

    public bool IsGameOverUIVisible
    {
        get => _gameOverUI.gameObject.activeSelf;
        set => _gameOverUI.gameObject.SetActive(value);
    }

    private void Awake()
    {
        Instance = this;
    }
}
