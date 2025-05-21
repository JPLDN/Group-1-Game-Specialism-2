using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathNotifier : MonoBehaviour
{
    private BothSideSpawners spawner;

    public void SetSpawner(BothSideSpawners spawnerRef)
    {
        spawner = spawnerRef;
    }

    private void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.OnEnemyDestroyed();
        }
    }
}
