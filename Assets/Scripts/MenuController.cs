using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menu;
    public GameObject tutorial;

    private bool fadingOut = false;
    public float fadeTime = 1.2f;
    public PostProcessVolume blur;
    private DepthOfField dof;

    private void Start() {
        dof = blur.profile.GetSetting<DepthOfField>();
    }

    private void FixedUpdate() {
        if(fadingOut) {
            dof.focusDistance.value += Time.deltaTime*1.5f;
        }
    }

    // Fades out the buttons and blur effect, waits a little, then loads the Blackjack scene
    public void StartGame() {
        fadingOut = true;
        menu.SetActive(false);
        StartCoroutine(WaitForFade());
    }

    public IEnumerator WaitForFade() {
        yield return new WaitForSeconds(fadeTime);

        SceneManager.LoadScene(1);
    }

    public void SetTutorialPopup(bool visibility) {
        tutorial.SetActive(visibility);
    }
}
