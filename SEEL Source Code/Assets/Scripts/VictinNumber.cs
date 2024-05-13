using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VictimData : MonoBehaviour
{
    public VictimManager victimManager;

    public GameObject prisonStampPrint;
    public GameObject freedomStampPrint;
    public GameObject deathStampPrint;

    public GameObject prisonStampPrintUI;
    public GameObject freedomStampPrintUI;
    public GameObject deathStampPrintUI;

    [Header("Numbers")]
    public int freedom;
    public int prison;
    public int death;

    [HideInInspector]
    public int freedomMoney;
    [HideInInspector]
    public int prisonMoney;
    [HideInInspector]
    public int deathMoney;

    [Header("Freedom Dialogue")]
    public List<GameObject> freedomDialogue;

    [Header("Prison Dialogue")]
    public List<GameObject> prisonDialogue;

    [Header("Death Dialogue")]
    public List<GameObject> deathDialogue;

    private void Start()
    {
        prisonStampPrint.SetActive(false);
        deathStampPrint.SetActive(false);
        freedomStampPrint.SetActive(false);

        prisonStampPrintUI.SetActive(false);
        deathStampPrintUI.SetActive(false);
        freedomStampPrintUI.SetActive(false);

        freedomMoney = freedom * 100;
        prisonMoney = prison * 100;
        deathMoney = death * 100;
        //Debug.Log(freedomMoney);
        //Debug.Log(prisonMoney);
        //Debug.Log(deathMoney);
    }
}