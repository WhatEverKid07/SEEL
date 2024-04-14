using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VictimData : MonoBehaviour
{
    public VictimManager victimManager;
    public AudioSource victimAudioSource;

    [Header("Numbers")]
    public int freedom;
    public int prison;
    public int death;

    [Header("Freedom Dialogue")]
    public List<AudioClip> freedomDialogue;

    [Header("Prison Dialogue")]
    public List<AudioClip> prisonDialogue;

    [Header("Death Dialogue")]
    public List<AudioClip> deathDialogue;
    private void Start()
    {
        victimAudioSource = GetComponent<AudioSource>();
    }
}