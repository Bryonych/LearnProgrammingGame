using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Transform player;

    void Awake() {
        player = GameObject.Find("CharacterParent").transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position + new Vector3(0, 0, -5);
    }

    // public void setPlayer(Transform p) {
    //     this.player = p;
    // }

}
