using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] Text pointsText;
    [SerializeField] Text counterText;
    [SerializeField] Text pointsTitleText;
    [SerializeField] bool autoPlay = false;

    public int pointsCounter;

    private void Awake()
    {
        int gameManagerCounter = FindObjectsOfType<GameSession>().Length;
        if (gameManagerCounter > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        pointsCounter = 0;
    }

    public void RestartGameStatus()
    {
        pointsCounter = 0;
        pointsText.text = "";
        counterText.text = "";
    }

    public void SetGameTextStatus(bool status)
    {
        pointsText.gameObject.SetActive(status);
        pointsTitleText.gameObject.SetActive(status);
        counterText.gameObject.SetActive(status);
    }

    public Text GetPointsText() { return pointsText;  }

    public void SetPointsText(string text) { pointsText.text = text; }

    public Text GetCounterText() { return counterText; }

    public void SetCounterText(string text) { counterText.text = text; }

    public bool IsAutoplayEnabled() { return autoPlay; }
}
