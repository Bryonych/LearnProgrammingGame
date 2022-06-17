using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCharacter : MonoBehaviour
{

    public Character character;
    
    public void SelectBody(GameObject bd) {
        character.body = bd;
    }

}
