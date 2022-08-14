using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NavigationButton : MonoBehaviour
{
    public GameObject Panel;
    public GameObject OldPanel;
    public Character character;
    FollowPlayer fp;

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

    public void resetBody() {
        SpriteRenderer sr = character.body.GetComponent<SpriteRenderer>();
        sr.sprite = null; 
        character.body.SetActive(true);
    }

    public void RemoveCharacter() {
        print("number of parts: " + character.getParts().Count);
        foreach (GameObject go in character.getParts()) {
            go.SetActive(false);
        }
    }

    public void AddCharacter() {
        print("number of parts: " + character.getParts().Count);
         foreach (GameObject go in character.getParts()) {
            go.SetActive(true);
        }
    }

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

        character.body.transform.parent.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        character.body.transform.parent.position = new Vector3(-7.0f, 0.0f, 0.0f);
        SceneManager.LoadScene(1);
    }
    

}
