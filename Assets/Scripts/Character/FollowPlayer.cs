using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>FollowPlayer<c> Points the camera at the character while moving.
/// <summary>
public class FollowPlayer : MonoBehaviour
{
    Transform player;

    void Awake() {
        player = GameObject.Find("CharacterParent").transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position + new Vector3(0, 0, -10);
    }

}
