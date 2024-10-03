using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool pressed;
    public GameLogic gl;
    
    private void OnTriggerEnter2D(Collider2D other) {
        pressed = true;
        gl.CheckWin();
    }

    private void OnTriggerExit2D(Collider2D other) {
        pressed = false;
        gl.CheckWin();
    }
}
