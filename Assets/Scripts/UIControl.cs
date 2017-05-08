using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour {

    public GameObject UI1;
    public GameObject UI2;

    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void showUI1()
    {
        UI1.SetActive(true);
    }

    private void hideUI1()
    {
        UI1.SetActive(false);
    }

    private void showUI2()
    {
        UI2.SetActive(true);
    }

    private void hideUI2()
    {
        UI2.SetActive(false);
    }

    public void switchToUI1()
    {
        showUI1();
        hideUI2();
    }

    public void switchToUI2()
    {
        hideUI1();
        showUI2();
    }

    public void hideAll()
    {
        hideUI1();
        hideUI2();
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
