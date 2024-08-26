using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    public List<AudioClip>sfx=new List<AudioClip>();
    public AudioSource audioSource;
    private void Awake()
    {
        instance = this;

    }
   public void PlaySfx(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
