using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerScript : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 3.0f;

    private Transform m_transform;

    private CharacterController characterController;

   
    private Vector3 moveVelocity;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        m_transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVelocity.x = Input.GetAxis("Horizontal") * moveSpeed;
        moveVelocity.y = Input.GetAxis("Vertical") * moveSpeed;

        //transform.LookAt(transform.position + new Vector3(moveVelocity.x, 0, moveVelocity.z));

        characterController.Move(moveVelocity * Time.deltaTime);
    
    }
}
