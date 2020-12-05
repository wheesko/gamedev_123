using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var aliveEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
            LevelManager.KilledEnemyCount = LevelManager.EnemyCount - aliveEnemyCount;
            GameController.Instance.EndGame(true);
            MusicController.Instance.Play(MusicController.MusicType.LevelEnd);
            Debug.Log($"The level is finished! \nTime: {LevelManager.LevelTime}" +
                $"\nEnemies killed: " +
                $"{LevelManager.KilledEnemyCount} " +
                $"\nSecrets Found: {LevelManager.FoundSecretCount}");
        }
    }
}
