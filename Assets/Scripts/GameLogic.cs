using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public Button[] buttons;

    public void CheckWin() {
        foreach(Button button in buttons) {
            if(!button.pressed) {
                return;
            }
        }

        // All buttons are pressed, win condition is passed
        // TODO
        Debug.Log("WIN");
    }
}
