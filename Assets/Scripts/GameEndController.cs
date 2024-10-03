using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndController : MonoBehaviour
{
    public void MainMenu() {
        SceneManager.LoadScene(0);
    }
}
