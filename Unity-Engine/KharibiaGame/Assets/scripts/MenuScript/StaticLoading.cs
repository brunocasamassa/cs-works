using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StaticLoading{
    public static string levelToLoad;

    public static void LoadLevel(string level)
    {
        levelToLoad = level;
        SceneManager.LoadScene("Loading");
    }
}
