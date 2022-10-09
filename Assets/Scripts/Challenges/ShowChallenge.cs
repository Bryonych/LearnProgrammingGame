using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>ShowChallenge<c> Displays a challenge if the character walks into a 
/// trigger that has a matching challenge number to the one stored in the 
/// character class. 
/// <summary>
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

    // Called when the player collides with the challenge area
    void OnTriggerEnter2D(Collider2D player) {

        if (player.gameObject.tag == "Player") {
            // Check if this is the correct order
            if (character.getChallengeNumber() == challengeNumber) {
                // Final challenge
                if (character.getChallengeNumber() == 4) {
                    GameObject.Find("ScarySound").GetComponent<AudioSource>().Play();
                }
                canvas.SetActive(true);
                firstPanel.SetActive(true);
                // Stop the character from moving. 
                foreach (GameObject go in character.getParts()) {
                    PlayerMovementController pmc = go.GetComponent(typeof(PlayerMovementController)) as PlayerMovementController;
                    pmc.UpdateMovementSpeed(0.0f);
                }
            }
        }
    }
}
