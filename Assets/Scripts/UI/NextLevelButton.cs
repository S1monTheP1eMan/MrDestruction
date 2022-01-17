using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class NextLevelButton : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _joystick.gameObject.SetActive(false);

        _button.onClick.AddListener(OnNextLevelButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnNextLevelButtonClick);
    }

    private void OnNextLevelButtonClick()
    {
        SceneController.Instance.SetCurrentSceneId(SceneManager.GetActiveScene().buildIndex);

        SceneController.Instance.LoadScene();
    }
}
