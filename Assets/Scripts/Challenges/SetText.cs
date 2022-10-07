using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Class <c>SetText<c> Writes text for the pages of the list access challenge.
/// <summary>
public class SetText : MonoBehaviour {
    public GameObject lessonPanel;
    public GameObject inputField;
    public TextMeshProUGUI displayText;
    public Character character;
    public GameObject button;
    public GameObject backButton;
    public int page;

    // Checks which page and displays the text with the agent number stored in the character class. 
    void Update() {
        if (page == 0) {
            displayText.SetText("Welcome to the city Agent " + character.getAgentNumber() + ".\n"
            + "If you need help at any stage, try entering a guess and help will be provided.\n"
            + "We have received intelligence that there are clues to the attacker's whereabouts inside a list of barrels.\n\n"
            + "A list is an ordered collection of data, with the same data type.\n");
            backButton.SetActive(false);
            button.SetActive(true);
            inputField.SetActive(false);
        }
        else if (page == 1) {
            displayText.SetText("An example of a list of integers is:\n"
            + "List<Integer> numbers = List.of(1, 2, 8, 17);\n"
            + "\nThe \'List<Integer>\' part means it is a list of integers and \'numbers\' is the name of the list."
            + "The items in the brackets are the integers that have been assigned to the list.");
            backButton.SetActive(false);
            button.SetActive(true);
            inputField.SetActive(false);
        }
        else if (page == 2) {
            displayText.SetText("You can access an item in a list by using its index number. In programming, we count from zero instead of one.\n\n"
            + "So in the list of integers\n List<Integer> numbers = List.of(1, 2, 8, 17);\n We can access the number 1 like this: "
            + "numbers.get(0) and the number 8 like this: numbers.get(2)\nThe 'get' method in the List class returns the element at the provided index.");
            backButton.SetActive(true);
            button.SetActive(true);
            inputField.SetActive(false);
        }
        else if (page == 3) {
            displayText.SetText("We have reason to believe there is a list of barrels in your current vicinity. To access the clue, select a "
            + "barrel from the list using its index number and the get method as described. The name of the list is 'barrels'.");
            button.SetActive(false);
            inputField.SetActive(true);
            backButton.SetActive(true);
        }

    }

    // Increases the page count
    public void turnPage() {
        page += 1;
    }

    public void turnBack() {
        if (page != 0) {page -=1;}
    }


}
