using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CampaignManager : MonoBehaviour
{
    private const int firstSceneIndex = 0;
    
    public static CampaignManager instance { get; private set; }

    void Start()
    {
        if(instance) { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    public void LoadNextLevel()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevel(int levelIndex)
    {
        if (levelIndex < firstSceneIndex)
        {
            Debug.LogWarning("Loading a scene that has smaller index than the first scene!");
        }
        
        SceneManager.LoadScene(levelIndex);
    }

	public void ReloadLevel () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}

