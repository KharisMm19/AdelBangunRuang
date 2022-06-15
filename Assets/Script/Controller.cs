using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    static int _lastSceneIndex;

    public GameObject ObjectToSpawn;
    private GameObject _spawnedObject;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Stage1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SceneAR()
    {
        _lastSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("ARscene");
    }

    public void BackLastScene()
    {
        SceneManager.LoadScene(_lastSceneIndex);
    }

    public void spawnObject()
    {
        _spawnedObject = Instantiate(ObjectToSpawn);
    }
}
