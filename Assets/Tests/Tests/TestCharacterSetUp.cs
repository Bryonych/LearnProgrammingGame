using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class TestCharacterSetUp
{   
    

    [Test]
    public void  AddShoesHandlesErrorCaseNoQuotes() {
        // GameObject ew = new GameObject();
        // TextMeshProUGUI t = new TextMeshProUGUI();
        // ew.SetActive(false);
        // AudioSource ast = new AudioSource();
        // Shoes s = new Shoes(null, null, null, null, null, null, null); 
        // Assert.IsFalse(s.checkLogicShoes("s", ew, t, ast, ast));
        // Assert.AreEqual(t.text, "Chars are in single quotes: ' '");
        // Assert.IsTrue(ew.activeSelf);
    }

    // A Test bhaves as an ordinary method
    // [Test]
    // public void NewTestScriptSimplePasses()
    // {
    //     // Use the Assert class to test conditions
    // }

    // // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // // `yield return null;` to skip a frame.
    // [UnityTest]
    // public IEnumerator NewTestScriptWithEnumeratorPasses()
    // {
    //     // Use the Assert class to test conditions.
    //     // Use yield to skip a frame.
    //     yield return null;
    // }
}
