using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExplosionWave : MonoBehaviour
{
    [SerializeField] private SphereCollider _collider;
   
    private float _minRadius = 0.5f;
    private float _maxRadius = 3f;

    public event UnityAction Created;

    private void Awake()
    {
        ResetWave();
    }

    public void CreateWave()
    {
        _collider.radius = _maxRadius;

        Created?.Invoke();
    }

    public void ResetWave()
    {
        _collider.radius = _minRadius;
    }
}
