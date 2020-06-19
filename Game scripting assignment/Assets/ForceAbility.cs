using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ForceAbility : MonoBehaviour
{
    #region Variables

    private PlayerSettings playerSettings = null;

    private PlayerAnimations animScript = null;

    [SerializeField] private GameObject player = null;

    #endregion

    void Awake()
    {
        if (player != null)
        {
            playerSettings = player.GetComponent<PlayerSettings>();
            animScript = player.GetComponent<PlayerAnimations>();
        }
    }

    void Update()
    {
        blowObjectsAway();
    }

    private void blowObjectsAway()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, playerSettings.forceRadius);

        foreach (Collider closeObjects in colliders)
        {
            Rigidbody rb = closeObjects.GetComponent<Rigidbody>();

            if (Input.GetKeyDown(playerSettings.explosionAbilityKey))
            {
                animScript.handleCameraShakeAnimation();
                if (rb != null)
                {
                    rb.AddExplosionForce(playerSettings.explosionForce, transform.position, playerSettings.forceRadius, 100f, ForceMode.Impulse);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
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
}
