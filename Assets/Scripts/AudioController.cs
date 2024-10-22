using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource BGM;

    public AudioClip bgm;

    private void Start()
    {
        BGM.clip = bgm;
        BGM.Play();
    }
}
