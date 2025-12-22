using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExpUI : MonoBehaviour
{
    public PlayerStats playerStats;
    public TextMeshProUGUI levelText;
    public Image expBar;

    void Update()
    {
        if (playerStats == null) return;

        // Lv 表示
        levelText.text = $"Lv.{playerStats.level}";

        // 経験値バー
        float fill =
            (float)playerStats.currentExp / playerStats.expToNextLevel;
        expBar.fillAmount = fill;
    }
}
