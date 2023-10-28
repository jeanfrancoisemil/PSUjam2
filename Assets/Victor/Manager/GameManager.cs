using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public int numberOfWavePredicted = 6;
    [HideInInspector]public int waveNumber = 0;
    public List<PatternElement> currentPatterns = new List<PatternElement>();
    public EnemyMovement deathPrefab;
    public DeathSpawner DeathSpawner;
    public PatternElement patternOfWave;
    public List<EnemyMovement> enemiesPrefabs;
    [HideInInspector]public int currentEnemySpawnedCount;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        for (int i = 0; i < numberOfWavePredicted; i++)
        {
            currentPatterns.Add(GenerateNewPattern(i));
        }
        patternOfWave = currentPatterns[0];
        currentPatterns.Add(GenerateNewPattern(waveNumber + numberOfWavePredicted));
        currentEnemySpawnedCount = 0;
    }

    public void SpawnEnemy(Vector3 pos)
    {
        if (currentEnemySpawnedCount < patternOfWave.EnemyCount)
        {
            Instantiate(patternOfWave.Enemy, pos, Quaternion.identity).transform.SetParent(transform);
            currentEnemySpawnedCount++;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Instance.transform.childCount == 0 && currentEnemySpawnedCount== patternOfWave.EnemyCount)
        {
            NextWave();
        }
    }

    private void NextWave()
    {
        if (Random.Range(0, 20) == 10)
        {
            
        }
        waveNumber++;
        currentPatterns.RemoveAt(0);
        patternOfWave = currentPatterns[0];
        currentPatterns.Add(GenerateNewPattern(waveNumber + numberOfWavePredicted));
        currentEnemySpawnedCount = 0;
    }

    private PatternElement GenerateNewPattern(int waveIndex)
    { 
        return new PatternElement()
        {
            EnemyCount = 5 + waveIndex * 2,
            Enemy = enemiesPrefabs[Random.Range(0, enemiesPrefabs.Count)]
        };
    }

    public class PatternElement
    {
        public EnemyMovement Enemy;
        public int EnemyCount;
    }
    
}
