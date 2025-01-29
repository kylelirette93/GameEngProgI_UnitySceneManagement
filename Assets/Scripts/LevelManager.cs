using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    string _spawnPoint;
    Transform player;

    private void Awake()
    {
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
        _spawnPoint = spawnPoint;
        SceneManager.sceneLoaded += OnSceneLoaded;  // Listen for scene load
        SceneManager.LoadScene(sceneName);  // Load the scene
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.Find("Player").transform;
        // Find the spawn point object based on the name passed in
        Transform spawn = GameObject.Find(_spawnPoint).transform;

        // Move the player to the spawn point
        player.position = spawn.position;

        // Remove the listener to avoid duplicate calls
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
