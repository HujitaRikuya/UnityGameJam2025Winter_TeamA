using UnityEngine;

/// <summary>
/// 経験値
/// </summary>
public class Exp : MonoBehaviour
{
    /// <summary>
    /// プレイヤーのトランスフォーム
    /// </summary>
    private Transform _playerTransform;

    /// <summary>
    /// 経験値
    /// </summary>
    private int _exp;

    /// <summary>
    /// Start
    /// </summary>
    private void Start()
    {
        _playerTransform = GameObject.Find("Player").transform;
    }

    /// <summary>
    /// 更新
    /// </summary>
    private void Update()
    {
        // プレイヤーとの距離が一定以上近づくと取得
        if(Vector3.Distance(transform.position,_playerTransform.position) < 0.8f)
        {
            var obj = GameObject.Find("GameManager");
            var gameManager = obj.GetComponent<GameManager>();
            gameManager.UpdateExpSlider();

            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 経験値設定
    /// </summary>
    /// <param name="exp"></param>
    public void SetExpValue(int exp)
    {
        _exp = exp;
    }

    public void SetPosition(Vector2 pos)
    {
        transform.position = pos;
    }
}
