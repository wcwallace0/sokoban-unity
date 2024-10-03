using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public Button[] buttons;
    private bool won;

    private void Update() {
        if(!won && Input.GetKeyDown(KeyCode.R)) {
            // Reload Scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void CheckWin() {
        foreach(Button button in buttons) {
            if(!button.pressed) {
                won = false;
                return;
            }
        }

        // All buttons are pressed, win condition is passed
        // TODO
        Debug.Log("WIN");
        won = true;
    }
}
