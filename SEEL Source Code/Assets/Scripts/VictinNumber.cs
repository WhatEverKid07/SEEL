using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VictimData : MonoBehaviour
{
    public VictimManager victimManager;
    public AudioSource victimAudioSource;

    public GameObject prisonStampPrint;
    public GameObject freedomStampPrint;
    public GameObject deathStampPrint;

    public GameObject prisonStampPrintUI;
    public GameObject freedomStampPrintUI;
    public GameObject deathStampPrintUI;

    public Transform subtitleBackground;
    [Header("Numbers")]
    public int freedom;
    public int prison;
    public int death;

    [Header("Freedom Dialogue")]
    public List<GameObject> freedomDialogue;
    //public Transform freedomSubtitles;

    [Header("Prison Dialogue")]
    public List<GameObject> prisonDialogue;
    //public Transform prisonSubtitles;

    [Header("Death Dialogue")]
    public List<GameObject> deathDialogue;
    //public Transform deathSubtitles;

    private void Start()
    {
        victimAudioSource = GetComponent<AudioSource>();
        prisonStampPrint.SetActive(false);
        deathStampPrint.SetActive(false);
        freedomStampPrint.SetActive(false);

        prisonStampPrintUI.SetActive(false);
        deathStampPrintUI.SetActive(false);
        freedomStampPrintUI.SetActive(false);
    }
}