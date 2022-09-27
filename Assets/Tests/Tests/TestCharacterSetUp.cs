using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class TestCharacterSetUp
{   
    GameObject mockErrorWindow = new GameObject();
    TextMeshProUGUI mockText = new TextMeshProUGUI(); 
    AudioSource mockAudioSource = new AudioSource();
    GameObject mockGo = new GameObject();
    Character mockCharacter = new Character();

    [Test]
    public void  AddShoesHandlesErrorCaseNoQuotes() {
        mockErrorWindow.SetActive(false);
        Shoes s = new Shoes(null, null, mockCharacter, mockGo); 
        Assert.IsFalse(s.checkLogicShoes("s", mockErrorWindow, mockText, mockAudioSource, mockAudioSource));
        Assert.AreEqual(mockText.text, "Chars are in single quotes: ' '");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void  AddShoesShouldNotError() {
        mockErrorWindow.SetActive(false);
        Shoes s = new Shoes(null, null, mockCharacter, mockGo); 
        Assert.IsTrue(s.checkLogicShoes("\'s\'", mockErrorWindow, mockText, mockAudioSource, mockAudioSource));
        Assert.IsTrue(!mockErrorWindow.activeSelf);
    }

    [Test]
    public void  AddShoesHandlesErrorCaseNotChar() {
        mockErrorWindow.SetActive(false);
        Shoes s = new Shoes(null, null, mockCharacter, mockGo); 
        Assert.IsFalse(s.checkLogicShoes("\'shoes\'", mockErrorWindow, mockText, mockAudioSource, mockAudioSource));
        Assert.AreEqual(mockText.text, "Inputs are either \'s\' or \'b\'");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void  AddHairHandlesErrorCaseWrongEntry() {
        mockErrorWindow.SetActive(false);
        Hair h = new Hair(null, null, mockCharacter, mockGo); 
        Assert.IsFalse(h.checkLogicHair("\"orange\"", mockErrorWindow, mockText, mockAudioSource, mockAudioSource));
        Assert.AreEqual(mockText.text, "Inputs are either \"long green\" or \"short black\" or \"dreads\" or \"short orange\"");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void  AddHairShouldNotError() {
        mockErrorWindow.SetActive(false);
        Hair h = new Hair(null, null, mockCharacter, mockGo); 
        Assert.IsTrue(h.checkLogicHair("\"dreads\"", mockErrorWindow, mockText, mockAudioSource, mockAudioSource));
        Assert.IsFalse(mockErrorWindow.activeSelf);
    }

    [Test]
    public void  AddHairHandlesErrorCaseNoQuotes() {
        mockErrorWindow.SetActive(false);
        Hair h = new Hair(null, null, mockCharacter, mockGo); 
        Assert.IsFalse(h.checkLogicHair("long green", mockErrorWindow, mockText, mockAudioSource, mockAudioSource));
        Assert.AreEqual(mockText.text, "A string needs to be in quotation marks");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void  AddHatHandlesErrorCaseWrongEntry() {
        mockErrorWindow.SetActive(false);
        Hat h = new Hat(null, null, mockCharacter, mockGo); 
        Assert.IsFalse(h.checkLogicHat("\"hat\"", mockErrorWindow, mockText, mockAudioSource, mockAudioSource));
        Assert.AreEqual(mockText.text, "Inputs are either \"cap\" or \"top hat\"");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void  AddHatShouldNotError() {
        mockErrorWindow.SetActive(false);
        Hat h = new Hat(null, null, mockCharacter, mockGo); 
        Assert.IsTrue(h.checkLogicHat("\"cap\"", mockErrorWindow, mockText, mockAudioSource, mockAudioSource));
        Assert.IsFalse(mockErrorWindow.activeSelf);
    }

    [Test]
    public void  AddHatHandlesErrorCaseNoQuotes() {
        mockErrorWindow.SetActive(false);
        Hat h = new Hat(null, null, mockCharacter, mockGo); 
        Assert.IsFalse(h.checkLogicHat("top hat", mockErrorWindow, mockText, mockAudioSource, mockAudioSource));
        Assert.AreEqual(mockText.text, "A string is in quotation marks");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void  AddTopHandlesErrorCaseNotBoolean() {
        mockErrorWindow.SetActive(false);
        Top t = new Top(null, null, mockCharacter, mockGo); 
        Assert.IsFalse(t.checkLogicTop("yes", mockErrorWindow, mockText, mockAudioSource, mockAudioSource));
        Assert.AreEqual(mockText.text, "A boolean is either true or false");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void  AddTopShouldNotError() {
        mockErrorWindow.SetActive(false);
        Top t = new Top(null, null, mockCharacter, mockGo); 
        Assert.IsTrue(t.checkLogicTop("true", mockErrorWindow, mockText, mockAudioSource, mockAudioSource));
        Assert.IsFalse(mockErrorWindow.activeSelf);
    }

    [Test]
    public void  AddBottomsHandlesErrorCaseNotBoolean() {
        mockErrorWindow.SetActive(false);
        Bottoms b = new Bottoms(null, null, mockCharacter, mockGo); 
        Assert.IsFalse(b.checkLogicBottoms("yes", mockErrorWindow, mockText, mockAudioSource, mockAudioSource));
        Assert.AreEqual(mockText.text, "A boolean is either true or false");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void  AddBottomsShouldNotError() {
        mockErrorWindow.SetActive(false);
        Bottoms b = new Bottoms(null, null, mockCharacter, mockGo); 
        Assert.IsTrue(b.checkLogicBottoms("true", mockErrorWindow, mockText, mockAudioSource, mockAudioSource));
        Assert.IsFalse(mockErrorWindow.activeSelf);
    }

    [Test]
    public void CheckTypeStringShouldFailNoQuotes() {
        mockErrorWindow.SetActive(false);
        TypesInputChecker tic = new TypesInputChecker(mockCharacter, "StringInputField", mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(tic.CheckInput("Bond"));
        Assert.AreEqual(mockText.text, "Strings must be in quotation marks");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void CheckTypeStringShouldPass() {
        mockErrorWindow.SetActive(false);
        TypesInputChecker tic = new TypesInputChecker(mockCharacter, "StringInputField", mockErrorWindow, mockText, mockAudioSource);
        Assert.IsTrue(tic.CheckInput("\"Bond\""));
        Assert.IsFalse(mockErrorWindow.activeSelf);
    }

    [Test]
    public void CheckTypeIntShouldFailDecimalPlace() {
        mockErrorWindow.SetActive(false);
        TypesInputChecker tic = new TypesInputChecker(mockCharacter, "IntInputField", mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(tic.CheckInput("1.5"));
        Assert.AreEqual(mockText.text, "An integer is a number with no decimal place");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void CheckTypeIntShouldFailNotNumber() {
        mockErrorWindow.SetActive(false);
        TypesInputChecker tic = new TypesInputChecker(mockCharacter, "IntInputField", mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(tic.CheckInput("z"));
        Assert.AreEqual(mockText.text, "An integer is a number with no decimal place");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void CheckTypeIntShouldPass() {
        mockErrorWindow.SetActive(false);
        TypesInputChecker tic = new TypesInputChecker(mockCharacter, "IntInputField", mockErrorWindow, mockText, mockAudioSource);
        Assert.IsTrue(tic.CheckInput("5"));
        Assert.IsFalse(mockErrorWindow.activeSelf);
    }

    [Test]
    public void CheckTypeFloatShouldFailNoDecimalPlace() {
        mockErrorWindow.SetActive(false);
        TypesInputChecker tic = new TypesInputChecker(mockCharacter, "FloatInputField", mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(tic.CheckInput("1"));
        Assert.AreEqual(mockText.text, "A float must have a decimal place. If a float is a whole number, its decimal is zero. eg. 1.0");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void CheckTypeFloatShouldFailNotNumber() {
        mockErrorWindow.SetActive(false);
        TypesInputChecker tic = new TypesInputChecker(mockCharacter, "FloatInputField", mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(tic.CheckInput("a"));
        Assert.AreEqual(mockText.text, "A float is a number with a decimal place and up to 7 digits.");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void CheckTypeFloatShouldFailIsDouble() {
        mockErrorWindow.SetActive(false);
        TypesInputChecker tic = new TypesInputChecker(mockCharacter, "FloatInputField", mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(tic.CheckInput("0.54795451131878784514"));
        Assert.AreEqual(mockText.text, "A number with more than 7 digits is a double, rather than a float.");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void CheckTypeFloatShouldPass() {
        mockErrorWindow.SetActive(false);
        TypesInputChecker tic = new TypesInputChecker(mockCharacter, "FloatInputField", mockErrorWindow, mockText, mockAudioSource);
        Assert.IsTrue(tic.CheckInput("1.65"));
        Assert.IsFalse(mockErrorWindow.activeSelf);
    }

    [Test]
    public void CheckTypeBooleanShouldFailNotBoolean() {
        mockErrorWindow.SetActive(false);
        TypesInputChecker tic = new TypesInputChecker(mockCharacter, "BooleanInputField", mockErrorWindow, mockText, mockAudioSource);
        Assert.IsFalse(tic.CheckInput("yes"));
        Assert.AreEqual(mockText.text, "A boolean can be either true or false");
        Assert.IsTrue(mockErrorWindow.activeSelf);
    }

    [Test]
    public void CheckTypeBooleanShouldPassTrue() {
        mockErrorWindow.SetActive(false);
        TypesInputChecker tic = new TypesInputChecker(mockCharacter, "BooleanInputField", mockErrorWindow, mockText, mockAudioSource);
        Assert.IsTrue(tic.CheckInput("true"));
        Assert.IsFalse(mockErrorWindow.activeSelf);
    }
      
    [Test]
    public void CheckTypeBooleanShouldPassFalse() {
        mockErrorWindow.SetActive(false);
        TypesInputChecker tic = new TypesInputChecker(mockCharacter, "BooleanInputField", mockErrorWindow, mockText, mockAudioSource);
        Assert.IsTrue(tic.CheckInput("false"));
        Assert.IsFalse(mockErrorWindow.activeSelf);
    }

    
}
