using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Class <c>StackQueueInput<c> Listens for the input from the stack and queue challenge.
/// Displays relevant error messages for incorrect input.
/// <summary>
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
    public GameObject backButton;
    AudioSource beep;
    AudioSource bomp;

    // Passes input to CheckChallengeLogic for checking. 
    public void OnStoppedEditing(string text) {
        errorWindow.SetActive(false);
        CheckChallengeLogic ccl = new CheckChallengeLogic(errorWindow, errorText, bomp);
        // If queue challenge input is correct, play success noise, play animation to remove the sprites, display stack challenge
        if (currentField.name == "First" && ccl.CheckStackAndQueueOrder(currentField.name, text)) {
            destroy[1].SetActive(false);
            if (beep != null) { beep.Play(); }
            StartCoroutine(Remove(roadBlocks, queue, destroy[0]));
            stack.SetActive(true);
        }
        // If stack challenge input is correct, play success nose, play animation for removing the boxes and close the challenge. 
        else if (currentField.name == "Second" && ccl.CheckStackAndQueueOrder(currentField.name, text)) {
            if (beep != null) { beep.Play(); }
            CloseChallenge();
            StartCoroutine(Remove(boxes, displayWindow, destroy[2]));
        }
    }

    // Removes the sprites in the order they are removed from stack/queue
    public IEnumerator Remove(GameObject[] objects, GameObject screen, GameObject obj) {
        backButton.GetComponent<Button>().interactable = false;
        foreach(GameObject go in objects) {
            go.SetActive(false);
            yield return new WaitForSeconds(1);
        }
        Destroy(obj);
        Destroy(screen);
        backButton.GetComponent<Button>().interactable = true;
    }

    // Closes the challenge
    public void CloseChallenge() {           
        // Reinstate character movement
        foreach (GameObject go in character.getParts()) {
            PlayerMovementController pmc = go.GetComponent(typeof(PlayerMovementController)) as PlayerMovementController;
            pmc.UpdateMovementSpeed(2.5f);
        }
        // Store next challenge number in character object
        character.increaseChallengeNumber();
    }


    // Start is called before the first frame update
    void Start()
    {
        // Listen for input
        currentField.onEndEdit.AddListener(delegate {OnStoppedEditing(currentField.text);});
        // Put cursor in text box.
        if (currentField != null) { currentField.Select(); }
        // Find audio
        beep = GameObject.Find("Beep").GetComponent<AudioSource>();
        bomp = GameObject.Find("Bomp").GetComponent<AudioSource>();
    }
}
