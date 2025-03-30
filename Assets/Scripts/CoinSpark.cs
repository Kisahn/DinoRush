using System.Collections;
using UnityEngine;

public class CoinSpark : MonoBehaviour
{
    public Transform Star;

    // Start is called before the first frame update
    void Start()
    {
        Star.GetComponent<ParticleSystem> ().enableEmission = false;
    }

    void OnTriggerEnter()
    {
        Star.GetComponent<ParticleSystem> ().enableEmission = true;
        StartCoroutine (stopStar ());
    }

    IEnumerator stopStar()
    {
        yield return new WaitForSeconds (.4f);
        Star.GetComponent<ParticleSystem>  ().enableEmission = false;
    }
}
