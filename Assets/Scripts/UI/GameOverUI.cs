using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _roundTimeTMP;

    private void OnEnable()
    {
        var time = TimeSpan.FromSeconds(GameManager.Instance.RoundTime);
        var formattedTime = time.ToString(@"hh\:mm\:ss");

        if (_roundTimeTMP != null)
            _roundTimeTMP.text = "ROUND TIME: " + formattedTime;
    }
}
