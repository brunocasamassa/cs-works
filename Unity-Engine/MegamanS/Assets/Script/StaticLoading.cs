using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StaticLoading {
    public static string leveltoload;
    public static void LoadLevel(string level)
    {
        leveltoload = level;
        SceneManager.LoadScene("Loading");

    }
    
}
