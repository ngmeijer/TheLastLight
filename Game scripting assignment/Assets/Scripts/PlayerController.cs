using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerSettings))]
[RequireComponent(typeof(PlayerAnimations))]
public class PlayerController : MonoBehaviour
{
    #region Variables

    //------------------------------------------------------------------//
    [Header("Player components")]

    private CharacterController charController = null;

    [SerializeField] private Camera playerCamera = null;

    private PlayerSettings playerSettings = null;
    private PlayerAnimations playerAnims = null;

    private BoxCollider bodyCollider = null;
    private SphereCollider headCollider = null;

    [SerializeField] private Transform groundCheck = null;
    private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    private Vector3 velocity;
    private float gravity = -9.81f;
    private bool isGrounded = true;
    //------------------------------------------------------------------//

    //Change this to a method.
    [HideInInspector] public int nextObjective = 0;
    //------------------------------------------------------------------//

    #endregion

    #region Default methods

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        playerSettings = GetComponent<PlayerSettings>();
        playerAnims = GetComponent<PlayerAnimations>();
    }

    private void Start()
    {
        Cursor.visible = false;

        nullChecks();
    }

    private void Update()
    {
        crouchPlayer();
    }

    private void FixedUpdate()
    {
        movePlayer();
        jumpPlayer();
        rotatePlayer();
        boostPlayer();
    }

    #endregion

    #region Movement related methods

    private void movePlayer()
    {
        //Checks if the invisible sphere overlaps with the "Ground" layerMask within a certain distance.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = playerSettings.downForce;
        }

        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 movementVector = transform.right * horizontalMove + transform.forward * verticalMove;

        if (Input.GetKey(playerSettings.sprintKey))
        {
            playerSettings.moveSpeed = playerSettings.sprintSpeed;
        }
        else
        {
            playerSettings.moveSpeed = playerSettings.walkSpeed;
        }

        charController.Move(movementVector * playerSettings.moveSpeed * Time.deltaTime);

        if(verticalMove > 0)
        {
            playerAnims.handleRunAnimation();
        }
        else
        {
            playerAnims.handleIdleAnimation();
        }
    }

    //Check for KeyInput, if true, apply jumpForce to the vertical axis of the Rigidbody.
    private void jumpPlayer()
    {
        //Yes, I followed a tutorial from Brackeys for this.
        //ONLY calculates gravity by applying  the gravity force to the velocity of the Transform.
        velocity.y += gravity * Time.deltaTime;

        //Implements the calculated gravity on the Y-axis.
        charController.Move(velocity * Time.deltaTime);

        if (Input.GetKey(playerSettings.jumpKey) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(playerSettings.jumpForce * playerSettings.downForce * gravity * Time.deltaTime);
        }
    }

    //A common mechanic in stealth games, this piece of code allows the player to turn off the flashlight and be less visible to enemies,
    //by updating the localPosition of the camera. This means it gets moved in the space relative to the parent, but not in global space (seperate from the parent).
    private void crouchPlayer()
    {
        if (Input.GetKey(playerSettings.crouchKey))
        {
            playerCamera.transform.localPosition = playerSettings.camCrouchPosition;
            playerAnims.handleCrouchAnimation();
            //charController.height = 0.3f;
        }
        else
        {
            playerCamera.transform.localPosition = playerSettings.camNormalPosition;
            //charController.height = 0.8f;
        }
    }

    private void boostPlayer()
    {
        if (Input.GetKeyDown(playerSettings.dashKey))
        {

        }
    }

    #endregion

    #region Camera related Methods

    //Rotates the player (and thus the camera) left and right, by calculating the AxisInput of Mouse X.
    private void rotatePlayer()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X") * playerSettings.rotateSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseHorizontal);
    }

    //Have to rework this function. 
    private void lookBack()
    {
        if (Input.GetKey(playerSettings.reverseViewKey))
        {
            playerCamera.transform.localRotation = playerSettings.reverseViewRotation;
        }
        if (Input.GetKeyUp(playerSettings.reverseViewKey))
        {
            playerCamera.transform.localRotation = playerSettings.normalViewRotation;
        }
    }

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        //
        //if (other.gameObject.CompareTag("NewObjective"))
        //{
        //    nextObjective++;
        //    Destroy(other.gameObject);
        //}
    }

    public void GoNextObjective()
    {

    }

    //Wrote this method to satisfy part of the "Excellent" criteria in the rubric.
    private void nullChecks()
    {
        Debug.Assert(charController != null, "The player's CharacterController cannot be found.");
        Debug.Assert(groundCheck != null, "The player's GroundCheck child-object is null. This means the player won't know if he's standing on the ground or not, so jumping is disabled.");
        Debug.Assert(playerCamera != null, "The player's Camera is null. You shouldn't be able to see shit.");
        Debug.Assert(playerSettings != null, "The PlayerSettings script is null. Check the GetComponent, or serialize it to show in the inspector and drag it in.");
        Debug.Assert(playerAnims != null, "The PlayerAnims script is null. Check the GetComponent, or serialize it to show in the inspector and drag it in.");
    }
}
