using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    // Reference to the player and the spawn point
    Transform player;
    string _spawnPoint;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void ChangeScene(string sceneName, string spawnPoint)
    {
        // Set spawn point to the one passed in by trigger.
        _spawnPoint = spawnPoint;
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded; 
        // Begin loading the scene.
        SceneManager.LoadScene(sceneName);  
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find the player object.
        player = GameObject.Find("Player").transform;

        // Find the spawn point object based on the name passed in
        Transform spawn = GameObject.Find(_spawnPoint).transform;

        // Move the player to the spawn point.
        player.position = spawn.position;

        // Remove the listener to avoid duplicate calls.
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
