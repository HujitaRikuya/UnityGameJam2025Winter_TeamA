using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲームマネージャー
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 敵の死亡回数
    /// </summary>
    private int _enemyDeathCount;

    [SerializeField]
    Text _enemyDeathCountText;

    [SerializeField]
    private Slider _expSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 敵の死亡回数をカウント
    /// </summary>
    public void CountEnemyDeath()
    {
        _enemyDeathCount++;
        _enemyDeathCountText.text = _enemyDeathCount.ToString();
    }

    public void UpdateExpSlider()
    {
        _expSlider.value += 0.02f;
    }
}
