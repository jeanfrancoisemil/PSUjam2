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
        WeaponChoice.Instance.transform.root.gameObject.SetActive(false);
    }

    public void SpawnEnemy(Vector3 pos)
    {
        if (currentEnemySpawnedCount < patternOfWave.EnemyCount)
        {
            Instantiate(patternOfWave.Enemy, pos, Quaternion.identity).transform.SetParent(transform);
            currentEnemySpawnedCount++;
        }
    }
    [HideInInspector]public bool newWave;
    [HideInInspector]public bool endWave;
    // Update is called once per frame
    void Update()
    {
        if (Instance.transform.childCount == 0 && currentEnemySpawnedCount==patternOfWave.EnemyCount && !_coroutines && !endWave)
        {
            endWave = true;
            StartCoroutine(StartMenuCoroutine());
        }
        else
        {
            newWave = false;
        }
    }
    private bool _coroutines;
    IEnumerator StartMenuCoroutine()
    {
        _coroutines = true;
        yield return new WaitForSeconds(3f);
        SpawnMenu();

        _coroutines = false;
    }
    private float _savedTimeScale;
    private Attack.WeaponSprite spriteOne;
    private Attack.WeaponSprite SpriteTwo;
    private void SpawnMenu()
    {
        _savedTimeScale = Time.timeScale;
        WeaponChoice.Instance.transform.root.gameObject.SetActive(true);
        WeaponChoice.Instance.SetPause();
        var weapons = Attack.Instance.FetchWeapons();
        WeaponChoice.Instance.SetSprites(weapons[0],weapons[1]);
        spriteOne = weapons[0];
        SpriteTwo = weapons[1];
        Time.timeScale = 0;
    }
    public void SetWeapon(int index)
    {
        WeaponChoice.Instance.transform.root.gameObject.SetActive(false);
        if (index == 2)
        {
            StartCoroutine(nameof(DisplayMap));
        }
        else
        {
            if (index == 0)
            {
                Attack.Instance.SwitchWeapon(spriteOne.Index);
            }
            if (index == 1)
            {
                Attack.Instance.SwitchWeapon(SpriteTwo.Index);
            }

            NextWave();
            
            Time.timeScale = _savedTimeScale;
            newWave = true;
            endWave = false;            
        }
        StartCoroutine(nameof(ResetEndWave));
    }

    IEnumerator ResetEndWave()
    {
        yield return new WaitForSeconds(12f);
        endWave = false;
    }
    IEnumerator DisplayMap()
    {
        yield return new WaitForSeconds(10f);
        NextWave();
        Time.timeScale = _savedTimeScale;
        newWave = true;
        endWave = false;
    }
    private void NextWave()
    {
        if (_deathPresence && Random.Range(0, 20) == 10)
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
