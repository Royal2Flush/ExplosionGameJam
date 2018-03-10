using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    public static MusicManager instance;

    public AudioSource audioSource;
    public AudioClip music;
    public AudioClip finishSound;
    
	void Start () {
        if(instance) { Destroy(gameObject); }
        instance = this;
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
        CampaignManager.s_instance.LoadNextLevel();
        audioSource.clip = music;
        audioSource.loop = true;
        audioSource.Play();
    }
}
