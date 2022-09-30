using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class <c>NavigationButton<c> Handles navigation between the character creation module. 
/// <summary>
public class NavigationButton : MonoBehaviour
{
    public GameObject Panel;
    public GameObject OldPanel;
    public Character character;
    FollowPlayer fp;

    // Changes the screen
    public void OpenPanel() {
        if (OldPanel != null) {
            OldPanel.SetActive(false);
        }
        if (Panel != null) {
            Panel.SetActive(true);
        }
        if (Panel.name == "LessonPanel") {
            Panel.transform.GetChild(2).gameObject.SetActive(true);
            Panel.transform.GetChild(1).gameObject.SetActive(false);
        }
    } 

    // Resets the body game object for change to new body
    public void resetBody() {
        SpriteRenderer sr = character.body.GetComponent<SpriteRenderer>();
        sr.sprite = null; 
        SpriteRenderer srb = character.bottoms.GetComponent<SpriteRenderer>();
        srb.sprite = null; 
        character.body.SetActive(true);
        character.bottoms.SetActive(true);
    }

    // Stops displaying character game objects. 
    public void RemoveCharacter() {
        print("number of parts: " + character.getParts().Count);
        foreach (GameObject go in character.getParts()) {
            go.SetActive(false);
        }
    }

    // Displays character objects. 
    public void AddCharacter() {
        print("number of parts: " + character.getParts().Count);
         foreach (GameObject go in character.getParts()) {
            go.SetActive(true);
        }
    }

    // Navigates to the city scene and sets up the components on the character for isometric and movement. 
    public void LoadCityScene() {
        foreach (GameObject go in character.getParts()) {
            go.AddComponent<PlayerRenderer>().character = character;
            go.AddComponent<PlayerMovementController>();
            go.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            go.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            Animator anim = GameObject.Find(go.name).GetComponent<Animator>();
            anim.enabled = true;
            anim.runtimeAnimatorController = character.GetController(go);
        }
        // Move to the correct location
        character.body.transform.parent.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        character.body.transform.parent.position = new Vector3(-7.0f, 0.0f, 0.0f);
        SceneManager.LoadScene(1);
    }

}
