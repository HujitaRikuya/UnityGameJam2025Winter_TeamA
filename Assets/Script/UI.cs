using UnityEngine;
using UnityEngine.UI;   // ← 追加

public class Timer : MonoBehaviour
{
    public Text timeText;   // ← TextMeshProUGUI から変更

    float currentTime;
    bool isRunning = true;

    void Start()
    {
        if (timeText == null)
        {
            Debug.LogError("Timer: timeText が設定されていません");
            enabled = false;
            return;
        }

        string[] split = timeText.text.Split(':');
        int min = int.Parse(split[0]);
        int sec = int.Parse(split[1]);

        currentTime = min * 60 + sec;
    }

    void Update()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = 0;
            isRunning = false;
        }

        int m = Mathf.FloorToInt(currentTime / 60);
        int s = Mathf.FloorToInt(currentTime % 60);
        timeText.text = $"{m:00}:{s:00}";
    }
}