using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CampaignManager : MonoBehaviour
{
    private const int firstSceneIndex = 1;
    
    public static CampaignManager instance { get; private set; }
    private int currentLevelIndex;

    void Start()
    {
        if(instance) { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);
        instance = this;

        currentLevelIndex = firstSceneIndex;
    }

    public void LoadNextLevel()
    {
        LoadLevel(currentLevelIndex + 1);
    }

    public void LoadLevel(int levelIndex)
    {
        if (levelIndex < firstSceneIndex)
        {
            Debug.LogWarning("Loading a scene that has smaller index than the first scene!");
        }

        currentLevelIndex = levelIndex;
        SceneManager.LoadScene(levelIndex);
    }

	public void ReloadLevel () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}

