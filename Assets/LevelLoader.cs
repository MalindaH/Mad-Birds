using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    private static int _nextLevelIndex = 1; // static: same variable for all levels
    private Enemy[] _enemies;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    private void Start() 
    {
        Debug.Log("start: "+transition);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Enemy enemy in _enemies)
        {
            if (enemy != null) return;
        }

        LoadNextLevel();

        // if (Input.GetMouseButtonDown(0)) {
        //     LoadNextLevel();
        // }
    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

        // StartCoroutine(MyCoroutine());
    }

    IEnumerator LoadLevel(int levelIndex) {
        Debug.Log("load level: "+transition+levelIndex);
        // transition.gameObject.SetActive(true);
        transition.SetTrigger("Start"); // play animation

        yield return new WaitForSeconds(transitionTime);

        if (levelIndex < SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene(levelIndex);
        } else {
            SceneManager.LoadScene("Menu");
        }
    }

    IEnumerator MyCoroutine()
    {
        Debug.Log("load level: "+transition);
        transition.SetTrigger("Start"); // play animation
       
        yield return new WaitForSeconds(transitionTime);

        _nextLevelIndex++;
        string nextLevelName = "Level" + _nextLevelIndex;
        SceneManager.LoadScene(nextLevelName);
    }
}
