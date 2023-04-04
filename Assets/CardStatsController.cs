using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardStatsController : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    public Image armour;
    public Enemy enemy;
    public GameObject player;
    private PlayerHealth playerHealthScript;

    void Start()
    {
        GameObject waveText = GameObject.Find("WaveText");
        textComponent = waveText.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Update wave text
        textComponent.text = "Wave: " + Enemy.waveNum.ToString();

        // Update armour status
        playerHealthScript = player.GetComponent<PlayerHealth>();
        bool armorOn = playerHealthScript.damageStart == 0;

        // Update armor colour
        if (armorOn)
        {
            armour.color = new Color(0, 0, 255, 1);
        } else
        {
            armour.color = new Color(255, 0, 0, 1);
        }
    }
}
