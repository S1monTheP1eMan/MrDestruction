using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshCollider))]
public class EnvironmentObject : MonoBehaviour
{
    private MeshCollider _collider;

    public event UnityAction<Transform> Destroying;

    private void Awake()
    {
        _collider = GetComponent<MeshCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Wave>(out Wave wave))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        Destroying?.Invoke(transform);
    }
}