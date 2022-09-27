using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCharacter : MonoBehaviour
{

    public Character character;
    GameObject body;
    GameObject bottoms;
    public RuntimeAnimatorController controller;
    
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

    public void SelectBottoms(Sprite b) {
        Bottoms bot = new Bottoms(b, controller, character, bottoms);
        bot.createAttribute(true);
        DontDestroyOnLoad(character.bottoms.transform.parent);
    }

}
