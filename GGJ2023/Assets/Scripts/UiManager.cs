using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI attackSpeedText;
    [SerializeField] private TextMeshProUGUI healPowerText;
    [SerializeField] private TextMeshProUGUI moveSpeecText;
    [SerializeField] private TextMeshProUGUI timer;
    private float timeElapsed;

    private void Start()
    {
        timeElapsed = 0f;
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        timer.text =  "TIMER: " + timeElapsed.ToString("F1");  
    }

    public void SetDamageText(string text)
    {
        damageText.text = "Damage: " + text;
    }
    public void SetHealText(string text)
    {
        healPowerText.text = "Heal Power: " + text;
    }
    public void SetAttackSpeedText(string text)
    {
        attackSpeedText.text = "Attack Speed: " + text;
    }
    public void SetMoveSpeedText(string text)
    {
        moveSpeecText.text = "Move Speed: " + text;
    }
}
