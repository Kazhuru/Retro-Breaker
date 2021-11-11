using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paddle : MonoBehaviour
{
    private float minX, maxX;
    private float screenWidthInUnits, screenHeightInUnits;

    private GameSession gameStatus;
    private Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        CanvasScaler canvasScaler = GameObject.Find("Game Canvas").GetComponent<CanvasScaler>();
        float screenRatio = canvasScaler.referenceResolution.x / canvasScaler.referenceResolution.y;
        
        screenHeightInUnits = 2f * Camera.main.orthographicSize;
        screenWidthInUnits = screenHeightInUnits * screenRatio;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float paddleSizeDiff = spriteRenderer.bounds.size.x / 2f;

        minX = paddleSizeDiff;
        maxX = screenWidthInUnits - paddleSizeDiff;

        gameStatus = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 nextPosition = new Vector2(transform.position.x, transform.position.y);
        nextPosition.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = nextPosition;
    }

    private float GetXPos()
    {
        if (gameStatus.IsAutoplayEnabled())
            return ball.transform.position.x;
        else
            return Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
    }
}
