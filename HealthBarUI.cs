using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    private HealthSystem playerHealthSystem;
    private Image playerHealthBarUI;

    [SerializeField] private Player player;
    [SerializeField] private GameObject panelKalah;

    public void Setup(HealthSystem playerHealthSystem)
    {
        this.playerHealthSystem = playerHealthSystem;

        playerHealthSystem.OnHealthChanged += PlayerHealthSystem_OnHealthChanged;
    }
    private void Awake()
    {
        playerHealthBarUI = transform.Find("Image").GetComponent<Image>();

        panelKalah.SetActive(false);
    }

    private void PlayerHealthSystem_OnHealthChanged(object sender, System.EventArgs e)
    {
        playerHealthBarUI.fillAmount = playerHealthSystem.GetCurrentHealth();

        if(playerHealthSystem.GetHP() == 0)
        {
            Destroy(player.gameObject);
            panelKalah.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
