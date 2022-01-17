using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private EnvironmentObjectsContainer _objects;
    [SerializeField] private PlayerMovement _player;

    [SerializeField] private TMP_Text _currentProgress;
    [SerializeField] private TMP_Text _fullProgress;

    [SerializeField] private NextLevelButton _nextLevelButton;

    private void OnEnable()
    {
        _objects.ObjectsChanged += OnObjectsChanged;
    }

    private void OnDisable()
    {
        _objects.ObjectsChanged -= OnObjectsChanged;
    }

    private void OnObjectsChanged(int current, int max)
    {
        _currentProgress.text = current.ToString();
        _fullProgress.text = max.ToString();

        if (current == max)
        {
            _player.DisableMovement();
            _nextLevelButton.gameObject.SetActive(true);
        }
    }
}
