using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class TestBehaviour {


    [Test]
    public void CharacterShouldMoveSouthWest() {
        Movement m = new Movement(2.5f);
        Vector2 initialPos = new Vector2(0.0f, 0.0f);
        Vector2 inputVector = new Vector2(0.0f, -1.0f);
        Vector2 newPos = m.calculate(initialPos, inputVector);
        Assert.IsTrue(newPos.x < initialPos.x && newPos.y < initialPos.y);
    }

    [Test]
    public void CharacterShouldMoveNorthEast() {
        Movement m = new Movement(2.5f);
        Vector2 initialPos = new Vector2(0.0f, 0.0f);
        Vector2 inputVector = new Vector2(0.0f, 1.0f);
        Vector2 newPos = m.calculate(initialPos, inputVector);
        Assert.IsTrue(newPos.x > initialPos.x && newPos.y > initialPos.y);
    }
    
    [Test]
    public void CharacterShouldMoveNorthWest() {
        Movement m = new Movement(2.5f);
        Vector2 initialPos = new Vector2(0.0f, 0.0f);
        Vector2 inputVector = new Vector2(-1.0f, 0.0f);
        Vector2 newPos = m.calculate(initialPos, inputVector);
        Assert.IsTrue(newPos.x < initialPos.x && newPos.y > initialPos.y);
    }

    [Test]
    public void CharacterShouldMoveSouthEast() {
        Movement m = new Movement(2.5f);
        Vector2 initialPos = new Vector2(0.0f, 0.0f);
        Vector2 inputVector = new Vector2(1.0f, 0.0f);
        Vector2 newPos = m.calculate(initialPos, inputVector);
        Assert.IsTrue(newPos.x > initialPos.x && newPos.y < initialPos.y);
    }
}