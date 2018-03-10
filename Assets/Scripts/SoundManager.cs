using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip[] wallHits;

    public void HitWall() {
        AudioClip clip = wallHits[Random.Range(0, wallHits.Length)];

        audioSource.clip = clip;
        audioSource.Play();
    }
}
