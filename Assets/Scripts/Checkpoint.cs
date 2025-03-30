using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    [SerializeField]
    private HealthManager theHealthManager;

    // Start is called before the first frame update
    void Start()
    {
        theHealthManager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            theHealthManager.SetSpawnPoint(transform.position);
        }
    }

}
