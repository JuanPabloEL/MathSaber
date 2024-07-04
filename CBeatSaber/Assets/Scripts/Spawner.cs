using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] points;
    public float beat = (60/130)*3;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timer>beat)
        {
            GameObject cube1 = Instantiate(cubes[1], points[0]);
            cube1.transform.localPosition = Vector3.zero;
            cube1.transform.Rotate(transform.forward, Random.Range(0, 4));

            GameObject cube2 = Instantiate(cubes[0], points[1]);
            cube2.transform.localPosition = Vector3.zero;
            cube2.transform.Rotate(transform.forward, Random.Range(0, 4));

            timer -= beat;
        }

        timer += Time.deltaTime;
        
    }
}
