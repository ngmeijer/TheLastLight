using UnityEngine;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private AudioMixer audioMixer = null;

    #endregion

    private void Start()
    {
        nullChecks();
    }

    private void nullChecks()
    {
        Debug.Assert(audioMixer != null, "The main AudioMixer is null. Drag it into the inspector slot.");
    }
    public void SetMainVolume(float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
