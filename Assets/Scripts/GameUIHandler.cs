using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIHandler : MonoBehaviour
{
    public static GameUIHandler singleton;
    
    [SerializeField] private TMP_Text _scoreText;
    private static int score;

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = new GameUIHandler();
            singleton._scoreText = _scoreText;
        }
        else
        {
            Debug.Log("Singleton already instantiated");
        }

    }
    
    public void SetScore(int addValue)
    {
        score += addValue;
        _scoreText.text = $"Score: {score}";
    }
}
