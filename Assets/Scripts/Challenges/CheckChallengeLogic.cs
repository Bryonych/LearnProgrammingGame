using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Class <c>CheckChallengeLogic<c> handles checking the logic from the city challenges,
/// displays error messages and returns to MonoBehaviour classes whether input is correct.
/// <summary>
public class CheckChallengeLogic {

    private GameObject errorWindow;
    private TextMeshProUGUI errorText;
    private AudioSource bomp;
    private int[] correctConditionalsOrder = {2, 0, 3, 1, 5, 4};
    private int[] altCorrectConditionalsOrder = {2, 0, 4, 1, 5, 3};
    private string[] codeOrder = { " for (Road road : roadList) {", "    if (road.contains(document) {",
                                "       display(road.getDirection());", "    }", " }"};

    // Constructs a CheckChallengeLogic object
    public CheckChallengeLogic(GameObject ew, TextMeshProUGUI et, AudioSource bomp) {
        this.errorWindow = ew;
        this.errorText = et;
        this.bomp = bomp;
    }

    // Checks the user input for accessing a barrel in the barrels list.
    public bool HandleListAccessEntry(string text) {
        if (!text.StartsWith("barrels")) {
            string eText = "To access an item in a list, start with the list's name - barrels";
            ErrorHandler eh = new ErrorHandler(bomp, eText, errorWindow, errorText);
        }
        else if (!text.StartsWith("barrels.get(")) {
            string eText = "To access an item in a list, start with the list's name and then .get(x), where x is its index number";
            ErrorHandler eh = new ErrorHandler(bomp, eText, errorWindow, errorText);
        }
        else if (text[12] != '0' && text[12] != '1' && text[12] != '2' && text[12] != '3') {
            string eText = "The available index numbers in the list are 0, 1, 2 and 3";
            ErrorHandler eh = new ErrorHandler(bomp, eText, errorWindow, errorText);
        }
        else if (text[text.Length-1] != ')') {
            string eText = "Access an element in the list like this: barrels.get(2)";
            ErrorHandler eh = new ErrorHandler(bomp, eText, errorWindow, errorText);
        }
        else {
            // Passed checks
            return true;
        }
        return false;
    }

    // Checks the order selected for the conditionals challenge
    public int CheckConditionalsOrder(int index, int count, List<TMP_Dropdown.OptionData> menuOptions, TextMeshProUGUI displaySelected) {
        if (index == correctConditionalsOrder[count] || index == altCorrectConditionalsOrder[count]) {
            displaySelected.text += menuOptions[index].text + "\n";
            // Passed, increase the count
            return count +1;
        }
        else {
            string eText = "The order should be: if(statement){ instruction } else { instruction }";
            ErrorHandler eh = new ErrorHandler(bomp, eText, errorWindow, errorText);
            // Failed, return old count
            return count;
        }
    }

    // Checks the order selected for the combination of iteraing and conditionals
    public int CheckOrderCombined(int selected, int order, TextMeshProUGUI[] displayBox) {
        string eText = "";
        if (selected == order) {
            displayBox[order].text = codeOrder[order];
            // Passed, increase the count
            return order +1;
        }
        else if (selected == 4 && order == 3) {
            eText = "The 'if' block is indented inside the 'for' loop, so you need the indented curly brace";
        }
        else if (selected == 3 && order == 4) {
            eText = "This is closing the outer code block, so you need the curly brace that isn't indented";
        }
        else {
            eText = "The order should be:\n for(Type _ : _) { if(condition) { //do something } }";
        }
        ErrorHandler eh = new ErrorHandler(bomp, eText, errorWindow, errorText);
        // Failed, return old count
        return order;
    }

    // Checks the input for the order of the stacks and queues.
    public bool CheckStackAndQueueOrder(string fieldName, string text) {
        if (text.Length == 0) { return false; }
        // Error cases.
        if ((fieldName == "First" && text != "0123") || (fieldName == "Second" && text != "3210")) {
            string eText;
            if (fieldName == "First" && text[0] == '0') {
                eText = "Enter all of the indexes in order without spaces between.";
            }
            else if (fieldName == "First") {
                eText = "In a queue, the item added first is the first to be removed.";
            }
            else if (fieldName == "Second" && text[0] == '3') {
                eText = "Enter all of the indexes in order without spaces between.";
            }
            else {
                eText = "In a stack, the item added last is the first to be removed.";
            }
            ErrorHandler eh = new ErrorHandler(bomp, eText, errorWindow, errorText);
            return false;
        }
        // Passed
        return true;
    }


}