using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsPool : ObjectPool
{
    [SerializeField] private ParticleSystem _effect;

    private void Awake()
    {
        Initialize(_effect.gameObject);
    }

    public void SpawnEffect(Transform objectPosition)
    {
        if (TryGetObject(out GameObject effect))
        {
            effect.SetActive(true);
            effect.transform.position = objectPosition.position;
        }
    }
}
