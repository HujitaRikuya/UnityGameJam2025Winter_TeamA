using UnityEngine;
using TMPro;

public class KillUI : MonoBehaviour
{
    public TextMeshProUGUI killText;

    int prevKillCount = -1;

    void Update()
    {
        if (killText == null || EnemyScript.DeathCount== null)
            return;

        int kill = EnemyScript.DeathCount;

        // 値が変わった時だけ更新
        if (kill != prevKillCount)
        {
            killText.text = kill.ToString("000"); // 3桁表示
            prevKillCount = kill;

            // ちょっと拡大演出（UI感UP）
            killText.transform.localScale = Vector3.one * 1.2f;
        }

        // 元のサイズに戻す
        killText.transform.localScale =
            Vector3.Lerp(killText.transform.localScale, Vector3.one, 10f * Time.deltaTime);
    }
}