using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VictimManager : MonoBehaviour
{
    [Header("---Scripts---")]
    public FirstWaypoint firstWaypoint;
    public SecondWaypoint secondWaypoint;
    public VictimData victimData;
    public DocumentButton documentButton;
    public DoorAnimationControl doorAnimationControl;

    [Header("---Stamp Outline---")]
    public Transform freedomOutline;
    public Transform prisonOutline;
    public Transform deathOutline;

    public static int fateNumber;
    public GameObject[] peopleModels; // Array to hold your different people models
    public float rightDoorPauseDuration = 2f;
    public float afterChoicePause = 2f;

    [Header("Info")]
    public GameObject currentPerson; // Reference to the currently active person
    private Dictionary<GameObject, int> selectionCounts = new Dictionary<GameObject, int>();

    // Function to select a random person
    private GameObject SelectRandomPerson()
    {
        // Shuffle the peopleModels array to randomize selection
        ShuffleArray(peopleModels);
        foreach (GameObject person in peopleModels)
        {
            // If the person has not been selected before or has been selected fewer times than others
            if (!selectionCounts.ContainsKey(person) || selectionCounts[person] < 1)
            {
                // Increment the selection count for this person
                if (!selectionCounts.ContainsKey(person))
                    selectionCounts[person] = 1;
                else
                    selectionCounts[person]++;

                firstWaypoint = person.transform.GetComponentInChildren<FirstWaypoint>();
                secondWaypoint = person.transform.GetComponentInChildren<SecondWaypoint>();
                victimData = person.transform.GetComponentInChildren<VictimData>();
                Beginning();

                return person;
            }
        }
        // If all people have been selected once, trigger your function
        AllPeopleSelected();
        // Return null or handle the case where all people have been selected
        return null;
    }
    // Function to shuffle an array
    private void ShuffleArray(GameObject[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            GameObject temp = array[i];
            int randomIndex = Random.Range(i, array.Length);
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
    private void AllPeopleSelected()
    {
        Debug.Log("All people have been selected once");
        // DAY 2
    }

    private void Start()
    {
        GameObject randomPerson = SelectRandomPerson();
        currentPerson = randomPerson;
        currentPerson.SetActive(true);
    }

    private void Beginning()
    {
        firstWaypoint.StartMovement();
        Debug.Log("Beginning");
        StartCoroutine(OpenDoorWithPause());
    }
    IEnumerator OpenDoorWithPause()
    {
        yield return new WaitForSeconds(rightDoorPauseDuration);
        doorAnimationControl.rightDoorAnimation.SetTrigger("RightOpen");
        doorAnimationControl.doorOpening.PlayDelayed(0.75f);
    }
    public void AtChair()
    {
        Debug.Log("At Chair");
        firstWaypoint.isOn = false;
        doorAnimationControl.rightDoorAnimation.SetTrigger("RightClose");
        doorAnimationControl.doorClosing.PlayDelayed(1.77f);
        freedomOutline.gameObject.SetActive(true);
        prisonOutline.gameObject.SetActive(true);
        deathOutline.gameObject.SetActive(true);
    }

    public void FreedomChoice()
    {
        AudioClip freedomRandomClip = victimData.freedomDialogue[Random.Range(0, victimData.freedomDialogue.Count)];
        victimData.victimAudioSource.clip = freedomRandomClip;
        victimData.victimAudioSource.Play();
        EveryChoice();
        Debug.Log("Freedom");
        fateNumber += victimData.freedom;
        StartCoroutine(VoiceLines(freedomRandomClip.length));
    }
    public void PrisonChoice()
    {
        AudioClip prisonRandomClip = victimData.prisonDialogue[Random.Range(0, victimData.prisonDialogue.Count)];
        victimData.victimAudioSource.clip = prisonRandomClip;
        victimData.victimAudioSource.Play();
        EveryChoice();
        Debug.Log("Prison");
        fateNumber += victimData.prison;
        StartCoroutine(VoiceLines(prisonRandomClip.length));
    }
    public void DeathChoice()
    {
        AudioClip deathRandomClip = victimData.deathDialogue[Random.Range(0, victimData.deathDialogue.Count)];
        victimData.victimAudioSource.clip = deathRandomClip;
        victimData.victimAudioSource.Play();
        EveryChoice();
        Debug.Log("Death");
        fateNumber += victimData.death;
        StartCoroutine(VoiceLines(deathRandomClip.length));
    }
    public void EveryChoice()
    {
        StartCoroutine(AfterChoice());
        Debug.Log(fateNumber);
        freedomOutline.gameObject.SetActive(false);
        prisonOutline.gameObject.SetActive(false);
        deathOutline.gameObject.SetActive(false);
    }
    IEnumerator VoiceLines(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        doorAnimationControl.leftDoorAnimation.SetTrigger("LeftOpen");
        doorAnimationControl.doorOpening.PlayDelayed(0.39f);
        StartCoroutine(AfterChoice());
    }
    IEnumerator AfterChoice()
    {
        yield return new WaitForSeconds(3f);
        secondWaypoint.StartMovement();
    }
    public void GetNextPerson()
    {
        firstWaypoint.isOn = true;
        currentPerson.SetActive(false);
        GameObject randomPerson = SelectRandomPerson();
        currentPerson = randomPerson;
        currentPerson.SetActive(true);
        doorAnimationControl.leftDoorAnimation.SetTrigger("LeftClose");
        doorAnimationControl.doorClosing.PlayDelayed(1.2f);
    }
}