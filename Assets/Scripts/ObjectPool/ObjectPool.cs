using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    
    private List<GameObject> _objects;

    protected void Initialize(GameObject prefab)
    {
        _objects = new List<GameObject>();

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            _objects.Add(spawned);

            spawned.SetActive(false);
        }
    }

    public bool TryGetObject(out GameObject result)
    {
        result = _objects.FirstOrDefault(prefab => prefab.activeSelf == false);

        return result != null;
    }
}