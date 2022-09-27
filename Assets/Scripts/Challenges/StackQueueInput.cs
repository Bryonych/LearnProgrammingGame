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
    public GameObject[] destroy;
    public GameObject errorWindow;
    public TextMeshProUGUI errorText;
    public Character character;
    public GameObject displayWindow;
    AudioSource beep;
    AudioSource bomp;

    public void OnStoppedEditing(string text) {
        errorWindow.SetActive(false);
        if (currentField.name == "First" && text == "0123") {
            destroy[1].SetActive(false);
            beep.Play();
            StartCoroutine(Remove(roadBlocks, queue, destroy[0]));
            stack.SetActive(true);
        }
        else if (currentField.name == "Second" && text == "3210") {
            beep.Play();
            CloseChallenge();
            StartCoroutine(Remove(boxes, displayWindow, destroy[2]));
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

    public IEnumerator Remove(GameObject[] objects, GameObject screen, GameObject obj) {
        foreach(GameObject go in objects) {
            go.SetActive(false);
            yield return new WaitForSeconds(2);
        }
        Destroy(obj);
        Destroy(screen);
    }

    public void CloseChallenge() {           
        foreach (GameObject go in character.getParts()) {
            PlayerMovementController pmc = go.GetComponent(typeof(PlayerMovementController)) as PlayerMovementController;
            pmc.movementSpeed = 2.5f;
        }
        character.increaseChallengeNumber();
    }


    // Start is called before the first frame update
    void Start()
    {
        currentField.onEndEdit.AddListener(delegate {OnStoppedEditing(currentField.text);});
        beep = GameObject.Find("Beep").GetComponent<AudioSource>();
        bomp = GameObject.Find("Bomp").GetComponent<AudioSource>();
    }
}
