using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    static public float maxSecond;

    public float heightRnage = 0.63f, timer;
    public GameObject[] pipes;
    int randomInt;
    void Start()
    {
        PipeSpawn();
        maxSecond = 1.5f;
    }


    void Update()
    {
        maxSecond = Random.Range(SpeedScript.pipeSpeedmin, SpeedScript.pipeSpeedmax);
        if (timer > maxSecond)
        {
            PipeSpawn();
            timer = 0;
        }
        timer += Time.deltaTime;
        randomInt = Random.Range(0, pipes.Length);

    }

    private void PipeSpawn()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRnage, +heightRnage));
        GameObject pipe = Instantiate(pipes[randomInt], spawnPos, Quaternion.identity);

        Destroy(pipe, 8f);
    }
}
