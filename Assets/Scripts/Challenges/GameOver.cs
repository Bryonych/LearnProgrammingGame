using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    AudioSource win;


    void Start() {
        win = GameObject.Find("Win").GetComponent<AudioSource>();
        if (win != null) { win.Play(); }
        Invoke("Quit", win.clip.length);
    }

    public void Quit() {
        #if UNITY_STANDALONE 
            Application.Quit(); 
        #endif
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; 
        #endif
    }
}