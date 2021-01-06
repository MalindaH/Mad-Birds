using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Timers;

public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1; // static: same variable for all levels
    private Enemy[] _enemies;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    void Update()
    {
        foreach (Enemy enemy in _enemies)
        {
            if (enemy != null) return;
        }

        StartCoroutine(MyCoroutine());    
    }

    public static IEnumerator MyCoroutine()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
       
        yield return new WaitForSeconds(2);

        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        _nextLevelIndex++;
        string nextLevelName = "Level" + _nextLevelIndex;
        SceneManager.LoadScene(nextLevelName);
    }
}
