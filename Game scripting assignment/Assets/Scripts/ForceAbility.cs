using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ForceAbility : MonoBehaviour
{
    #region Variables

    private PlayerSettings playerSettings = null;
    private PlayerAnimations animScript = null;
    [SerializeField] private GameObject player = null;
    private AudioSource forceAudio = null;

    #endregion

    private void Awake()
    {
        if (player != null)
        {
            playerSettings = player.GetComponent<PlayerSettings>();
            animScript = player.GetComponent<PlayerAnimations>();
            forceAudio = GetComponent<AudioSource>();
        }
    }

    private void Start()
    {
        nullChecks();
    }

    private void Update()
    {
        blowObjectsAway();
    }

    private void blowObjectsAway()
    {
        if (Input.GetKeyDown(playerSettings.explosionAbilityKey))
        {
            animScript.handleCameraShakeAnimation();
        }
        if (Input.GetKeyUp(playerSettings.explosionAbilityKey))
        {
            animScript.playerAnim.SetBool("cameraShaking", false);
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, playerSettings.forceRadius);

        foreach (Collider closeObjects in colliders)
        {
            Rigidbody rb = closeObjects.GetComponent<Rigidbody>();

            if (Input.GetKeyUp(playerSettings.explosionAbilityKey))
            {
                if (rb != null)
                {
                    forceAudio.Play();
                    //rb.AddExplosionForce(playerSettings.explosionForce, transform.position, playerSettings.forceRadius, 100f, ForceMode.Impulse);
                    rb.AddRelativeForce(Vector3.up * playerSettings.explosionForce, ForceMode.Impulse);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        //Shows the force radius/range in which the cubes will be affected in scene view.
        if (playerSettings == null)
        {
            return;
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, playerSettings.forceRadius);
        }
    }

    private void nullChecks()
    {
        Debug.Assert(player != null, "Player GameObject could not be found.");
        Debug.Assert(animScript != null, "Player Animator component could not be found.");
        Debug.Assert(forceAudio != null, "Gameobject's Audio Source could not be found.");
        Debug.Assert(playerSettings != null, "The Players' PlayerSettings script could not be found.");
    }
}
