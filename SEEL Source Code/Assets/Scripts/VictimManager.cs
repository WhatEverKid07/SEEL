using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictimManager : MonoBehaviour
{
    [Header("---Scripts---")]
    public FirstWaypoint firstWaypoint;
    public SecondWaypoint secondWaypoint;
    public VictimData victimData;
    public DocumentButton documentButton;
    public DoorAnimationControl doorAnimationControl;
    public Document_DrawerAnimationController documentDrawerAnimationController;

    [Header("---Stamp Outline---")]
    public Transform freedomOutline;
    public Transform prisonOutline;
    public Transform deathOutline;

    public static int fateNumber;
    public GameObject[] peopleModels; // Array to hold your different people models
    public float rightDoorPauseDuration;
    public float afterChoicePause;

    [Header("Info")]
    public GameObject currentPerson; // Reference to the currently active person
    public Animator victimAnimatorController;
    public Transform nextVictimButtonOutline;

    //public Animator 

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
                victimAnimatorController = person.transform.GetComponentInChildren<Animator>();


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
        SceneManager.LoadScene("Demo End");
    }

    private void Start()
    {
        GameObject randomPerson = SelectRandomPerson();
        currentPerson = randomPerson;
        currentPerson.SetActive(true);
        
        nextVictimButtonOutline.gameObject.SetActive(false);
    }

    private void Beginning()
    {

        documentDrawerAnimationController.TakeOutDocument();
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
        victimAnimatorController.SetTrigger("Sit");
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
        /*
        AudioClip freedomRandomClip = victimData.freedomDialogue[Random.Range(0, victimData.freedomDialogue.Count)];
        victimData.victimAudioSource.clip = freedomRandomClip;
        victimData.victimAudioSource.Play();
        */
        victimData.freedomSubtitles.gameObject.SetActive(true);
        victimData.subtitleBackground.gameObject.SetActive(true);
        EveryChoice();
        Debug.Log("Freedom");
        fateNumber += victimData.freedom;
        StartCoroutine(VoiceLines());
        //        StartCoroutine(VoiceLines(freedomRandomClip.length));
    }
    public void PrisonChoice()
    {
        /*
        AudioClip prisonRandomClip = victimData.prisonDialogue[Random.Range(0, victimData.prisonDialogue.Count)];
        victimData.victimAudioSource.clip = prisonRandomClip;
        victimData.victimAudioSource.Play();
        */
        victimData.prisonSubtitles.gameObject.SetActive(true);
        victimData.subtitleBackground.gameObject.SetActive(true);
        EveryChoice();
        Debug.Log("Prison");
        fateNumber += victimData.prison;
        StartCoroutine(VoiceLines());
        //        StartCoroutine(VoiceLines(prisonRandomClip.length));
    }
    public void DeathChoice()
    {
        /*
        AudioClip deathRandomClip = victimData.deathDialogue[Random.Range(0, victimData.deathDialogue.Count)];
        victimData.victimAudioSource.clip = deathRandomClip;
        victimData.victimAudioSource.Play();
        */
        victimData.deathSubtitles.gameObject.SetActive(true);
        victimData.subtitleBackground.gameObject.SetActive(true);
        EveryChoice();
        Debug.Log("Death");
        fateNumber += victimData.death;

        StartCoroutine(VoiceLines());
        //StartCoroutine(VoiceLines(deathRandomClip.length));
    }
    public void EveryChoice()
    {
        victimAnimatorController.SetTrigger("Stand");
        //StartCoroutine(AfterChoice());
        Debug.Log(fateNumber);
        freedomOutline.gameObject.SetActive(false);
        prisonOutline.gameObject.SetActive(false);
        deathOutline.gameObject.SetActive(false);
    }
    IEnumerator VoiceLines()
    {
        //    IEnumerator VoiceLines(float clipLength)
        //        yield return new WaitForSeconds(clipLength);
        yield return new WaitForSeconds(5f);

        doorAnimationControl.leftDoorAnimation.SetTrigger("LeftOpen");
        doorAnimationControl.doorOpening.PlayDelayed(0.39f);
        victimData.freedomSubtitles.gameObject.SetActive(false);
        victimData.prisonSubtitles.gameObject.SetActive(false);
        victimData.deathSubtitles.gameObject.SetActive(false);
        victimData.subtitleBackground.gameObject.SetActive(false);

        StartCoroutine(AfterChoice());
    }
    IEnumerator AfterChoice()
    {
        yield return new WaitForSeconds(2f);
        victimAnimatorController.SetTrigger("Walk");
        secondWaypoint.StartMovement();
        yield return new WaitForSeconds(3.3f);
        documentDrawerAnimationController.PutAwayDocument();
    }
    public void JustBeforeNextPerson()
    {
        doorAnimationControl.leftDoorAnimation.SetTrigger("LeftClose");
        doorAnimationControl.doorClosing.PlayDelayed(1.2f);
        firstWaypoint.isOn = true;

        currentPerson.SetActive(false);
        Debug.Log("Away Document HAHAHAHA");
        StartCoroutine(GetNextPerson());
        //nextVictimButtonOutline.gameObject.SetActive(true);
    }


    public IEnumerator GetNextPerson()
    {

        yield return new WaitForSeconds(2f);


        GameObject randomPerson = SelectRandomPerson();
        currentPerson = randomPerson;
        currentPerson.SetActive(true);
        

    }
}