using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CoinSpark : MonoBehaviour
{
    [SerializeField] private ParticleSystem sparkParticles;
    [SerializeField] private float duration = 0.4f;

    private void Start()
    {
        if (sparkParticles == null)
        {
            Debug.LogWarning("CoinSpark: ParticleSystem not assigned.");
            return;
        }

        sparkParticles.Stop();
    }

    /// <summary>
    /// Joue les particules, puis détruit le GameObject (la pièce) une fois terminé.
    /// </summary>
    public void PlayAndDestroySelf()
    {
        if (sparkParticles != null)
        {
            sparkParticles.Play();
            StartCoroutine(PlayAndDestroyCoroutine());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator PlayAndDestroyCoroutine()
    {
        yield return new WaitForSeconds(duration);
        sparkParticles.Stop();
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
