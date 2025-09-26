using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class WaveManager : MonoBehaviour
{
    [Header("Spawning")]
    [SerializeField] private List<GameObject> enemiesToSpawn;
    [SerializeField] private List<BoxCollider2D> spawnAreas;
    [SerializeField] private float fixedZ = 0f; 

    [Header("Waves")]
    [SerializeField] private float timeBetweenWaves = 30f;
    [SerializeField] private int enemyAmount = 8;
    [SerializeField] private int maxWaves = 8;
    [SerializeField] private int currentWave = 0;
    [Header("UI")]
    [SerializeField] private TMP_Text nextWaveText;
    [SerializeField] private TMP_Text waveCount;
    [SerializeField] private TMP_Text enemiesLeft;


    private float timer = 0;
    private int aliveEnemies = 0;
    public static WaveManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }
        Instance = this;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        UpdateWaveText();


        if (timer <= 0 && currentWave < maxWaves)
        {
            int toSpawn = enemyAmount + currentWave; 
            for (int i = 0; i < toSpawn; i++)
            {
                
                GameObject enemyToSpawn = enemiesToSpawn[Random.Range(0, enemiesToSpawn.Count)];
                BoxCollider2D area = spawnAreas[Random.Range(0, spawnAreas.Count)];
                Vector3 spawnPosition = GetRandomPointInArea(area);

                var go = Instantiate(enemyToSpawn, spawnPosition, area.transform.rotation);
                var enemy = go.GetComponent<Enemy>();
                if (enemy != null)
                {
                    aliveEnemies++;
                    enemy.Died += OnEnemyDied;
                }

            }
            enemiesLeft.text = "Enemies Left: " + aliveEnemies;
            timer = timeBetweenWaves;
            currentWave++;
        }
        if( currentWave == maxWaves && aliveEnemies == 0){
            GlobalStats.wavesCleared = true;
            GlobalStats.gameOver  = true;
        }

    }
    
    private void OnEnemyDied(Enemy e)
    {
        if (e != null) e.Died -= OnEnemyDied;

        aliveEnemies = Mathf.Max(0, aliveEnemies - 1);
        enemiesLeft.text = "Enemies Left: " + aliveEnemies;
        if (aliveEnemies == 0 && currentWave < maxWaves)
        {
            timer = 0;
        }
    }
    
    private Vector3 GetRandomPointInArea(BoxCollider2D area)
    {
        Bounds b = area.bounds;

        float x = Random.Range(b.min.x, b.max.x);
        float y = Random.Range(b.min.y, b.max.y);

        return new Vector3(x, y, fixedZ);
    }

    private void UpdateWaveText()
    {

        if (nextWaveText == null || waveCount == null)
        {
            return;
        }
        if (currentWave < maxWaves)
        {
            nextWaveText.text = "Next wave in " + Mathf.CeilToInt(timer);
        }
        else
        {
            nextWaveText.text = "Last wave";
        }
        waveCount.text = "Wave " + currentWave + "/" + maxWaves;


    }

}
