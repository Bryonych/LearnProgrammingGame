using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StackQueueInput : MonoBehaviour
{
    public GameObject queue;
    public GameObject stack;
    public TMP_InputField currentField;
    public GameObject[] roadBlocks;
    public GameObject[] boxes;
    public GameObject errorWindow;
    public TextMeshProUGUI errorText;
    public Character character;
    public GameObject displayWindow;
    AudioSource beep;
    AudioSource bomp;

    public void OnStoppedEditing(string text) {
        errorWindow.SetActive(false);
        if (currentField.name == "First" && text == "0123") {
            beep.Play();
            Destroy(queue, beep.clip.length);
            stack.SetActive(true);
            roadBlocks[0].GetComponent<Animator>().Play("RoadBlockAnim1");
            // roadBlocks[1].GetComponent<Animator>().Play("RoadBlockAnim2");
            // roadBlocks[2].GetComponent<Animator>().Play("RoadBlockAnim3");
            // roadBlocks[3].GetComponent<Animator>().Play("RoadBlockAnim4");
            roadBlocks[4].SetActive(false);
            roadBlocks[5].SetActive(false);
        }
        else if (currentField.name == "Second" && text == "3210") {
            beep.Play();
            boxes[0].GetComponent<Animator>().Play("BoxAnim");
            boxes[4].SetActive(false);
            CloseChallenge();
        }
        else {
            string eText;
            if (currentField.name == "First") {
                eText = "In a queue, the item added first is the first to be removed.";
            }
            else {
                eText = "In a stack, the item added last is the first to be removed.";
            }
            ErrorHandler eh = new ErrorHandler(bomp, eText, errorWindow, errorText);
        }
    }

    public void CloseChallenge() {           
        foreach (GameObject go in character.getParts()) {
            PlayerMovementController pmc = go.GetComponent(typeof(PlayerMovementController)) as PlayerMovementController;
            pmc.movementSpeed = 2.5f;
        }
        character.increaseChallengeNumber();
        Destroy(displayWindow, beep.clip.length);
    }


    // Start is called before the first frame update
    void Start()
    {
        currentField.onEndEdit.AddListener(delegate {OnStoppedEditing(currentField.text);});
        beep = GameObject.Find("Beep").GetComponent<AudioSource>();
        bomp = GameObject.Find("Bomp").GetComponent<AudioSource>();
    }
}
