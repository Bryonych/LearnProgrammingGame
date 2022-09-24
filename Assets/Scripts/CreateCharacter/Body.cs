using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : Attribute {
    
    public Body(Sprite sprite, RuntimeAnimatorController controller, Character character, GameObject go) 
            :base(sprite, controller, character, go, "Body"){ }



}