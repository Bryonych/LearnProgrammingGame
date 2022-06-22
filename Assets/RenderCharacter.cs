using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderCharacter : MonoBehaviour
{

    public Character character;
    private SpriteRenderer sr;
    private SpriteRenderer srb;

    // private void Awake() {
    //     sr = GetComponent<SpriteRenderer>();
    //     if (character != null) {
    //         sr.sprite = character.body.sprite;
    //     }
    // }
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (character != null) {
    //         sr.sprite = character.body.sprite;
    //     }
    //     if (character.bottoms != null) {
    //         srb = character.bottoms.GetComponent<SpriteRenderer>();
    //         srb.sprite = character.bottoms.sprite;
    //     }
    // }
}
