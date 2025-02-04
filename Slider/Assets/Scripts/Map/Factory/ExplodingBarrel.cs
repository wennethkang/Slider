using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExplodingBarrel : MonoBehaviour
{
    private readonly string explosionResName = "SmokePoof Variant";

    [SerializeField] private Transform[] explosionLocations;
    [SerializeField] private ParticleSystem[] fuseParticles;
    [SerializeField] private ExplodableRock explodableRock;

    public UnityEvent OnExplode;

    private GameObject explosionEffect;

    private void Start()
    {
        if (explodableRock.isExploded)
        {
            DestroyBarrels();
        }

        explosionEffect = ParticleManager.GetPrefab(ParticleType.SmokePoof);
    }

    public void Explode()
    {
        StartCoroutine(ExplodeRoutine());
    }

    private IEnumerator ExplodeRoutine()
    {
        CameraShake.ShakeConstant(2, 0.1f);
        foreach (ParticleSystem ps in fuseParticles)
        {
            ps.Play();
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(2.0f);

        foreach (ParticleSystem ps in fuseParticles)
        {
            ps.Stop();
        }

        foreach (Transform location in explosionLocations)
        {
            Instantiate(explosionEffect, location.position, Quaternion.identity);
        }

        DestroyBarrels();

        OnExplode?.Invoke();
    }

    private void DestroyBarrels()
    {
        foreach (Transform location in explosionLocations)
        {
            Destroy(location.gameObject);
        }
    }
}