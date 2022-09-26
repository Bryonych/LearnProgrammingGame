using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetText : MonoBehaviour {
    public GameObject lessonPanel;
    public GameObject inputField;
    public TextMeshProUGUI displayText;
    public Character character;
    public GameObject button;
    public int page;

    void Update() {
        if (page == 0) {
            displayText.SetText("Welcome to the city Agent " + character.getAgentNumber() + ".\n"
            + "We have received intelligence that there are clues to the attacker's whereabouts inside an array of barrels.\n\n"
            + "A array is an ordered collection of data, with the same data type.\n");
        }
        else if (page == 1) {
            displayText.SetText("An example of an array of integers is:\n"
            + "int[ ] numbers = [1, 2, 8, 17];\n"
            + "\nThe \'int[ ]\' part means it is an array of integers and \'numbers\' is the name of the array."
            + "The items after the \'=\' sign in the square brackets are the integers that have been assigned to the array.");
        }
        else if (page == 2) {
            displayText.SetText("You can access an item in an array by using its index number. In programming, we count from zero instead of one.\n\n"
            + "So in the array of integers\n int[ ] numbers = [1, 2, 8, 17];\n We can access the number 1 like this: "
            + "numbers[0] and the number 8 like this: numbers[2]");
        }
        else if (page == 3) {
            displayText.SetText("We have reason to believe there is an array of barrels in your current vacinity. To access the clue, select a "
            + "barrel from the array using its index number as described. The name of the array is 'barrels'.");
            button.SetActive(false);
            inputField.SetActive(true);
        }

    }

    public void turnPage() {
        page += 1;
    }


}
