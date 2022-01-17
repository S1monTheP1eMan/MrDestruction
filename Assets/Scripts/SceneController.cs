using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; set; }

    private bool _isSequential = true;

    private int _currentScene = 0;

    private int _sceneCounter = 0;

    private void Awake()
    {
        Instance = this;
        _sceneCounter++;

        _currentScene = 1;
        SceneManager.LoadScene("Castle");
    }

    public void LoadScene()
    {
        if (_isSequential)
        {
            _currentScene++;
            _sceneCounter++;

            if (_currentScene == 3)
            {
                _isSequential = false;
            }

            SceneManager.LoadScene(_currentScene);

            return;
        }

        _sceneCounter++;

        SceneManager.LoadScene(GenerateRandomId());
    }

    public void SetCurrentSceneId(int sceneId)
    {
        _currentScene = sceneId;
    }

    private int GenerateRandomId()
    {
        List<int> numbers = new List<int>();

        for (int i = 1; i < 4; i++)
        {
            numbers.Add(i);
        }

        numbers.Remove(_currentScene);

        int randomId = Random.Range(0, 2);

        return numbers[randomId];
    }

    public int GetSceneCount()
    {
        return _sceneCounter;
    }
}
