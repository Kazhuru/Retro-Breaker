using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] private float musicVolume = 1f;

    private static MusicPlayer instance;
    public static MusicPlayer Instance { get { return instance; } }

    private AudioSource audioSource;

    private void Awake()
    {
        int musicThemeCounter = FindObjectsOfType<MusicPlayer>().Length;
        if (musicThemeCounter > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        audioSource.Play();
    }

    private void Update()
    {
        audioSource.volume = musicVolume;
    }
}
