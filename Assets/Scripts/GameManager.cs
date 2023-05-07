using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }

    }
    private GuiManager _guiManager;
    public GuiManager GuiManager
    {
        get
        {
            if (_guiManager == null)
                _guiManager = FindObjectOfType<GuiManager>();

            return _guiManager;
        }
    }
    private LevelManager _levelManager;
    public LevelManager LevelManager
    {
        get
        {
            if (_levelManager == null)
                _levelManager = FindObjectOfType<LevelManager>();

            return _levelManager;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
    }

    // Values +++++++++++++++++++++++++++++
    private int _nDual;
    //-------------------------------------
    

    public void LoadScene()
    {
        if (SceneManager.GetSceneByBuildIndex(1).isLoaded)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(1));
            SceneManager.LoadScene(1 , LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene(1 , LoadSceneMode.Additive);
        }
        
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
    }

}
