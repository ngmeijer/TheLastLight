using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator playerAnim = null;

    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        nullChecks();
    }

    public void handleIdleAnimation()
    {
        //Change to event based.
        playerAnim.SetBool("isIdle", true);
        playerAnim.SetBool("isCrouching", false);
    }

    public void handleCrouchAnimation()
    {
        playerAnim.SetBool("isCrouching", true);
        playerAnim.SetBool("isIdle", false);
    }

    private void handleJumpAnimation()
    {

    }

    private void nullChecks()
    {
        Debug.Assert(playerAnim != null, "The playerAnim component is null. Check the GetComponent, or serialize it to show in the inspector and drag it in.");
    }
}
