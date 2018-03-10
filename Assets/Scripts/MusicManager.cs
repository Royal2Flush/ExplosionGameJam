using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip music;
    public AudioClip finishSound;
    
	void Start () {
        DontDestroyOnLoad(gameObject);
        audioSource.clip = music;
        audioSource.loop = true;
        audioSource.Play();
	}

    public void PlayFinishSound() {
        audioSource.Stop();
        audioSource.clip = finishSound;
        audioSource.loop = false;
        audioSource.Play();
        StartCoroutine(ResumeMusic());
    }

    IEnumerator ResumeMusic() {
        yield return new WaitForSeconds(finishSound.length + 0.5f);
        audioSource.clip = music;
        audioSource.loop = true;
        audioSource.Play();
    }
}
