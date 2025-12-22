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

    [SerializeField]
    private Text _levelText;

    private int _currentLv;

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
        _expSlider.value += 0.1f;

        if (_expSlider.value >= 1)
        {
            _currentLv++;
            _levelText.text = _currentLv.ToString();
            _expSlider.value = 0;
        }
    }
}
