using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject developersBoard;
    [SerializeField] public GameObject ChoiceLvl;
    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackMenuWithChoiceLvl()
    {
        ChoiceLvl.SetActive(false);
    }
    public void OpenChoiceMenu()
    {
        ChoiceLvl.SetActive(true);
    }
    public void StartLvlOne()
    {
        SceneManager.LoadScene("BloodLevelScene");
    }
    public void OpendevelopersBoard()
    {
        developersBoard.SetActive(true);
    }

    public void BackMenuWithDevelopersBoard()
    {
        developersBoard.SetActive(false);
    }
}
