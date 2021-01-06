using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel() {

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

        // StartCoroutine(LevelController.MyCoroutine());
    }

    IEnumerator LoadLevel(int levelIndex) {
        // play animation
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        if (levelIndex < SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene(levelIndex);
        }
    }
}
