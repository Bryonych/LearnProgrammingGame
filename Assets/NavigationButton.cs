using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void MoveCharacterToMiddle() {
        GameObject body = GameObject.Find("Body");
        body.transform.position = new Vector3(0, 0, 0);
        GameObject bottoms = GameObject.Find("Bottoms");
        bottoms.transform.position = new Vector3(0, 0, 0);
    }

    public void RemoveCharacter() {
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
    

}
