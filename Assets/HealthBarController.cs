using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public PlayerHealth playerHealth; // Your PlayerHealth script
    public Image healthBarFill;
    RectTransform rectTransform;
    Vector2 sizeDelta;
    public float width;

    private void Start()
    {
        rectTransform = healthBarFill.GetComponent<RectTransform>();
        sizeDelta = rectTransform.sizeDelta;
        width = sizeDelta.x;
        //rectTransform.position = new Vector2(110, 25);
    }

    void Update()
    {
        healthBarFill.fillAmount = 0.5f;
        sizeDelta.x = width * ((float)(playerHealth.health) / 100f);
        rectTransform.sizeDelta = sizeDelta;
    }
}
