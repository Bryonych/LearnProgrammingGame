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
}