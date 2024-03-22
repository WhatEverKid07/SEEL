using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimManager : MonoBehaviour
{
    [Header("---Scripts---")]
    public FirstWaypoint firstWaypoint;
    public SecondWaypoint secondWaypoint;
    public VictinNumber victimNumber;

    [Header("---Stamp Outline---")]
    public Transform freedomOutline;
    public Transform prisonOutline;
    public Transform deathOutline;

    public static int fateNumber;

    public GameObject[] peopleModels; // Array to hold your different people models


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

                firstWaypoint = person.GetComponent<FirstWaypoint>();
                secondWaypoint = person.GetComponent<SecondWaypoint>();
                victimNumber = person.GetComponent<VictinNumber>();
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
    }
    public void AtChair()
    {
        Debug.Log("At Chair");
        firstWaypoint.isOn = false;
        freedomOutline.gameObject.SetActive(true);
        prisonOutline.gameObject.SetActive(true);
        deathOutline.gameObject.SetActive(true);
    }

    public void FreedomChoice()
    {
        Debug.Log("Freedom");
        secondWaypoint.StartMovement();
        fateNumber += victimNumber.freedom;
        Debug.Log(fateNumber);
        freedomOutline.gameObject.SetActive(false);
        prisonOutline.gameObject.SetActive(false);
        deathOutline.gameObject.SetActive(false);
    }
    public void PrisonChoice()
    {
        Debug.Log("Prison");
        secondWaypoint.StartMovement();
        fateNumber += victimNumber.prison;
        Debug.Log(fateNumber);
        freedomOutline.gameObject.SetActive(false);
        prisonOutline.gameObject.SetActive(false);
        deathOutline.gameObject.SetActive(false);
    }
    public void DeathChoice()
    {
        Debug.Log("Death");
        secondWaypoint.StartMovement();
        fateNumber += victimNumber.death;
        Debug.Log(fateNumber);
        freedomOutline.gameObject.SetActive(false);
        prisonOutline.gameObject.SetActive(false);
        deathOutline.gameObject.SetActive(false);
    }

    public void GetNextPerson()
    {
        firstWaypoint.isOn = true;
        currentPerson.SetActive(false);
        GameObject randomPerson = SelectRandomPerson();
        currentPerson = randomPerson;
        currentPerson.SetActive(true);
    }
}
