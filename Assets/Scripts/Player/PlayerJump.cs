using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerJump : MonoBehaviour
{
    private List<RaycastResult> _raycastResults = new List<RaycastResult>();

    private PlayerMovement _movement;
    private Animator _animator;

    private float _doubleTapTime = 0.5f;
    private float _elapsedTime = 0f;

    private int _tapCounter = 0;

    private bool _isJumping = false;

    public bool IsJumping => _isJumping;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _movement.Landed += OnPlayerLanded;
    }

    private void OnDisable()
    {
        _movement.Landed -= OnPlayerLanded;
    }

    private void Update()
    {
        if (_elapsedTime >= _doubleTapTime)
        {
            _elapsedTime = 0;
            _tapCounter = 0;
        }

        if (_tapCounter == 1)
        {
            _elapsedTime += Time.deltaTime;
        }

        if (_tapCounter == 2)
        {
            _tapCounter = 0;
            _elapsedTime = 0;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GetInput();
            CheckInput();
        }
    }

    private void GetInput()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        EventSystem.current.RaycastAll(pointerEventData, _raycastResults);
    }

    private void CheckInput()
    {
        if (_isJumping)
        {
            return;
        }

        for (int i = 0; i < _raycastResults.Count; i++)
        {
            if (_raycastResults[i].gameObject.TryGetComponent<FixedJoystick>(out FixedJoystick fixedJoystick))
            {
                _tapCounter++;

                if (_tapCounter == 2 && _elapsedTime <= _doubleTapTime)
                {
                    _movement.DisableMovement();

                    _animator.SetTrigger("Jump");

                    _isJumping = true;
                }
            }
        }

        _raycastResults.Clear();
    }

    private void OnPlayerLanded()
    {
        _isJumping = false;
    }
}
