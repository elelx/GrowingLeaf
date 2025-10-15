using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject leafPrefabs; //array

    public GameObject redgrass;

    public GameObject yellowgrass;

    public float spawnCountMin = 1f;
    public float spawnCountMax = 5f;

    public float timer = 60f;
    public bool firstPlant = false;


    public float startDelay = 1;
    public float spawnInterval;





    // Start is called before the first frame update
    void Start()
    {
        // Invoke("timerEnded", startDelay); //invoke is used for time delayed actions so it calles spawnleaves after the amount of delay secondsd
        //invokeRepeating(methodName, initldely, repeatrate) --> does it repeatdly after inital delya

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f && !firstPlant)
        {
            firstPlant = true;
            StartCoroutine(SpawnSequence()); //starts the ienmnerter

        }
        //{
        //    timerEnded();
        //}
    }

    IEnumerator SpawnSequence() //runs overtime but lets u pause using yeild

    {
        Debug.Log("Spawning green leaf");

        GameObject green = Instantiate(leafPrefabs, transform.position, transform.rotation);

        GetComponent<Renderer>().enabled = false;


        float randomDelay = Random.Range(spawnCountMin, spawnCountMax);

        yield return new WaitForSeconds(randomDelay);


        Debug.Log("Spawning red leaf");

        GameObject red = Instantiate(redgrass, transform.position, transform.rotation);
        Destroy(green);



        randomDelay = Random.Range(spawnCountMin, spawnCountMax);
        yield return new WaitForSeconds(randomDelay);


        Debug.Log("Spawning yellow leaf");

        Destroy(red);

        Instantiate(yellowgrass, transform.position, transform.rotation);



        //Destroy(gameObject);

    }

    //    void timerEnded()
    //    {
    //        int randomLeaves = Random.Range(0, 2);

    //        Instantiate(leafPrefabs, transform.position, transform.rotation);

    //        Destroy(gameObject);

    //        firstPlant = true;

    //        NextSpawn();


    //    }

    //    void NextSpawn()
    //    {
    //        float timer2 = 5f;

    //        timer2 -= Time.deltaTime;

    //        if (timer2 <= 0.0f)
    //        {
    //            timerEnded2();
    //        }
    //    }

    //    void timerEnded2()
    //    {
    //        int randomLeaves = Random.Range(0, 2);

    //        Instantiate(redgrass, transform.position, transform.rotation);

    //        Destroy(gameObject);

    //    }

    //}

}


