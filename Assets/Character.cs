using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject {

    public new string name;
    public int age;

    public GameObject body;
    public GameObject hair;
    public GameObject hat;
    public GameObject glasses;
    public GameObject mask;
    public GameObject top;
    public GameObject bottoms;
    public GameObject shoes;

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

    public void removePart(GameObject part) {
        parts.Remove(part);
    }

    public List<GameObject> getParts() {
        return parts;
    }
  
}
