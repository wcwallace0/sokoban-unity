using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool pressed;
    public GameLogic gl;

    public AudioSource audioSource;
    public AudioClip buttonSFX;
    
    private void OnTriggerEnter2D(Collider2D other) {
        pressed = true;
        // play button sfx
        audioSource.clip = buttonSFX;
        audioSource.Play();
        gl.CheckWin();
    }

    private void OnTriggerExit2D(Collider2D other) {
        pressed = false;
        gl.CheckWin();
    }
}
