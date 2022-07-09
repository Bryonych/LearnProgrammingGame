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
        SceneManager.LoadScene(1);
    }
    

}
