using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationButton : MonoBehaviour
{
    public GameObject Panel;
    public GameObject OldPanel;

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
        GameObject character = GameObject.Find("Body");
        character.SetActive(false);
        GameObject shorts = GameObject.Find("Bottoms");
        shorts.SetActive(false);
    }

    public void AddCharacter() {
        GameObject character = GameObject.Find("Body");
        character.SetActive(true);
        GameObject shorts = GameObject.Find("Bottoms");
        shorts.SetActive(true);
    }
    

}
