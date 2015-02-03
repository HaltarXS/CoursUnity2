using UnityEngine;
using System.Collections;

public class ParalaxItemSpawnScript : MonoBehaviour {

    public float nextSpawn = 5.0f;
    public Vector2 spawnRange = new Vector2(5.0f, 15.0f);
    public float[] spawnLignePosY = new float[]{0.6f, 0.9f, 1.2f};
    public GameObject[] ressources;

    private float lastPlayerPosition,paralaxSpeed;
    private GameObject parent;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lastPlayerPosition = player.transform.position.z;
        parent = gameObject;
       
    }

    void Update()
    {
        
        Vector3 playerPosition = player.transform.position;
        if (nextSpawn < 0)
        {
            int rand = UnityEngine.Random.Range(0, spawnLignePosY.Length);
            float ligneY = spawnLignePosY[rand];

            GameObject go = GameObject.Instantiate(
                ressources[Random.Range(0,ressources.Length)],
                new Vector3(-ligneY, 0.0f, player.transform.position.z + 20.0f),
                Quaternion.identity
            ) as GameObject;
            go.transform.parent = parent.transform;
            nextSpawn = UnityEngine.Random.Range(spawnRange.x, spawnRange.y);
            
            rand = UnityEngine.Random.Range(0, 10);
            if(rand ==1)
                go.GetComponent<Animator>().SetBool("gangnam", true);
        }
        else
        {
            float playerPositionZ = playerPosition.z;
            paralaxSpeed = (playerPositionZ - lastPlayerPosition);
            nextSpawn = nextSpawn - (playerPositionZ - lastPlayerPosition);
            lastPlayerPosition = playerPositionZ;
        } 
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Paralax"))
        {
            obj.transform.position = new Vector3(obj.transform.position.x,
                obj.transform.position.y,
                obj.transform.position.z + 0.3f*Time.deltaTime );
        }
    }
}
