using UnityEngine;

/// <summary>
/// 敵の基底クラス
/// </summary>
public class Enemy : MonoBehaviour
{
    /// <summary>
    /// HP
    /// </summary>
    private int _hp;

    /// <summary>
    /// 移動速度
    /// </summary>
    private int _moveSpeed;

    /// <summary>
    /// 攻撃力
    /// </summary>
    private int _attackPower;

    /// <summary>
    /// 落とす経験値の値
    /// </summary>
    private int _dropExpValue;

    /// <summary>
    /// プレイヤートランスフォーム
    /// </summary>
    private Transform _playerTransform;

    /// <summary>
    /// 無敵時間
    /// </summary>
    [SerializeField] private float invincibleTime = 0.1f;
    private bool _isInvincible = false;

    [SerializeField]
    private GameObject expPrefab;

    private GameObject playerObj;

    /// <summary>
    /// Update
    /// </summary>
    private void Update()
    {
        if(playerObj == null)
        {
            playerObj = GameObject.Find("Player");
        }

        // プレイヤーを追従
        Chase();

        // 死亡したかチェック
        CheckDeath();
    }

    /// <summary>
    /// プレイヤーを追跡
    /// </summary>
    private void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, _playerTransform.position, _moveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 経験値を落とす
    /// </summary>
    private void DropExp()
    {
        // 経験値を落とす
        var expObj = Instantiate(expPrefab);
        var exp = expObj.GetComponent<Exp>();
        exp.SetExpValue(_dropExpValue);
        exp.SetPosition(transform.position);
    }

    /// <summary>
    /// ステータス設定
    /// </summary>
    protected void SetStatus(int hp,int moveSpeed,int attackPower, int dropExpValue)
    {
        _hp = hp;
        _moveSpeed = moveSpeed;
        _attackPower = attackPower;
        _dropExpValue = dropExpValue;
    }

    /// <summary>
    /// 死亡
    /// </summary>
    public void CheckDeath()
    {
        // if(_hp <= 0)
        if(Vector3.Distance(playerObj.transform.position,transform.position) < 2.0f)
        {
            // 経験値を落とす
            DropExp();
            // 死亡カウント
            var obj = GameObject.Find("GameManager");
            var gameManager = obj.GetComponent<GameManager>();
            gameManager.CountEnemyDeath();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// ダメージを受ける
    /// </summary>
    public void Damaged(int damage)
    {
        if (_isInvincible == true)//無敵時間中に被弾してもダメージを受けない
        {
            return;
        }
        _hp -= damage;
    }

    /// <summary>
    /// プレイヤーのトランスフォームを設定
    /// </summary>
    public void SetPlayerTransform(Transform playerTransform)
    {
        _playerTransform = playerTransform;
    }
}
