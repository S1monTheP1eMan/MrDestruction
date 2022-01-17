using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnvironmentObjectsContainer : MonoBehaviour
{
    [SerializeField] private EffectsPool _effects;

    private EnvironmentObject[] _objects;

    public int _destroyedObjects = 0;

    public event UnityAction<int, int> ObjectsChanged;

    private void Awake()
    {
        _objects = gameObject.GetComponentsInChildren<EnvironmentObject>();

        for (int i = 0; i < _objects.Length; i++)
        {
            _objects[i].Destroying += OnObjectDestroying;
        }
    }

    private void Start()
    {
        ObjectsChanged?.Invoke(_destroyedObjects, _objects.Length);
    }

    private void OnDisable()
    {
        for (int i = 0; i < _objects.Length; i++)
        {
            _objects[i].Destroying -= OnObjectDestroying;
        }
    }

    private void OnObjectDestroying(Transform transform)
    {
        _effects.SpawnEffect(transform);

        _destroyedObjects++;
        ObjectsChanged?.Invoke(_destroyedObjects, _objects.Length);
    }
}
