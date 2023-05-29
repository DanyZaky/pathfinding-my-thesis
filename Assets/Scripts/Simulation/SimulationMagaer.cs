using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SimulationMagaer : MonoBehaviour
{
    [SerializeField] private TMP_InputField StartXPosInput, StartYPosInput, EndXPosInput, EndYPosInput;
    [SerializeField] private GameObject menuPanel, inputPanel;
    [SerializeField] private Button generateButton;

    private void Start()
    {
        menuPanel.SetActive(true);
        inputPanel.SetActive(false);

        generateButton.interactable = false;

        StartXPosInput.text = null;
        StartYPosInput.text = null;
        EndXPosInput.text = null;
        EndYPosInput.text = null;

    }

    private void Update()
    {
        if (!string.IsNullOrEmpty(StartXPosInput.text) && !string.IsNullOrEmpty(StartYPosInput.text) &&
            !string.IsNullOrEmpty(EndXPosInput.text) && !string.IsNullOrEmpty(EndYPosInput.text))
        {
            generateButton.interactable = true;
        }
    }

    public void OnClickThisLevelDesign(int level)
    {
        PlayerPrefs.SetInt("LevelDesign", level);

        menuPanel.SetActive(false);
        inputPanel.SetActive(true);
    }

    public void OnClickGenerate()
    {
        PlayerPrefs.SetString("StartXPos", StartXPosInput.text);
        PlayerPrefs.SetString("StartYPos", StartYPosInput.text);
        PlayerPrefs.SetString("EndXPos", EndXPosInput.text);
        PlayerPrefs.SetString("EndYPos", EndXPosInput.text);

        SceneManager.LoadScene(PlayerPrefs.GetInt("LevelDesign"));
    }

    public void OnClickBackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
