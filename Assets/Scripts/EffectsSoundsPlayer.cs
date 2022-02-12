using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sounds { AhhCorrect, BotonYApuntes, OhhhIncorrect }

public class EffectsSoundsPlayer : MonoBehaviour
{
    private AudioSource audio;
    [SerializeField] AudioClip[] clips;

    private void PlayClip(PlaySoundSignal sound)
    {
        audio.PlayOneShot(clips[(int)sound.sound], 0.25f);
    }

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        SignalBus<PlaySoundSignal>.Subscribe(PlayClip);
    }

    private void OnDestroy()
    {
        SignalBus<PlaySoundSignal>.Unsubscribe(PlayClip);
    }
}
