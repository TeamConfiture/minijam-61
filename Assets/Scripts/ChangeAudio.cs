using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudio : MonoBehaviour
{
    public AudioClip music;
    public float volume = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource source = GameManager.Instance.GetComponent<AudioSource>();
        source.clip = music;
        source.volume = volume;
        source.Play();
    }
}
