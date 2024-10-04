using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public Button[] buttons;
    public GameObject winLock;
    private bool won;
    private string levelName;
    private int level;

    public Skeleton[] skeletons;
    public AudioSource audioSource;
    public AudioClip dieSFX;

    private void Start() {
        levelName = SceneManager.GetActiveScene().name;
        level = (int) char.GetNumericValue(levelName[^1]);
    }

    private void Update() {
        if(!won && Input.GetKeyDown(KeyCode.R)) {
            RestartLevel();
        }
    }

    private void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void KillPlayer(GameObject player) {
        StartCoroutine(KillPlayerCoroutine(player));
    }

    private IEnumerator KillPlayerCoroutine(GameObject player) {
        audioSource.clip = dieSFX;
        audioSource.Play();
        Destroy(player);

        yield return new WaitForSeconds(2f);
        RestartLevel();
    }

    public void CheckWin() {
        foreach(Button button in buttons) {
            if(!button.pressed) {
                won = false;
                if(winLock) {
                    winLock.SetActive(true);
                }
                return;
            }
        }

        // All buttons are pressed, win condition is passed
        // Deactivate the lock so the player can move to the next level
        won = true;
        winLock.SetActive(false);
    }

    // Player enters the win area (behind lock)
    private void OnTriggerEnter2D(Collider2D other) {
        SceneManager.LoadScene(level+1);
    }

    public void MoveSkeletons() {
        foreach(Skeleton skele in skeletons) {
            skele.Move();
        }
    }
}
