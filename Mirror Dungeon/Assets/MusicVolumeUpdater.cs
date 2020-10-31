using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolumeUpdater : MonoBehaviour
{
    private static readonly string VolumePref = "VolumePref";
    public AudioSource VolumeAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VolumeAudio.volume = PlayerPrefs.GetFloat(VolumePref);
    }
}
