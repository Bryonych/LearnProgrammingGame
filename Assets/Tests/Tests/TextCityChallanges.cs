using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class TestCityChallanges
{   
    GameObject mockErrorWindow = new GameObject();
    TextMeshProUGUI mockText = new TextMeshProUGUI(); 
    AudioSource mockAudioSource = new AudioSource();
    GameObject mockGo = new GameObject();
    Character mockCharacter = new Character();
    List<TMP_Dropdown.OptionData> mockMenuOptions = new List<TMP_Dropdown.OptionData>(){new TMP_Dropdown.OptionData("two"), new TMP_Dropdown.OptionData("oh"), 
                                                        new TMP_Dropdown.OptionData("three"), new TMP_Dropdown.OptionData("one"), 
                                                        new TMP_Dropdown.OptionData("five"), new TMP_Dropdown.OptionData("four")};

    [Test]
    public void ListEntryShouldFailWrongListName() {
        mockErrorWindow.SetActive(false);
        CheckChallengeLogic ccl = new CheckChallengeLogic(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(ccl.HandleListAccessEntry("list"));
        Assert.AreEqual(mockText.text, "To access an item in a list, start with the list's name - barrels");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void ListEntryShouldFailNoGetMethod() {
        mockErrorWindow.SetActive(false);
        CheckChallengeLogic ccl = new CheckChallengeLogic(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(ccl.HandleListAccessEntry("barrels(0)"));
        Assert.AreEqual(mockText.text, "To access an item in a list, start with the list's name and then .get(x), where x is its index number");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void ListEntryShouldFailIndexNotInList() {
        mockErrorWindow.SetActive(false);
        CheckChallengeLogic ccl = new CheckChallengeLogic(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(ccl.HandleListAccessEntry("barrels.get(4)"));
        Assert.AreEqual(mockText.text, "The available index numbers in the list are 0, 1, 2 and 3");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void ListEntryShouldFailNoClosingBracket() {
        mockErrorWindow.SetActive(false);
        CheckChallengeLogic ccl = new CheckChallengeLogic(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(ccl.HandleListAccessEntry("barrels.get(0"));
        Assert.AreEqual(mockText.text, "Access an element in the list like this: barrels.get(2)");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void ListEntryShouldPass() {
        mockErrorWindow.SetActive(false);
        CheckChallengeLogic ccl = new CheckChallengeLogic(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsTrue(ccl.HandleListAccessEntry("barrels.get(0)"));
        Assert.IsFalse(mockErrorWindow.activeSelf);
    }

    [Test]
    public void ListEntryShouldPass2() {
        mockErrorWindow.SetActive(false);
        CheckChallengeLogic ccl = new CheckChallengeLogic(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsTrue(ccl.HandleListAccessEntry("barrels.get(3)"));
        Assert.IsFalse(mockErrorWindow.activeSelf);
    }

    [Test]
    public void ConditionalsOrderShouldFailWrongSelection() {
        mockErrorWindow.SetActive(false);
        TextMeshProUGUI mockDisplay = new TextMeshProUGUI(); 
        CheckChallengeLogic ccl = new CheckChallengeLogic(mockErrorWindow, mockText, mockAudioSource);
        int count = 0;
        int newCount = ccl.CheckConditionalsOrder(0, count, mockMenuOptions, mockDisplay);
        Assert.AreEqual(count, newCount);
        Assert.AreEqual(mockText.text, "The order should be: if(statement){ instruction } else { instruction }");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void ConditionalsOrderShouldFailWrongSelection2() {
        mockErrorWindow.SetActive(false);
        TextMeshProUGUI mockDisplay = new TextMeshProUGUI(); 
        CheckChallengeLogic ccl = new CheckChallengeLogic(mockErrorWindow, mockText, mockAudioSource);
        int count = 3;
        int newCount = ccl.CheckConditionalsOrder(2, count, mockMenuOptions, mockDisplay);
        Assert.AreEqual(count, newCount);
        Assert.AreEqual(mockText.text, "The order should be: if(statement){ instruction } else { instruction }");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void ConditionalsOrderShouldPass() {
        mockErrorWindow.SetActive(false);
        TextMeshProUGUI mockDisplay = new TextMeshProUGUI(); 
        CheckChallengeLogic ccl = new CheckChallengeLogic(mockErrorWindow, mockText, mockAudioSource);
        int count = 3;
        int newCount = ccl.CheckConditionalsOrder(1, count, mockMenuOptions, mockDisplay);
        Assert.AreEqual(count+1, newCount);
        Assert.AreEqual(mockDisplay.text, "oh\n");
        Assert.IsFalse(mockErrorWindow.activeSelf);
    }

    [Test]
    public void ConditionalsOrderShouldPass2() {
        mockErrorWindow.SetActive(false);
        TextMeshProUGUI mockDisplay = new TextMeshProUGUI(); 
        CheckChallengeLogic ccl = new CheckChallengeLogic(mockErrorWindow, mockText, mockAudioSource);
        int count = 1;
        int newCount = ccl.CheckConditionalsOrder(0, count, mockMenuOptions, mockDisplay);
        Assert.AreEqual(count+1, newCount);
        Assert.AreEqual(mockDisplay.text, "two\n");
        Assert.IsFalse(mockErrorWindow.activeSelf);
    }

    [Test]
    public void CombinedOrderShouldFailWrongOrder() {
        mockErrorWindow.SetActive(false);
        TextMeshProUGUI[] displayBox = {new TextMeshProUGUI(), new TextMeshProUGUI(), new TextMeshProUGUI()};
        CheckChallengeLogic ccl = new CheckChallengeLogic(mockErrorWindow, mockText, mockAudioSource);
        int count = 0;
        int newCount = ccl.CheckOrderCombined(1, count, displayBox);
        Assert.AreEqual(count, newCount);
        Assert.AreEqual(mockText.text, "The order should be:\n for(Type _ : _) { if(condition) { //do something } }");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void CombinedOrderShouldFailWrongOrder2() {
        mockErrorWindow.SetActive(false);
        TextMeshProUGUI[] displayBox = {new TextMeshProUGUI(), new TextMeshProUGUI(), new TextMeshProUGUI()};
        CheckChallengeLogic ccl = new CheckChallengeLogic(mockErrorWindow, mockText, mockAudioSource);
        int count = 2;
        int newCount = ccl.CheckOrderCombined(0, count, displayBox);
        Assert.AreEqual(count, newCount);
        Assert.AreEqual(mockText.text, "The order should be:\n for(Type _ : _) { if(condition) { //do something } }");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void CombinedOrderShouldPass() {
        mockErrorWindow.SetActive(false);
        TextMeshProUGUI[] displayBox = {new TextMeshProUGUI(), new TextMeshProUGUI(), new TextMeshProUGUI()};
        CheckChallengeLogic ccl = new CheckChallengeLogic(mockErrorWindow, mockText, mockAudioSource);
        int count = 0;
        int newCount = ccl.CheckOrderCombined(0, count, displayBox);
        Assert.AreEqual(count+1, newCount);
        Assert.AreEqual(displayBox[0].text, " for (Road road : roadList) {");
        Assert.IsFalse(mockErrorWindow.activeSelf);
    }

    [Test]
    public void CombinedOrderShouldPass2() {
        mockErrorWindow.SetActive(false);
        TextMeshProUGUI[] displayBox = {new TextMeshProUGUI(), new TextMeshProUGUI(), new TextMeshProUGUI()};
        CheckChallengeLogic ccl = new CheckChallengeLogic(mockErrorWindow, mockText, mockAudioSource);
        int count = 2;
        int newCount = ccl.CheckOrderCombined(2, count, displayBox);
        Assert.AreEqual(count+1, newCount);
        Assert.AreEqual(displayBox[2].text, "       display(road.getDirection());");
        Assert.IsFalse(mockErrorWindow.activeSelf);
    }

    [Test]
    public void StackAndQueueShouldFailWrongOrderQueue() {
        mockErrorWindow.SetActive(false);
        CheckChallengeLogic ccl = new CheckChallengeLogic(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(ccl.CheckStackAndQueueOrder("First", "3210"));
        Assert.AreEqual(mockText.text, "In a queue, the item added first is the first to be removed.");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void StackAndQueueShouldFailWrongOrderStack() {
        mockErrorWindow.SetActive(false);
        CheckChallengeLogic ccl = new CheckChallengeLogic(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(ccl.CheckStackAndQueueOrder("Second", "0123"));
        Assert.AreEqual(mockText.text, "In a stack, the item added last is the first to be removed.");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void StackAndQueueShouldFailNotAllListedQueue() {
        mockErrorWindow.SetActive(false);
        CheckChallengeLogic ccl = new CheckChallengeLogic(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(ccl.CheckStackAndQueueOrder("First", "0"));
        Assert.AreEqual(mockText.text, "Enter all of the indexes in order without spaces between.");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void StackAndQueueShouldFailNotAllListedStack() {
        mockErrorWindow.SetActive(false);
        CheckChallengeLogic ccl = new CheckChallengeLogic(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(ccl.CheckStackAndQueueOrder("Second", "3"));
        Assert.AreEqual(mockText.text, "Enter all of the indexes in order without spaces between.");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void StackAndQueueShouldFailStrangeInput() {
        mockErrorWindow.SetActive(false);
        CheckChallengeLogic ccl = new CheckChallengeLogic(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(ccl.CheckStackAndQueueOrder("First", "first"));
        Assert.AreEqual(mockText.text, "In a queue, the item added first is the first to be removed.");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void StackAndQueueShouldPassQueue() {
        mockErrorWindow.SetActive(false);
        CheckChallengeLogic ccl = new CheckChallengeLogic(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsTrue(ccl.CheckStackAndQueueOrder("First", "0123"));
        Assert.IsFalse(mockErrorWindow.activeSelf);
    }

    [Test]
    public void StackAndQueueShouldPassStack() {
        mockErrorWindow.SetActive(false);
        CheckChallengeLogic ccl = new CheckChallengeLogic(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsTrue(ccl.CheckStackAndQueueOrder("Second", "3210"));
        Assert.IsFalse(mockErrorWindow.activeSelf);
    }

    [Test]
    public void BugCorrectionShouldFailMissingCurly() {
        mockErrorWindow.SetActive(false);
        CorrectionChecker cc = new CorrectionChecker(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(cc.CheckInput("for(Integernumber:numbers)", 2));
        Assert.AreEqual(mockText.text, "Very close! You forgot to open the curly bracket");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    
    [Test]
    public void BugCorrectionShouldFailWrongInput() {
        mockErrorWindow.SetActive(false);
        CorrectionChecker cc = new CorrectionChecker(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(cc.CheckInput("string", 2));
        string reply = "The bug in this code is the type used is String, rather than integer, so it should read:\n"
                        +"for (Integer number : numbers) {";
        Assert.AreEqual(mockText.text, reply);
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void BugCorrectionShouldPass2() {
        mockErrorWindow.SetActive(false);
        CorrectionChecker cc = new CorrectionChecker(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsTrue(cc.CheckInput("for(Integernumber:numbers){", 2));
        Assert.IsFalse(mockErrorWindow.activeSelf);
    }

    [Test]
    public void BugCorrectionShouldFailWrongInputMissingEquals() {
        mockErrorWindow.SetActive(false);
        CorrectionChecker cc = new CorrectionChecker(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(cc.CheckInput("if(number=6){", 3));
        Assert.AreEqual(mockText.text, "In programming, a single '=' sign is for assignment. Use '==' to check equality.");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void BugCorrectionShouldFailWrongInput3() {
        mockErrorWindow.SetActive(false);
        CorrectionChecker cc = new CorrectionChecker(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(cc.CheckInput("else", 3));
        string reply = "The bug in this code is that it starts with an \'else\' statement, instead of an \'if\'.\n"
                        +"Re-write the line with an \'if\' in place of the \'else\'";
        Assert.AreEqual(mockText.text, reply);
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }
        
    [Test]
    public void BugCorrectionShouldPass3() {
        mockErrorWindow.SetActive(false);
        CorrectionChecker cc = new CorrectionChecker(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsTrue(cc.CheckInput("if(number==6){", 3));
        Assert.IsFalse(mockErrorWindow.activeSelf);
    }

    [Test]
    public void BugCorrectionShouldFailWrongLine() {
        mockErrorWindow.SetActive(false);
        CorrectionChecker cc = new CorrectionChecker(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(cc.CheckInput("if{", 5));
        Assert.AreEqual(mockText.text, "This is code for a different line. You are correcting the fifth line down.");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void BugCorrectionShouldFailWrongInput5() {
        mockErrorWindow.SetActive(false);
        CorrectionChecker cc = new CorrectionChecker(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(cc.CheckInput("jfkdjafl", 5));
        Assert.AreEqual(mockText.text, "The bug in this line is that the \'if\' block is closed with a normal bracket, but it should be a curly bracket");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void BugCorrectionShouldPass5() {
        mockErrorWindow.SetActive(false);
        CorrectionChecker cc = new CorrectionChecker(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsTrue(cc.CheckInput("}", 5));
        Assert.IsFalse(mockErrorWindow.activeSelf);
    }

    [Test]
    public void BugCorrectionShouldFailMissingCurly6() {
        mockErrorWindow.SetActive(false);
        CorrectionChecker cc = new CorrectionChecker(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(cc.CheckInput("else", 6));
        Assert.AreEqual(mockText.text, "The curly brackets need to open after the \'else\'");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void BugCorrectionShouldFailWrongInput6() {
        mockErrorWindow.SetActive(false);
        CorrectionChecker cc = new CorrectionChecker(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(cc.CheckInput("fdfkj", 6));
        Assert.AreEqual(mockText.text, "The bug in this line is that it is an \'if\' statement, where it should be \'else\'");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void BugCorrectionShouldPass6() {
        mockErrorWindow.SetActive(false);
        CorrectionChecker cc = new CorrectionChecker(mockErrorWindow, mockText, mockAudioSource);
        Assert.IsTrue(cc.CheckInput("else{", 6));
        Assert.IsFalse(mockErrorWindow.activeSelf);
    }

}