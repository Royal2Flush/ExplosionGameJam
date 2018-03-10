using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignManager : MonoBehaviour
{
    private const int firstSceneIndex = 1;

    public static CampaignManager s_instance;
    public static CampaignManager instance { get; private set; }
    private int currentLevelIndex;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        s_instance = this;

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
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelIndex);
    }
}

