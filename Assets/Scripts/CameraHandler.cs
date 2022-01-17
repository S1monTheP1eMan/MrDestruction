using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CameraHandler : MonoBehaviour
{
    [SerializeField] private ExplosionWave _explosionWave;

    private Animator _animator;

    private const string CameraShake = "CameraShake";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _explosionWave.Created += OnWaveCreated;
    }

    private void OnDisable()
    {
        _explosionWave.Created -= OnWaveCreated;
    }

    private void OnWaveCreated()
    {
        _animator.Play(CameraShake);
    }
}
