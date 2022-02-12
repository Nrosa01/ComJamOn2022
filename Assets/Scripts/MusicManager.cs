using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    //public AudioClip intro;
    public AudioClip music1;
    public AudioClip music2;
    //public AudioClip vsIA;
    AudioSource musica;
    public static MusicManager instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            musica = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else Destroy(gameObject);

    }


    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "Game Over":
                if (musica.clip != music1) //Si esta ejecutando el audio battle, se evita que se reinicie el audio
                {
                    musica.clip = music1;
                    musica.Stop();
                }
                break;
            case "Menu Inicio":
                {
                    if (musica.clip != music1) //Si esta ejecutando el audio battle, se evita que se reinicie el audio
                    {
                        musica.clip = music1;
                        musica.Play();
                    }
                    break;
                }
        }
    }
}
