using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller1 : MonoBehaviour
{
    // Start is called before the first frame update
    float playerHeight = 2f;
    private Camera _camera;
    [Header("Movment")]
    private float moveSpeed;
    [SerializeField] private float crouchSpeed = 2f;
    [SerializeField] private float standSpeed = 5f;
    [SerializeField] private float moveMultiplier = 10f;
    float horizontalMovment;
    float verticalMovment;
    Vector3 moveDirection;
    Rigidbody _rigidbody;
    float rbDrag = 6f;
    [SerializeField] private float airMovement = 0.4f;
    [Header("Jump")]
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float airDrag = 3f;
    bool isGrounded;
    [Header("Crouch")]
    [SerializeField] private float crouchHeight;
    private float startHeight;
    [Header("Interact")]
    bool canInteract;



    void Start(){
        _rigidbody = GetComponent<Rigidbody>();   

        _rigidbody.freezeRotation = true;

        startHeight = transform.localScale.y;
        moveSpeed = standSpeed;
        
    }
    void Update(){
        MyInput();
        ControlDrag();

        Grounded();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true){
            Jump();
        }       
        Crouch();



    }
    void FixedUpdate(){
        // use fixed update since the movement is physics based
        PlayerMovement();
       
    }
    private void ControlDrag(){
        if (!isGrounded){
            _rigidbody.drag = airDrag;
            
        }else{
            _rigidbody.drag = rbDrag;
        }
        
    }
    private void Grounded(){
        // uses a raycast to check if the palyer is touching the ground
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2 + 0.01f);


    }
    private void MyInput(){
        horizontalMovment = Input.GetAxisRaw("Horizontal");
        verticalMovment = Input.GetAxisRaw("Vertical");

    }
    private void PlayerMovement(){

        moveDirection = transform.forward * verticalMovment + transform.right * horizontalMovment;
        // the speed of the player will change when the player is on the ground
        // or in the air
        if (!isGrounded){ 
            _rigidbody.AddForce(moveDirection.normalized * moveSpeed * moveMultiplier * airMovement, 
            ForceMode.Acceleration);
        }else{
            _rigidbody.AddForce(moveDirection.normalized * moveSpeed * moveMultiplier, 
            ForceMode.Acceleration);
        }
    }
    private void Jump(){
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }
    private void Crouch(){
        if (Input.GetKeyDown(KeyCode.LeftControl)){
            transform.localScale = new Vector3(transform.localScale.x, crouchHeight, transform.localScale.z);
            _rigidbody.AddForce(Vector3.down * 5f, ForceMode.Impulse);
            moveSpeed = crouchSpeed;       
        // stops crouching when player releases the controll button
        }else if (Input.GetKeyUp(KeyCode.LeftControl)){
            transform.localScale = new Vector3(transform.localScale.x, startHeight, transform.localScale.z);
            moveSpeed = standSpeed;
            
        }
    }
}
