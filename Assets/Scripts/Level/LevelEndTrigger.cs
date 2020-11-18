using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var aliveEnemyCount = GameObject.FindGameObjectsWithTag("Secret").Length;
            LevelManager.KilledEnemyCount = LevelManager.EnemyCount - aliveEnemyCount;
            GameController.Instance.EndGame(true);
            Debug.Log($"The level is finished! \nTime: {LevelManager.LevelTime}" +
                $"\nEnemies killed: " +
                $"{LevelManager.KilledEnemyCount} " +
                $"\nSecrets Found: {LevelManager.FoundSecretCount}");
        }
    }
}
