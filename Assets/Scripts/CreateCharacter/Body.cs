using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Body<c> Extends attribute class for a body attribute
/// <summary>
public class Body : Attribute {
    
    public Body(Sprite sprite, RuntimeAnimatorController controller, Character character, GameObject go) 
            :base(sprite, controller, character, go, "Body"){ }



}