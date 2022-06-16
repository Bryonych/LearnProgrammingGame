using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCharacterButton : MonoBehaviour
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
}
