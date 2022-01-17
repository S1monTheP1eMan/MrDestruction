using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartButton : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private ProgressBar _progressBar;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnStartButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        _joystick.gameObject.SetActive(true);
        _progressBar.gameObject.SetActive(true);

        gameObject.SetActive(false);
    }
}
