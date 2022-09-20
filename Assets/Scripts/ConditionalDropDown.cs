using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConditionalDropDown : MonoBehaviour
{
    public Character character;
    public GameObject displayWindow;
    public TextMeshProUGUI errorText;
    public GameObject errorPanel;
    public TextMeshProUGUI displaySelected;
    public TMP_Dropdown selected;
    public AudioSource bleep;
    public GameObject button;
    private int[] correctOrder = {2, 0, 3, 1, 5, 4};
    private int codeLineCount = 0;
    List<TMP_Dropdown.OptionData> menuOptions;

    public void Start() {
        menuOptions = selected.GetComponent<TMP_Dropdown>().options;
    }
    
    public void OnSelect() {
        errorPanel.SetActive(false);
        int index = selected.value;
        print(index);
        if (index == correctOrder[codeLineCount]) {
            displaySelected.text += menuOptions[index].text + "\n";
            codeLineCount += 1;
        }
        else {
            errorText.text = "The order should be: if(statement){ instruction } else { instruction }";
            errorPanel.SetActive(true);
        }
        if (codeLineCount == 6) {
            bleep.Play();
            displaySelected.text = "The attacker went North!";
            button.SetActive(true);
            character.increaseChallengeNumber();
        }
    }

    public void Close() {
        foreach (GameObject go in character.getParts()) {
            PlayerMovementController pmc = go.GetComponent(typeof(PlayerMovementController)) as PlayerMovementController;
            pmc.movementSpeed = 2.5f;
        }
        displayWindow.SetActive(false);
    }
    
}
