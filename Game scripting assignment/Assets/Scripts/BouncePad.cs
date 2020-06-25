using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    #region Variables

    [SerializeField] private int bounceForce = 500;

    #endregion

    void OnCollisionEnter(Collision other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * bounceForce);
    }
}
