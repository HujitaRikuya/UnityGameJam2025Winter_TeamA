
/// <summary>
/// アンデット(敵)
/// </summary>
public class EnemyUndead : Enemy
{
    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        // ステータス設定
        SetStatus(30, 1, 2, 15);
    }
}
