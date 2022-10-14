using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;
using NSubstitute;

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

    [Test]
    public void ShouldAddGameObjectBodyPartToCharacterAndRemoveIt() {
        mockCharacter.resetParts();
        mockCharacter.addPart(mockGo);
        Assert.AreEqual(mockCharacter.getParts().Count, 1);
        mockCharacter.removePart(mockGo);
        Assert.AreEqual(mockCharacter.getParts().Count, 0);
    }

    [Test]
    public void ShouldAddGameObjectToCharacterPartsAndThenRemoveAllParts() {
        mockCharacter.resetParts();
        mockCharacter.addPart(mockGo);
        Assert.AreEqual(mockCharacter.getParts().Count, 1);
        mockCharacter.resetParts();
        Assert.AreEqual(mockCharacter.getParts().Count, 0);
    }

    [Test]
    public void ShouldIncreaseTheCharacterChallengeNumberThenResetIt() {
        Assert.AreEqual(mockCharacter.getChallengeNumber(), 0);
        mockCharacter.increaseChallengeNumber();
        Assert.AreEqual(mockCharacter.getChallengeNumber(), 1);
        mockCharacter.resetChallengeNumber();
        Assert.AreEqual(mockCharacter.getChallengeNumber(), 0);
    }

    [Test]
    public void ShouldSetTheCharactersBodyPart() {
        mockCharacter.setPart("Body", mockGo);
        Assert.AreEqual(mockCharacter.getPart("Body"), mockGo);
    }

    [Test]
    public void ShouldSetAgentName() {
        mockCharacter.setName("bing");
        Assert.AreEqual(mockCharacter.getName(), "bing");
    }

    
    [Test]
    public void ShouldSetAgentNumber() {
        mockCharacter.setAgentNumber("7");
        Assert.AreEqual(mockCharacter.getAgentNumber(), "7");
    }

    [Test]
    public void ShouldCreateNewBodyAndAddToCharacter() {
        mockGo.AddComponent<SpriteRenderer>();
        RuntimeAnimatorController rac = Substitute.For<RuntimeAnimatorController>();
        Body b = new Body(null, rac, mockCharacter, mockGo);
        b.createAttribute(true);
        Assert.IsTrue(mockGo.activeSelf);
        Assert.AreEqual(mockCharacter.getPart("Body"), mockGo);
    }

    [Test]
    public void ShouldAddHatToCharacter() {
        mockCharacter.bodyShape = 's';
        mockGo.AddComponent<SpriteRenderer>();
        RuntimeAnimatorController rac = Substitute.For<RuntimeAnimatorController>();
        Sprite[] mockSprites = {null, null};
        RuntimeAnimatorController[] mockRac = {rac};
        Hat h = new Hat(mockSprites, mockRac, mockCharacter, mockGo);
        h.checkLogicHat("\"top hat\"", mockErrorWindow, mockText, mockAudioSource, mockAudioSource);
        Assert.IsFalse(mockGo.activeSelf);
        Assert.AreEqual(mockCharacter.getPart("Hat"), mockGo);
    }

    [Test]
    public void ShouldAddHairToCharacter() {
        mockCharacter.bodyShape = 's';
        mockGo.AddComponent<SpriteRenderer>();
        RuntimeAnimatorController rac = Substitute.For<RuntimeAnimatorController>();
        Sprite[] mockSprites = {null, null, null};
        RuntimeAnimatorController[] mockRac = {rac, rac};
        Hair h = new Hair(mockSprites, mockRac, mockCharacter, mockGo);
        h.checkLogicHair("\"dreads\"", mockErrorWindow, mockText, mockAudioSource, mockAudioSource);
        Assert.IsFalse(mockGo.activeSelf);
        Assert.AreEqual(mockCharacter.getPart("Hair"), mockGo);
    }
    
    [Test]
    public void ShouldAddShoesToCharacter() {
        mockCharacter.bodyShape = 's';
        mockGo.AddComponent<SpriteRenderer>();
        RuntimeAnimatorController rac = Substitute.For<RuntimeAnimatorController>();
        Sprite[] mockSprites = {null, null, null};
        RuntimeAnimatorController[] mockRac = {rac, rac};
        Shoes h = new Shoes(mockSprites, mockRac, mockCharacter, mockGo);
        h.checkLogicShoes("\'s\'", mockErrorWindow, mockText, mockAudioSource, mockAudioSource);
        Assert.IsFalse(mockGo.activeSelf);
        Assert.AreEqual(mockCharacter.getPart("Shoes"), mockGo);
    }

    [Test]
    public void ShouldAddTopToCharacter() {
        mockCharacter.bodyShape = 's';
        mockGo.AddComponent<SpriteRenderer>();
        RuntimeAnimatorController rac = Substitute.For<RuntimeAnimatorController>();
        Sprite[] mockSprites = {null, null, null};
        RuntimeAnimatorController[] mockRac = {rac, rac};
        Top h = new Top(mockSprites, mockRac, mockCharacter, mockGo);
        h.checkLogicTop("false", mockErrorWindow, mockText, mockAudioSource, mockAudioSource);
        Assert.IsFalse(mockGo.activeSelf);
        Assert.AreEqual(mockCharacter.getPart("Top"), mockGo);
    }

    [Test]
    public void ShouldAddBottomsToCharacter() {
        mockCharacter.bodyShape = 's';
        mockGo.AddComponent<SpriteRenderer>();
        RuntimeAnimatorController rac = Substitute.For<RuntimeAnimatorController>();
        RuntimeAnimatorController[] mockRac = {rac, rac};
        Bottoms h = new Bottoms(null, rac, mockCharacter, mockGo);
        h.setSprites(null, null, null, null, mockRac);
        h.checkLogicBottoms("false", mockErrorWindow, mockText, mockAudioSource, mockAudioSource);
        Assert.IsFalse(mockGo.activeSelf);
        Assert.AreEqual(mockCharacter.getPart("Bottoms"), mockGo);
    }

    [Test]
    public void ShouldAddHairToCharacter2() {
        mockCharacter.bodyShape = 'h';
        mockGo.AddComponent<SpriteRenderer>();
        RuntimeAnimatorController rac = Substitute.For<RuntimeAnimatorController>();
        Sprite[] mockSprites = {null, null, null};
        RuntimeAnimatorController[] mockRac = {rac, rac, rac};
        Hair h = new Hair(mockSprites, mockRac, mockCharacter, mockGo);
        h.checkLogicHair("\"short black\"", mockErrorWindow, mockText, mockAudioSource, mockAudioSource);
        Assert.IsFalse(mockGo.activeSelf);
        Assert.AreEqual(mockCharacter.getPart("Hair"), mockGo);
    }

    [Test]
    public void ShouldAddTopToCharacter2() {
        mockCharacter.bodyShape = 'h';
        mockGo.AddComponent<SpriteRenderer>();
        RuntimeAnimatorController rac = Substitute.For<RuntimeAnimatorController>();
        Sprite[] mockSprites = {null, null, null};
        RuntimeAnimatorController[] mockRac = {rac, rac, rac};
        Top h = new Top(mockSprites, mockRac, mockCharacter, mockGo);
        h.checkLogicTop("false", mockErrorWindow, mockText, mockAudioSource, mockAudioSource);
        Assert.IsFalse(mockGo.activeSelf);
        Assert.AreEqual(mockCharacter.getPart("Top"), mockGo);
    }

    [Test]
    public void ShouldAddShoesToCharacter2() {
        mockCharacter.bodyShape = 'h';
        mockGo.AddComponent<SpriteRenderer>();
        RuntimeAnimatorController rac = Substitute.For<RuntimeAnimatorController>();
        Sprite[] mockSprites = {null, null, null, null};
        RuntimeAnimatorController[] mockRac = {rac, rac, rac};
        Shoes h = new Shoes(mockSprites, mockRac, mockCharacter, mockGo);
        h.checkLogicShoes("\'s\'", mockErrorWindow, mockText, mockAudioSource, mockAudioSource);
        Assert.IsFalse(mockGo.activeSelf);
        Assert.AreEqual(mockCharacter.getPart("Shoes"), mockGo);
    }

    
    [Test]
    public void ShouldAddHatToCharacter2() {
        mockCharacter.bodyShape = 'h';
        mockGo.AddComponent<SpriteRenderer>();
        RuntimeAnimatorController rac = Substitute.For<RuntimeAnimatorController>();
        Sprite[] mockSprites = {null, null};
        RuntimeAnimatorController[] mockRac = {rac, rac};
        Hat h = new Hat(mockSprites, mockRac, mockCharacter, mockGo);
        h.checkLogicHat("\"cap\"", mockErrorWindow, mockText, mockAudioSource, mockAudioSource);
        Assert.IsFalse(mockGo.activeSelf);
        Assert.AreEqual(mockCharacter.getPart("Hat"), mockGo);
    }

    [Test]
    public void ShouldAddHairToCharacter3() {
        mockCharacter.bodyShape = 'h';
        mockGo.AddComponent<SpriteRenderer>();
        RuntimeAnimatorController rac = Substitute.For<RuntimeAnimatorController>();
        Sprite[] mockSprites = {null, null, null};
        RuntimeAnimatorController[] mockRac = {rac, rac, rac, rac};
        Hair h = new Hair(mockSprites, mockRac, mockCharacter, mockGo);
        h.checkLogicHair("\"short orange\"", mockErrorWindow, mockText, mockAudioSource, mockAudioSource);
        Assert.IsFalse(mockGo.activeSelf);
        Assert.AreEqual(mockCharacter.getPart("Hair"), mockGo);
    }
    
}
