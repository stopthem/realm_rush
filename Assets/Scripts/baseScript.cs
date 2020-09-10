using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class baseScript : MonoBehaviour
{
    [SerializeField]int baseHealth=10;
    [SerializeField]Text healthText;
    [SerializeField]AudioClip enemyExplosionSFX;
    
    void Start() {
    healthText.text="Merkezin kalan cani: "+baseHealth.ToString();
    }
    private void OnTriggerEnter(Collider other) {
        baseHealth--;
        healthText.text="Merkezin kalan cani: "+baseHealth.ToString();
        GetComponent<AudioSource>().PlayOneShot(enemyExplosionSFX);
    }

}
