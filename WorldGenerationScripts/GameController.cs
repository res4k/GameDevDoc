using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{   
    public static GameController instance = null;
    public BoardCreator boardCreator;
    public int playerHealth = 100;
    [HideInInspector]
    public int level = 1;

    void Awake()
    {        
        Debug.Log("Awake, Level " + level);
        //SceneManager.sceneLoaded += OnLevelChanged;
        if(instance == null){
            instance = this;
        }else if(instance != this){
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        boardCreator = GetComponent<BoardCreator>();
        InitGame(); 
    }

    public void InitGame()
    {
        boardCreator.SetupScene(level);
    }
}
