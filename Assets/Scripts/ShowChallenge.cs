using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowChallenge : MonoBehaviour
{
    
    public GameObject canvas;
    public GameObject firstPanel;
    public Character character;
    public int challengeNumber;


    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        firstPanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D player) {

        if (player.gameObject.tag == "Player") {
            if (character.getChallengeNumber() == challengeNumber) {
                canvas.SetActive(true);
                firstPanel.SetActive(true);
                foreach (GameObject go in character.getParts()) {
                    PlayerMovementController pmc = go.GetComponent(typeof(PlayerMovementController)) as PlayerMovementController;
                    pmc.movementSpeed = 0;
                }
            }
        }
    }
}
