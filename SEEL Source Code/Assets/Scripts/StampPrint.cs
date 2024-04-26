using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampPrint : MonoBehaviour
{
    public VictimManager victimManager;
    public bool freedom=false;
    public bool prison = false;
    public bool death = false;

    public void PrintStamp()
    {
        if (freedom)
        {
            victimManager.victimData.freedomStampPrint.SetActive(true);
            victimManager.victimData.freedomStampPrintUI.SetActive(true);
        }
        if (prison)
        {
            victimManager.victimData.prisonStampPrint.SetActive(true);
            victimManager.victimData.prisonStampPrintUI.SetActive(true);
        }
        if (death)
        {
            victimManager.victimData.deathStampPrint.SetActive(true);
            victimManager.victimData.deathStampPrintUI.SetActive(true);
        }
    }
}
