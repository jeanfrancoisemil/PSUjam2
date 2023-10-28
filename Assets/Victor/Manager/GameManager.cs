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
    public PatternElement patternOfWave;
    public List<EnemyMovement> enemiesPrefabs;
    [HideInInspector]public int currentEnemySpawnedCount;
    private bool _deathPresence;
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
        _deathPresence = DeathSpawner.Instance != null;
    }

    public void SpawnEnemy(Vector3 pos)
    {
        if (currentEnemySpawnedCount < patternOfWave.EnemyCount)
        {
            Instantiate(patternOfWave.Enemy, pos, Quaternion.identity).transform.SetParent(transform);
            currentEnemySpawnedCount++;
        }
    }
    public bool newWave;
    public bool endWave;
    // Update is called once per frame
    void Update()
    {
        if (Instance.transform.childCount == 0 && currentEnemySpawnedCount== patternOfWave.EnemyCount)
        {
            endWave = true;
            StartCoroutine(StartMenuCoroutine());
        }
        else
        {
            newWave = false;
        }
    }

    IEnumerator StartMenuCoroutine()
    {
        yield return new WaitForSeconds(3f);
        SpawnMenu();
        NextWave();
        newWave = true;
        endWave = false;
    }
    private float _savedTimeScale;
    private void SpawnMenu()
    {
        _savedTimeScale = Time.timeScale;
        Time.timeScale = 0;
    }
    private void NextWave()
    {
        if (_deathPresence && Random.Range(0, 20) <= 20)
        {
            StartCoroutine(nameof(SpawnDeath));
            DeathSpawner.Instance.SpawnDeath();
        }
        
        waveNumber++;
        currentPatterns.RemoveAt(0);
        patternOfWave = currentPatterns[0];
        currentPatterns.Add(GenerateNewPattern(waveNumber + numberOfWavePredicted));
        currentEnemySpawnedCount = 0;
    }

    IEnumerator SpawnDeath()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(deathPrefab, DeathSpawner.Instance.transform.position, Quaternion.identity);
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
