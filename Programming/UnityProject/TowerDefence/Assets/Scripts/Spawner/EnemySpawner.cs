using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class EnemySpawner : MonoBehaviour {

    private float timeTillNextWave = 0.2f;
    private float timeTillNextSpawn = 0.5f;

    private int waveCounter = 1;
    private string waveText;
    private string timeTillNextWaveText;
    private bool spawning = false;

    public GameObject[] enemyArray;
    private GameObject currentSpawnObject;

    private float spawnCircleRadius = 30.0f;
    [SerializeField]
    private int[] currentWave = new int[20];

    private UIBehaviour uIBehaviour;

	void Start ()
    {
        uIBehaviour = GameObject.Find("MainGameLogic").GetComponent<UIBehaviour>();
        uIBehaviour.UpdateWaveText("Next wave: " + waveCounter);
    }

	void Update () {
		if(!spawning)
        {
            if(timeTillNextWave >= 0)
            {
                timeTillNextWave -= Time.deltaTime;
                uIBehaviour.UpdateTTNW("Next wave in: " + Mathf.Round(timeTillNextWave));
                
            }
            else if(timeTillNextWave < 0)
            {
                currentWave = new int[20];
                ReadWave();
                StartCoroutine(SpawnWave());
                uIBehaviour.UpdateTTNW("Wave spawning now");
                
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

            currentSpawnObject = Instantiate(enemyArray[currentWave[i] - 1] , new Vector3(0, 0.5f, 0) , Quaternion.identity);
            float randomAngle = Random.value * 360;
            currentSpawnObject.transform.rotation = Quaternion.Euler(0, randomAngle, 0);
            currentSpawnObject.transform.Translate(Vector3.forward * spawnCircleRadius);
            counter++;
        }
        timeTillNextWave = 3.0f;
        waveCounter++;
        uIBehaviour.UpdateWaveText("Next wave: " + waveCounter);
        spawning = false;

    }

    private void ReadWave()
    {
        // small patch to create infinite waves
        if (waveCounter < 6)
        {
            //waveCounter = 1;

            string path = "Assets/Resources/SpawnWave/Wave" + waveCounter + ".txt";
            StreamReader reader = new StreamReader(path);
            string results = reader.ReadToEnd();
            string[] waveString = results.Split(",".ToCharArray());
            for (int i = 0; i < 20; i++)
            {
                currentWave[i] = int.Parse(waveString[i]);
            }
            reader.Close();
        }
        else
        {
            for(int i=0; i< 20; i++)
            {
                currentWave[i] = Mathf.RoundToInt(Random.value * 2) + 1;
            }
        }
        
    }
}
