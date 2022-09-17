using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConditionalDropDown : MonoBehaviour
{
    private int codeLineCount = 0;
    public TextMeshProUGUI errorText;
    public GameObject errorPanel;
    public TextMeshProUGUI displaySelected;
    public TMP_Dropdown selected;
    
    public void OnSelect(TMP_Dropdown selection) {
        int index = selection.value;
        if (index == codeLineCount) {
            displaySelected.text += selection.captionText + "\n";
            codeLineCount += 1;
        }
        else {

        }
        if (codeLineCount == 5) {
            //TODO show direction
        }
    }
    
    void Start() {
        selected.onValueChanged.AddListener(delegate {OnSelect(selected);});

    }
}
