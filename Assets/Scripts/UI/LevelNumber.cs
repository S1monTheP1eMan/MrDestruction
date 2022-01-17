using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class LevelNumber : MonoBehaviour
{
    private TMP_Text _counter;

    private void Awake()
    {
        _counter = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        int number = SceneController.Instance.GetSceneCount();
        Debug.Log(number);
        _counter.text = number.ToString();

    }

}
