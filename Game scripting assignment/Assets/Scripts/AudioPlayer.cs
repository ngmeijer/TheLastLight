using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayer : MonoBehaviour
{
    #region Variables

    private AudioSource audioSource = null;

    [SerializeField] private AudioClip footstepSFX = null;

    #endregion

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        nullChecks();
    }

    void Update()
    {
        playFootsteps();
    }

    private void playFootsteps()
    {
        if (Input.GetButtonDown("Horizontal") && !Input.GetButtonDown("Vertical") && !Input.GetKey(KeyCode.LeftControl))
            audioSource.Play();
        else if (!Input.GetButtonDown("Horizontal") && Input.GetButtonDown("Vertical") && !Input.GetKey(KeyCode.LeftControl))
            audioSource.Play();
        else if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical") && audioSource.isPlaying)
            audioSource.Stop();
    }

    private void nullChecks()
    {
        Debug.Assert(audioSource != null, "The audio source attached to the player is null.");
        Debug.Assert(footstepSFX != null, "The footsteps audio file in the audio source is null.");
    }
}
