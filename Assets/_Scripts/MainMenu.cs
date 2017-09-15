using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [SerializeField]private Button startButton;
    [SerializeField]private Button quitButton;

    private void Start()
    {
        Button btn = startButton.GetComponent<Button>();
        Button btn2 = startButton.GetComponent<Button>();
        btn.onClick.AddListener(Ready);
        btn2.onClick.AddListener(Quit);
    }

    private void Ready()
    {
        SceneManager.LoadScene(1);
    }

    private void Quit()
    {
        Application.Quit();
    }

}
