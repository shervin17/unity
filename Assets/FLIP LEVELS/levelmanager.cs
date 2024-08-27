using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelmanager : MonoBehaviour
{
    public LevelButton[] levelButtons;

    private void Awake()
    {
        int unlockedlevel = PlayerPrefs.GetInt("Unlockedlevel", 1);
        Debug.Log("Initial unlockedlevel: " + unlockedlevel);

        // Ensure unlockedlevel is within the bounds of the buttons array
        unlockedlevel = Mathf.Clamp(unlockedlevel, 0, levelButtons.Length);
        Debug.Log("Clamped unlockedlevel: " + unlockedlevel);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].button.interactable = false;
            Debug.Log("Button " + i + " interactable: " + levelButtons[i].button.interactable);
        }

        for (int i = 0; i < unlockedlevel; i++)
        {
            levelButtons[i].button.interactable = true;
            Debug.Log("Button " + i + " interactable: " + levelButtons[i].button.interactable);
        }
    }

    public void Openlevel(int levelID)
    {
        if (levelID >= 0 && levelID < levelButtons.Length)
        {
            string levelName = levelButtons[levelID].sceneName;
            Debug.Log("Loading level: " + levelName);
            SceneManager.LoadScene(levelName);
        }
        else
        {
            Debug.LogError("Invalid level ID: " + levelID);
        }
    }
}
