using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimManager : MonoBehaviour
{
    public FirstWaypoint firstWaypoint;
    public SecondWaypoint secondWaypoint;
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
    }

    private void Start()
    {
        // Select and activate the initial person
        GameObject randomPerson = SelectRandomPerson();
        currentPerson = randomPerson;
        currentPerson.SetActive(true);

        Beginning();
    }

    private void Beginning()
    {
        firstWaypoint.StartMovement();
    }

    // Example function to demonstrate using the selected person
    public void FreedomChoice()
    {
        Debug.Log("Freedom");
        //GetNextPerson();
        secondWaypoint.StartMovement();
    }

    public void PrisonChoice()
    {
        Debug.Log("Prison");
        //GetNextPerson();
        secondWaypoint.StartMovement();
    }

    public void DeathChoice()
    {
        Debug.Log("Death");
        //GetNextPerson();
        secondWaypoint.StartMovement();
    }

    public void GetNextPerson()
    {
        // Deactivate the current person
        currentPerson.SetActive(false);

        // Select and activate the next person
        GameObject randomPerson = SelectRandomPerson();
        currentPerson = randomPerson;
        currentPerson.SetActive(true);
    }
}
