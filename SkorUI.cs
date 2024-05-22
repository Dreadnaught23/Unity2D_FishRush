using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkorUI : MonoBehaviour
{

    private TextMeshProUGUI poinText;
    private PointSystem pointSystem;

    [SerializeField] private GameObject panelMenang;

    public void Setup(PointSystem pointSystem)
    {
        this.pointSystem = pointSystem;

        pointSystem.OnPointSystemChanged += PointSystem_OnPointSystemChanged;
    }

    private void PointSystem_OnPointSystemChanged(object sender, System.EventArgs e)
    {
        poinText.text = pointSystem.GetCurrenttPoint().ToString();

        if(pointSystem.GetCurrenttPoint() >= 100)
        {
            panelMenang.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void Awake()
    {
        poinText = transform.Find("Poin").GetComponent<TextMeshProUGUI>();

        poinText.text = 0.ToString();
        panelMenang.SetActive(false);
    }



}
