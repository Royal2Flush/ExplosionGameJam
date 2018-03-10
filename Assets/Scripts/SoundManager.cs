using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip[] wallHits;
    public AudioClip[] explosions;

    public void HitWall() {
        audioSource.Stop();
        AudioClip clip = wallHits[Random.Range(0, wallHits.Length)];

        audioSource.clip = clip;
        audioSource.Play();
    }

    public void Explosion() {
        audioSource.Stop();
        AudioClip clip = explosions[Random.Range(0, explosions.Length)];

        audioSource.clip = clip;
        audioSource.Play();
    }
}
