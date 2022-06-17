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


  
}
