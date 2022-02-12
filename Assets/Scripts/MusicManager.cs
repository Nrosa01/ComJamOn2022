using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    public AudioClip music;
    public AudioClip finished;

    AudioSource musica;
    AudioSource sound_effects;

    public EffectsSoundsPlayer sndManager;

    public static MusicManager instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            musica = GetComponent<AudioSource>();
            sndManager = GetComponent<EffectsSoundsPlayer>();
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
                    sndManager.PlayClip(new PlaySoundSignal(Sounds.AQueSeJuega_V1));
                    //SignalBus<PlaySoundSignal>.Fire(new PlaySoundSignal(Sounds.AQueSeJuega));
                    musica.Stop();
                    //sound_effects.PlayOneShot(finished);
                
                break;
            case "Menu Inicio":
                {
                    if (musica.clip != music) //Si esta ejecutando el audio battle, se evita que se reinicie el audio
                    {
                        musica.clip = music;
                        musica.Play();
                    }
                    break;
                }
        }
    }
}
