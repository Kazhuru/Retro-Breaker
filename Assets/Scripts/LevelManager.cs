using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 2;


    private int blockCounter;
    private int totalBlocks;
    private SceneLoader sceneLoader;
    private GameSession gameStatus;


    void Start()
    {
        blockCounter = 0;
        totalBlocks = CountBreakableBlocks();
        sceneLoader = GameObject.Find("Scene Loader").GetComponent<SceneLoader>();
        gameStatus = FindObjectOfType<GameSession>();

        UpdateCounterText();
        UpdatePointsText();
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;

        if (blockCounter == totalBlocks)
        {
            sceneLoader.LoadNextScene();
        }
    }

    public void CountBreakBlock()
    {
        blockCounter++;
        gameStatus.pointsCounter += pointsPerBlock;

        UpdatePointsText();
        UpdateCounterText();
    }

    public void UpdateCounterText()
    {
        gameStatus.SetCounterText(blockCounter + " / " + totalBlocks);
    }

    public void UpdatePointsText()
    {
        gameStatus.SetPointsText(gameStatus.pointsCounter.ToString());
    }

    private int CountBreakableBlocks()
    {
        Block[] blocks = FindObjectsOfType<Block>();
        int counter = 0;
        foreach (Block block in blocks)
            if (block.tag == "Breakable")
                counter++;

        return counter;
    }
}