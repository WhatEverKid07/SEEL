using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject subtitle;
    public GameObject background;
    public AudioSource dialogue;
    // Start is called before the first frame update
    void Start()
    {
        PlayDialouge();
        //dialogue = GetComponent<AudioSource>();
    }
    private void PlayDialouge()
    {
        dialogue.Play();
        subtitle.SetActive(true);
        background.SetActive(true);
    }
}
