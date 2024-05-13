using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
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
    public FadeForNextDay fadeForNextDay;

    [Header("---Stamp Outline---")]
    public Transform freedomOutline;
    public Transform prisonOutline;
    public Transform deathOutline;

    [Header("---Money---")]
    public Text moneyScore;
    public static int moneyCounterStatic;
    public int moneyCounter;

    [Header("---Other Stuff---")]
    public static int fateNumber;
    public GameObject[] peopleModels; // Array to hold your different people models
    public float rightDoorPauseDuration;
    public float afterChoicePause;
    private float clipLength;
    public GameObject nextDay;

    private GameObject chosenFreedomDialouge;
    private GameObject chosenPrisonDialouge;
    private GameObject chosenDeathDialouge;

    public Transform rustyButtonOutlineForNextPerson;

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
        fadeForNextDay.BlackOut();
        StartCoroutine(NextDay());
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene("Demo End");
    }
    IEnumerator NextDay()
    {
        yield return new WaitForSeconds(0.4f);
        nextDay.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Start()
    {
        moneyCounter = moneyCounterStatic;
        moneyScore.text = moneyCounterStatic.ToString("0");
        GameObject randomPerson = SelectRandomPerson();
        currentPerson = randomPerson;
        currentPerson.SetActive(true);
        
        nextVictimButtonOutline.gameObject.SetActive(false);
        rustyButtonOutlineForNextPerson.gameObject.SetActive(false);
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
        doorAnimationControl.OpenRightDoor();
    }
    public void AtChair()
    {
        victimAnimatorController.SetTrigger("Sit");
        Debug.Log("At Chair");
        firstWaypoint.isOn = false;
        doorAnimationControl.CloseRightDoor();
        freedomOutline.gameObject.SetActive(true);
        prisonOutline.gameObject.SetActive(true);
        deathOutline.gameObject.SetActive(true);
        StartCoroutine(StopPeopleChatter());
    }
    IEnumerator StopPeopleChatter()
    {
        yield return new WaitForSeconds(1.9f);
        doorAnimationControl.peopleChatter.Stop();
    }
    public void FreedomChoice()
    {
        AudioClip freedomRandomClip;
        int randomIndex = Random.Range(0, victimData.freedomDialogue.Count);
        chosenFreedomDialouge = victimData.freedomDialogue[randomIndex];
        freedomRandomClip = chosenFreedomDialouge.GetComponent<AudioSource>().clip;
        chosenFreedomDialouge.SetActive(true);
        clipLength = freedomRandomClip.length;

        EveryChoice();
        Debug.Log("Freedom");
        fateNumber += victimData.freedom;
        moneyCounter += victimData.freedomMoney;

        StartCoroutine(VoiceLines());
    }
    public void PrisonChoice()
    {
        AudioClip prisonRandomClip;
        int randomIndex = Random.Range(0, victimData.prisonDialogue.Count);
        chosenPrisonDialouge = victimData.prisonDialogue[randomIndex];
        prisonRandomClip = chosenPrisonDialouge.GetComponent<AudioSource>().clip;
        chosenPrisonDialouge.SetActive(true);
        clipLength = prisonRandomClip.length;

        EveryChoice();
        Debug.Log("Prison");
        fateNumber += victimData.prison;
        moneyCounter += victimData.prisonMoney;

        StartCoroutine(VoiceLines());
    }
    public void DeathChoice()
    {
        AudioClip deathRandomClip;
        int randomIndex = Random.Range(0, victimData.deathDialogue.Count);
        chosenDeathDialouge = victimData.deathDialogue[randomIndex];
        deathRandomClip = chosenDeathDialouge.GetComponent<AudioSource>().clip;
        chosenDeathDialouge.SetActive(true);
        clipLength = deathRandomClip.length;

        EveryChoice();
        Debug.Log("Death");
        fateNumber += victimData.death;
        moneyCounter += victimData.deathMoney;

        StartCoroutine(VoiceLines());
    }
    public void EveryChoice()
    {
        victimAnimatorController.SetTrigger("Stand");
        Debug.Log(fateNumber);
        freedomOutline.gameObject.SetActive(false);
        prisonOutline.gameObject.SetActive(false);
        deathOutline.gameObject.SetActive(false);
    }

    private void Update()
    {
        /*
        if (Input.GetKeyUp(KeyCode.Space))
        {
            moneyCounter += 100;
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            moneyCounter += -100;
        }
        */

        if (moneyCounter == moneyCounterStatic)
        {
            moneyCounterStatic += 0;
        }
        else if (moneyCounter <= moneyCounterStatic)
        {
            moneyCounterStatic += -1;
        }
        else if (moneyCounter >= moneyCounterStatic)
        {
            moneyCounterStatic += 1;
        }
        moneyScore.text = moneyCounterStatic.ToString("0");
    }

    IEnumerator VoiceLines()
    {
        yield return new WaitForSeconds(clipLength);

        doorAnimationControl.OpenLeftDoor();

        if (chosenFreedomDialouge == true)
        {
            chosenFreedomDialouge.SetActive(false);
            Debug.Log("IM GONE");
        }
        if (chosenPrisonDialouge == true)
        {
            chosenPrisonDialouge.SetActive(false);
            Debug.Log("IM GONE");
        }
        if (chosenDeathDialouge == true)
        {
            chosenDeathDialouge.SetActive(false);
            Debug.Log("IM GONE");
        }

        StartCoroutine(AfterChoice());
    }
    IEnumerator AfterChoice()
    {
        yield return new WaitForSeconds(2f);
        victimAnimatorController.SetTrigger("Walk");
        secondWaypoint.StartMovement();
        yield return new WaitForSeconds(3.3f);
        documentDrawerAnimationController.PutAwayDocument();
        rustyButtonOutlineForNextPerson.gameObject.SetActive(true);
    }
    public void JustBeforeNextPerson()
    {
        doorAnimationControl.CloseLeftDoor();
        firstWaypoint.isOn = true;

        currentPerson.SetActive(false);
        Debug.Log("Away Document HAHAHAHA");

        //this is if we dont want the rusty button to get a new person
        //StartCoroutine(GetNextPerson());
    }
    public void RustyButtonActivate()
    {
        StartCoroutine(GetNextPerson());
    }

    public IEnumerator GetNextPerson()
    {
        yield return new WaitForSeconds(2f);
        GameObject randomPerson = SelectRandomPerson();
        currentPerson = randomPerson;
        currentPerson.SetActive(true);
    }
}