using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EscapeCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text counter;
    [SerializeField] private int maxEscape = 100;
    private int currentEscaped = 0;
    private void Start()
    {
        Enemy.ReachedEndPoint += OnReachedEndPoint; // subscribtion
        RefreshText();
    }
    private void OnDestroy()
    {
        Enemy.ReachedEndPoint -= OnReachedEndPoint; // unsubscribtion
        Func<string> action = () => 
        {
           return "string example";
        };
        action?.Invoke();
    }

    private void RefreshText()
    {
        counter.text = $"{currentEscaped}/{maxEscape}";
    }

    private void OnReachedEndPoint(Enemy sender)
    {
        currentEscaped++;
        RefreshText();
    }
}
