using System;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{

    [SerializeField] private TMP_Text text;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        text.text = "Score: " + GameManager.gameManager.Score;
    }
}