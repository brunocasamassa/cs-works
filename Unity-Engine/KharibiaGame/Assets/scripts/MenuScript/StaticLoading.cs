using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StaticLoading{
    public static string levelToLoad;

    public static void LoadLevel(string level)
    {
        levelToLoad = level; //invoke in InternalLoading Script
		SceneManager.LoadScene("Loading");

    }
}
