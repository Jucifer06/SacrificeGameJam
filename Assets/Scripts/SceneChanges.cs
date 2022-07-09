using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanges : MonoBehaviour
{
    public Animator transition;
    public float animationTime = 0.5f;

    public void GameScene01()
    {
        CursorVisible();
        if (StaticVariables.easyMode)
        {
            StartCoroutine(LoadScene("GameSceneEasy"));
        }
        else
        {
            StartCoroutine(LoadScene("GameScene01"));
        }
    }
    public void ComicScene()
    {
        CursorVisible();
        StartCoroutine(LoadScene("ComicScene"));
    }

    public void MenuScene()
    {
        CursorVisible();
        StartCoroutine(LoadScene("MenuScene"));
    }

    public void GameOverScene()
    {
        CursorVisible();
        StartCoroutine(LoadScene("GameOverScene"));
    }

    private IEnumerator LoadScene(string sceneName)
    {
        transition.SetTrigger("exit_scene");
        yield return new WaitForSeconds(animationTime);
        SceneManager.LoadScene(sceneName);
    }
    private void CursorVisible()
    {
        Cursor.visible = true;
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }
}
