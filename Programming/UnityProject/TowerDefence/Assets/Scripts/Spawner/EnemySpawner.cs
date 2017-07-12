using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class EnemySpawner : MonoBehaviour {

    private float timeTillNextWave = 0.2f;
    private float timeTillNextSpawn = 0.5f;

    public Text textField;
    public Text textFieldTimeTillNextWave;

    private int waveCounter = 1;
    private string waveText;
    private string timeTillNextWaveText;
    private bool spawning = false;

    public GameObject basicEnemy;
    private GameObject currentSpawnObject;

    private float spawnCircleRadius = 30.0f;
    [SerializeField]
    private int[] currentWave = new int[20];

	void Start () {
        waveText = "Next wave: " + waveCounter;
        textField.text = waveText;
        ReadWave();
    }

	void Update () {
		if(!spawning)
        {
            if(timeTillNextWave >= 0)
            {
                timeTillNextWave -= Time.deltaTime;
                timeTillNextWaveText = "Next wave in: " + Mathf.Round(timeTillNextWave);
                textFieldTimeTillNextWave.text = timeTillNextWaveText;
            }
            else if(timeTillNextWave < 0)
            {
                StartCoroutine(SpawnWave());
                timeTillNextWaveText = "Wave spawning now";
                textFieldTimeTillNextWave.text = timeTillNextWaveText;
                spawning = true;
            }
        }
	}

    private IEnumerator SpawnWave()
    {
        int counter = 0;
        for (int i = 0; i<20; i++)
        {
            yield return new WaitForSeconds(timeTillNextSpawn);
            currentSpawnObject = Instantiate(basicEnemy, Vector3.zero, Quaternion.identity);
            float randomAngle = Random.value * 360;
            currentSpawnObject.transform.rotation = Quaternion.Euler(0, randomAngle, 0);
            currentSpawnObject.transform.Translate(Vector3.forward * spawnCircleRadius);
            Debug.Log(counter);
            counter++;
        }
        timeTillNextWave = 3.0f;
        waveCounter++;
        waveText = "Next wave: " + waveCounter;
        textField.text = waveText;
        spawning = false;
    }

    private void ReadWave()
    {
        string path = "Assets/Resources/SpawnWave/Wave" + waveCounter + ".txt";
        StreamReader reader = new StreamReader(path);
        string results = reader.ReadToEnd();
        string[] waveString = results.Split(new char[] { "," }, System.StringSplitOptions.None);
        for (int i = 0; i < 20; i++)
        {
            currentWave[i] = int.Parse(waveString[i]);
        }

        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }
}
