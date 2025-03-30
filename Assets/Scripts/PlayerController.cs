using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float gravityScale;
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private Transform pivot;
    [SerializeField]
    public float rotateSpeed;
    [SerializeField]
    public GameObject playerModel;

    private Vector3 moveDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();      
        float myrtpc =0;
        AkSoundEngine.SetState("Dead_Or_Alive", "Alive");
        AkSoundEngine.SetRTPCValue("Pause_Menu",myrtpc);
    }

    // Update is called once per frame
    void Update()
    {
        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);

        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = (moveDirection.normalized * moveSpeed);
        moveDirection.y = yStore;

        if(controller.isGrounded)
        {
            moveDirection.y = 0f;
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpForce;
                AkSoundEngine.PostEvent("Space_Jump", gameObject);
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
        controller.Move(moveDirection * Time.deltaTime);

        // Move the player in different direction based on camera look direction

        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

    }
}
