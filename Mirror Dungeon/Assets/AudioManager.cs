using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string VolumePref = "VolumePref";
    private int firstPlayInt;
    public Slider VolumeSlider;
    private float VolumeFloat;
    public AudioSource VolumeAudio;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            VolumeFloat = 0.75f;
            VolumeSlider.value = VolumeFloat;
            PlayerPrefs.SetFloat(VolumePref, VolumeFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            VolumeFloat = PlayerPrefs.GetFloat(VolumePref);
            VolumeSlider.value = VolumeFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(VolumePref, VolumeSlider.value);
        UpdateSound();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveSoundSettings();
        }
    }
    
    public void UpdateSound()
    {
        VolumeAudio.volume = VolumeSlider.value;
    }
    
}
