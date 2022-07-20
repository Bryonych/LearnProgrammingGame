using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NavigationButton : MonoBehaviour
{
    public GameObject Panel;
    public GameObject OldPanel;
    public Character character;

    public void OpenPanel() {
        if (OldPanel != null) {
            OldPanel.SetActive(false);
        }
        if (Panel != null) {
            Panel.SetActive(true);
        }
        
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
            go.transform.localScale = new Vector3(go.transform.localScale.x - 1.0f, go.transform.localScale.y - 1.0f, go.transform.localScale.z);
            go.transform.position = new Vector3(go.transform.position.x - 1.0f, go.transform.position.y, go.transform.position.z);
            Animator anim = GameObject.Find(go.name).GetComponent<Animator>();
            anim.enabled = true;
            anim.runtimeAnimatorController = character.GetController(go);
        }
        SceneManager.LoadScene(1);
    }
    

}
