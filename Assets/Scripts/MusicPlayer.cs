using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    [SerializeField]AudioClip music;
    [SerializeField]float volume=0.10f;
    AudioSource audioSource;
    private void Awake()
    {
       AudioSource.PlayClipAtPoint(music,Camera.main.transform.position,volume);
       
    }
}
