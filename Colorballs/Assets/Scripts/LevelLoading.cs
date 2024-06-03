using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoading : MonoBehaviour
{
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void NextLevel()
    {
        int _sceneCount = SceneManager.sceneCountInBuildSettings;
        int levelNumber = SceneManager.GetActiveScene().buildIndex;
        levelNumber++;
        if (levelNumber >= _sceneCount)
        {
            SceneManager.LoadScene(1);
        }
        else
            SceneManager.LoadScene(levelNumber);
    }
    public void LoadingLevelByNumber(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
