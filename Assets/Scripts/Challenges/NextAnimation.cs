using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextAnimation : MonoBehaviour
{
    public void PlayNext(string name) {
        gameObject.GetComponent<Animator>().Play(name);
    }
}
