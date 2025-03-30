using System.Collections;
using UnityEngine;

public class DinoAnim : MonoBehaviour
{
    private Animator anim;

    void Start ()
    {
     anim =GetComponent<Animator>();
    }

    
    void Update()
    {

        // Animation de la course si z est appuyé

        if (Input.GetKey(KeyCode.Z))
        {
            anim.SetBool("Run", true);
        }

        if(Input.GetKeyUp(KeyCode.Z))
        {
            anim.SetBool("Run", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Jump", true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("Jump", false);
        }

        else
        {
            anim.SetBool("Idle", true);
        }
    }
}