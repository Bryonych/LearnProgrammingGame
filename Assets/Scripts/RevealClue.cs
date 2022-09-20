using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RevealClue : MonoBehaviour
{   
    public Character character;
    public TMP_InputField currentField;
    public GameObject errorWindow;
    public GameObject displayWindow;
    public GameObject nextWindow;
    public GameObject[] clues;
    public TextMeshProUGUI errorText;
    public GameObject[] screens;
    public GameObject button;
    private int current = 0;
    public AudioSource beep;
    
    public void OnStoppedEditing(string text) {

        errorWindow.SetActive(false);
        if (text.Length > 0) {
            if (currentField.name == "ListAccessInputField") {
                handleListAccessEntry(text);
            }
        }
    }

    public void handleListAccessEntry(string text) {
        if (!text.StartsWith("barrels")) {
            errorText.text = "To access an item in a list, start with the list's name - barrels";
            errorWindow.SetActive(true);
        }
        else if (!text.StartsWith("barrels[")) {
            errorText.text = "To access an item in a list, start with the list's name and then enter the index number in [ ] afterwards";
            errorWindow.SetActive(true);
        }
        else if (text[8] != '0' && text[8] != '1' && text[8] != '2' && text[8] != '3') {
            errorText.text = "The available index numbers in the list are 0, 1, 2 and 3";
            errorWindow.SetActive(true);
        }
        else if (text[text.Length-1] != ']') {
            errorText.text = "Access an element in the list like this: barrels[2]";
            errorWindow.SetActive(true);
        }
        else {
            beep.Play();
            // displayWindow.SetActive(false);
            Destroy(displayWindow, beep.clip.length);
            nextWindow.SetActive(true);
        }
    }

    public void DisplayError() {
        errorText.text = "The list name is 'barrels', so our foreach loop needs to start with foreach(_ in barrels)";
        errorWindow.SetActive(true);
    }

    public void ChangeScreen() {
        if (current == 1) { button.SetActive(false); }
        screens[current].SetActive(false);
        screens[current+1].SetActive(true);
        current += 1;
    }

    public void ShowClue() {
        beep.Play();
        button.SetActive(false);
        errorWindow.SetActive(false);
        character.increaseChallengeNumber();
        // displayWindow.SetActive(false);
        Destroy(displayWindow, beep.clip.length);
        Destroy(screens[2], beep.clip.length);
        Vector3 pos = character.body.transform.position;
        if (pos.x < -20 && pos.x > -26 && pos.y < -9 && pos.y > -15) {
            clues[0].SetActive(true);
            clues[0].GetComponent<Animator>().Play("ChurchAnimation");
        }
        else if (pos.x < -0.7 && pos.x > -2.6 && pos.y < -5.5 && pos.y > -7.6) {
            clues[1].SetActive(true);
            clues[1].GetComponent<Animator>().Play("ChurchAnimation2");
        }
        else if (pos.x < -19.5 && pos.x > -22.4 && pos.y < 4.5 && pos.y > 2.0) {
            clues[2].SetActive(true);
            clues[2].GetComponent<Animator>().Play("ChurchAnimation3");
        }
        else if (pos.x < 6.9 && pos.x > 3.8 && pos.y < 12.5 && pos.y > 10.9) {
            clues[3].SetActive(true);
            clues[3].GetComponent<Animator>().Play("ChurchAnimation4");
        }
        
        foreach (GameObject go in character.getParts()) {
            PlayerMovementController pmc = go.GetComponent(typeof(PlayerMovementController)) as PlayerMovementController;
            pmc.movementSpeed = 2.5f;
        }
    }

    void Start() {
        currentField.onEndEdit.AddListener(delegate {OnStoppedEditing(currentField.text);});
    }
}
