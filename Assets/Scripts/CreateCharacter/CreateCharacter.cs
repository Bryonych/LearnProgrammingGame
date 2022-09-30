using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>CreateCharacter<c> Listens for input in the datatypes challenge
/// and passes to relevant classes to create attributes. 
/// <summary>
public class CreateCharacter : MonoBehaviour
{

    public Character character;
    GameObject body;
    GameObject bottoms;
    public RuntimeAnimatorController controller;
    
    // Passes to the Body class to create the atttribute.
    public void SelectBody(Sprite bd) {
        character.resetParts();
        character.resetChallengeNumber();
        Body bod = new Body(bd, controller, character, body);
        bod.createAttribute(true);
        DontDestroyOnLoad(character.body.transform.parent);
        if (bd.name.StartsWith("SH")) {
            character.bodyShape = 's';
        }
        else {
            character.bodyShape = 'h';
        }
    }

    // Pases to the Bottoms class to create attribute
    public void SelectBottoms(Sprite b) {
        Bottoms bot = new Bottoms(b, controller, character, bottoms);
        bot.createAttribute(true);
        DontDestroyOnLoad(character.bottoms.transform.parent);
    }

}
