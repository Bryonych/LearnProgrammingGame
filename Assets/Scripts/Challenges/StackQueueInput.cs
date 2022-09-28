using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StackQueueInput : MonoBehaviour
{
    public GameObject queue;
    public GameObject stack;
    public TMP_InputField currentField;
    public GameObject[] roadBlocks;
    public GameObject[] boxes;
    public GameObject[] destroy;
    public GameObject errorWindow;
    public TextMeshProUGUI errorText;
    public Character character;
    public GameObject displayWindow;
    AudioSource beep;
    AudioSource bomp;

    public void OnStoppedEditing(string text) {
        errorWindow.SetActive(false);
        CheckChallengeLogic ccl = new CheckChallengeLogic(errorWindow, errorText, bomp);
        if (currentField.name == "First" && ccl.CheckStackAndQueueOrder(currentField.name, text)) {
            destroy[1].SetActive(false);
            if (beep != null) { beep.Play(); }
            StartCoroutine(Remove(roadBlocks, queue, destroy[0]));
            stack.SetActive(true);
        }
        else if (currentField.name == "Second" && ccl.CheckStackAndQueueOrder(currentField.name, text)) {
            if (beep != null) { beep.Play(); }
            CloseChallenge();
            StartCoroutine(Remove(boxes, displayWindow, destroy[2]));
        }
    }

    public IEnumerator Remove(GameObject[] objects, GameObject screen, GameObject obj) {
        foreach(GameObject go in objects) {
            go.SetActive(false);
            yield return new WaitForSeconds(1);
        }
        Destroy(obj);
        Destroy(screen);
    }

    public void CloseChallenge() {           
        foreach (GameObject go in character.getParts()) {
            PlayerMovementController pmc = go.GetComponent(typeof(PlayerMovementController)) as PlayerMovementController;
            pmc.movementSpeed = 2.5f;
        }
        character.increaseChallengeNumber();
    }


    // Start is called before the first frame update
    void Start()
    {
        currentField.onEndEdit.AddListener(delegate {OnStoppedEditing(currentField.text);});
        if (currentField != null) { currentField.Select(); }
        beep = GameObject.Find("Beep").GetComponent<AudioSource>();
        bomp = GameObject.Find("Bomp").GetComponent<AudioSource>();
    }
}
