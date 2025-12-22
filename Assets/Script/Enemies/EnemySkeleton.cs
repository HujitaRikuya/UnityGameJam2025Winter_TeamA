/// <summary>
/// スケルトン(敵)
/// </summary>
public class EnemySkeleton : Enemy
{
    /// <summary>
    /// Start
    /// </summary>
    private void Start()
    {
        // ステータス設定
        SetStatus(10, 1, 1,10);
    }
}
