using System.Collections;
using UnityEngine;

/// <summary>
/// 敵のスポナー
/// 画面外に円環状の範囲にランダム生成
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [Header("敵Prefab"),SerializeField]
    private GameObject[] _enemyPrefabs;

    [Header("プレイヤーのトランスフォーム"), SerializeField]
    private Transform _playerTransform;

    [SerializeField]
    private Transform[] _spawnPoints;

    /// <summary>
    /// Start
    /// </summary>
    private void Start()
    {
        // x秒ごとに生成場所を計算しスポーンさせる
        // これにはコルーチンを使って繰り返し計算しスポーン。
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.7f);
            var spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            Spawn(spawnPoint);
        }
    }

    /// <summary>
    /// スポーン
    /// </summary>
    private void Spawn(Transform spawnPoint)
    {
        // 敵生成
        var index = Random.Range(0, _enemyPrefabs.Length);
        var enemyObj = Instantiate(_enemyPrefabs[index], spawnPoint);
        enemyObj.GetComponent<Enemy>().SetPlayerTransform(_playerTransform);
    }

}
