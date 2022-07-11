using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Piano : MonoBehaviour
{
    public void PlaySound(AudioSource source)
    {
        source.Play();
    }
}
