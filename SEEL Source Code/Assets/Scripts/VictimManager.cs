using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimManager : MonoBehaviour
{
    public WaypointManager waypointManager;
    public GameObject[] peopleModels; // Array to hold your different people models

    private GameObject currentPerson; // Reference to the currently active person

    // Function to select a random person
    private GameObject SelectRandomPerson()
    {
        int index;
        do
        {
            // Generate a random index
            index = Random.Range(0, peopleModels.Length);
        } while (peopleModels[index] == currentPerson); // Ensure the index is different from the current person

        return peopleModels[index]; // Return the selected person
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
        waypointManager.StartMovement();
    }

    // Example function to demonstrate using the selected person
    public void FreedomChoice(GameObject person)
    {
        Debug.Log("Freedom");
    }

    public void PrisonChoice(GameObject person)
    {
        Debug.Log("Prison");
    }

    public void DeathChoice(GameObject person)
    {
        Debug.Log("Death");
    }

    // Example usage in Start() function


    // Example function to handle the event where something happens to the current person
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
