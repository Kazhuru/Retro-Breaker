using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneLoader sceneLoader = GameObject.Find("Scene Loader").GetComponent<SceneLoader>();
        sceneLoader.LoadNextScene();
    }
}
