using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject menu;
    public GameObject learn;
    public GameObject credit;

    // Start is called before the first frame update
    void Start()
    {
        ShowScreen(menu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void HowToPlay()
    {
        ShowScreen(learn);
    }

    public void GameCredits()
    {
        ShowScreen(credit);
    }

    public void BackToStart()
    {
        ShowScreen(menu);
    }

    private void ShowScreen(GameObject gameObjectToShow)
    {
        menu.SetActive(false);
        learn.SetActive(false);
        credit.SetActive(false);

        gameObjectToShow.SetActive(true);
    }
}
