using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("----------- Audio Source -----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------- Audio Clip -----------")]
    public AudioClip background;
    public AudioClip ghostis1;
    public AudioClip ghostis2;
    public AudioClip ghostis3;
    public AudioClip ghostis4;

    public AudioClip wind1;
    public AudioClip wind2;

    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
