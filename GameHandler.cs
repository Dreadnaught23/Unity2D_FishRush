using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{

    [SerializeField] private Button retryBT;
    [SerializeField] private Button retryB2;

    [SerializeField] private Button mulaiBT;
    [SerializeField] private GameObject mulaiPanel;

    private void Awake()
    {
        Time.timeScale = 0;

        retryBT.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        retryB2.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        mulaiBT.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            Destroy(mulaiPanel.gameObject);
        });

       
    }
}
