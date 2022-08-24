using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetText : MonoBehaviour {
    public TextMeshProUGUI displayText;
    public Character character;
    public int page;

    void Update() {
        if (page == 1) {
            displayText.SetText("Welcome to the city Agent " + character.getAgentNumber() + ".\n"
            + "We have received intelligence that there are clues to the attackers whereabouts inside a list of barrels.\n\n"
            + "A list is an ordered collection of data that all has the same data type.\n");
        }
        else if (page == 2) {
            displayText.SetText("An example of a list of integers is:\n"
            + "int[] numbers = [1, 2, 8, 17]\n\n"
            + "\nThe \'int[]\' part means it is a list of ints and \'numbers\' is the name of the list."
            + "The items after the \'=\' sign in the square brackets are the integers that have been assigned to the list.");
        }
        else if (page == 3) {
            displayText.SetText("We have reason to belive the list of barrels is in your current vacinity.\n"
            + "You can access an item in a list by using its index number. In programming, we count from zero."
            + "So in the list of integers\n int[] numbers = [1, 2, 8, 17]\n We can access the number 1 like this:"
            + "numbers[0] and the number 8 like this: numbers[2]");
        }

    }

    public void turnPage() {
        page += 1;
    }


}
