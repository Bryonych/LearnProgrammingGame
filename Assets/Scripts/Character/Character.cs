using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject {

    private new string name;
    private string agentNumber;

    public GameObject body;
    public GameObject hair;
    public GameObject hat;
    public GameObject top;
    public GameObject bottoms;
    public GameObject shoes;

    RuntimeAnimatorController bodyController;
    RuntimeAnimatorController hairController;
    RuntimeAnimatorController hatController;
    RuntimeAnimatorController topController;
    RuntimeAnimatorController bottomsController;
    RuntimeAnimatorController shoesController;

    private int challengeNumber = 0;    

    public GameObject challengeCanvas;

    List<GameObject> parts = new List<GameObject>();

    public bool hasHair = false;
    public bool hasHat = false;
    public bool hasGlasses = false;
    public bool hasMask = false;
    public bool hasShoes = false;

    public char bodyShape;

    public void addPart(GameObject part) {
        parts.Add(part);
    }

    public void resetParts() {
        parts = new List<GameObject>();
    }

    public void removePart(GameObject part) {
        parts.Remove(part);
    }

    public List<GameObject> getParts() {
        return parts;
    }

    public void increaseChallengeNumber() {
        challengeNumber +=1;
    }

    public int getChallengeNumber() {
        return challengeNumber;
    }

    public void resetChallengeNumber() {
        challengeNumber = 0;
    }

    public GameObject getPart(string name) {
        switch(name) {
            case "Body":
                return body;
            case "Bottoms":
                return bottoms;
            case "Hair":
                return hair;
            case "Top":
                return top;
            case "Hat":
                return hat;
            case "Shoes":
                return shoes;
            default:
                return null;
        }
    }

    public void setPart(string name, GameObject go) {
         switch(name) {
            case "Body":
                this.body = go;
                break;
            case "Bottoms":
                this.bottoms = go;
                break;
            case "Hair":
                this.hair = go;
                break;
            case "Top":
                this.top = go;
                break;
            case "Hat":
                this.hat = go;
                break;
            case "Shoes":
                this.shoes = go;
                break;
        }
    }

    public void setController(string part, RuntimeAnimatorController c) {
        if (part == "Body") { bodyController = c; }
        else if (part == "Hair") { hairController = c; }
        else if (part == "Hat") { hatController = c; }
        else if (part == "Top") { topController = c; }
        else if (part == "Bottoms") { bottomsController = c; }
        else if (part == "Shoes") { shoesController = c; }
        else { }
    }

    public RuntimeAnimatorController GetController(GameObject go) {
        if (go.name == "Body") { return bodyController; }
        else if (go.name == "Hair") { return hairController; }
        else if (go.name == "Hat") { return hatController; }
        else if (go.name == "Top") { return topController; }
        else if (go.name == "Bottoms") { return bottomsController; }
        else if (go.name == "Shoes") { return shoesController; }
        else { return null; }
    }

    public void setName(string name) {
        this.name = name;
    }

    public void setAgentNumber(string age) {
        this.agentNumber = age;
    }

    public string getName() {
        return name;
    }

    public string getAgentNumber() {
        return agentNumber;
    }

}
