﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    #region Variables

    [SerializeField] private Transform objectDestination = null;

    private Rigidbody rb = null;
    private MeshCollider meshCollider = null;

    [SerializeField] private float throwForce = 25f;

    #endregion

    //The object should be NON-STATIC, have a NON-KINEMATIC rigidbody, and a CONVEX mesh collider.
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        meshCollider = GetComponent<MeshCollider>();
    }

    private void OnMouseDown()
    {
        //meshCollider.enabled = false;
        rb.useGravity = false;

        //Freezes rotation, otherwise it will rotate unneccesarily.
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.constraints = RigidbodyConstraints.FreezePosition;

        //Sets the player as parent so it inherits position until mouse release.
        this.transform.parent = objectDestination;
    }

    private void OnMouseUp()
    {
        this.transform.parent = null;
        rb.useGravity = true;
        meshCollider.enabled = true;

        //rb.AddForce(throwForce, 0f, 0f, ForceMode.Impulse);

        //Removes rotation constraints after the object has been released.
        rb.constraints = RigidbodyConstraints.None;
    }
}
