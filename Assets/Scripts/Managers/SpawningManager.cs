using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpawningManager : MonoBehaviour
{
    private static SpawningManager instance;
    public static SpawningManager Instance
    {
        get
        {
            if (instance == null) {
                instance = FindObjectOfType<SpawningManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(SpawningManager).Name;
                    instance = obj.AddComponent<SpawningManager>();
                }
            }
            return instance;
        }
    }

    [SerializeField]
    private Vector2 spawningAreaCentre;
    
    public Vector2 spawningArea;//Box where fleas can spawn

    [SerializeField]
    private Vector2 numFleaSpawnRange = new Vector2(10,20);//The range for number of fleas to be spawned. X is the lower range, Y is the upper range.
    public List<GameObject> fleaPrefabs;//Prefab for flea to be spawned

    private List<GameObject> fleas = new List<GameObject>();

    public void Start()
    {
        SpawnFleas();
    }

    public void Update()
    {
        if(fleas.Count == 0)
        {
            SceneManager.LoadScene(3);
            //Debug.Log("game ended");
        }
    }

    /*
        Method to spawn in fleas
    */
    public void SpawnFleas()
    {
        //Get the final number of fleas to spawn this time round
        float NumSpawnedFleas = Mathf.Floor(Random.Range(numFleaSpawnRange.x, numFleaSpawnRange.y));

        
        for(int i = 0; i < NumSpawnedFleas; i++)
        {
            //Choose a random spawn area and instantiate the flea
            Vector2 chosenSpawnArea = new Vector2(Random.Range(-spawningArea.x, spawningArea.x), Random.Range(-spawningArea.y, spawningArea.y));
            GameObject fleaPrefab = fleaPrefabs[Random.Range(0,fleaPrefabs.Count-1)];
            GameObject spawnedFlea = Instantiate(fleaPrefab, chosenSpawnArea,Quaternion.identity);
            fleas.Add(spawnedFlea);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(spawningAreaCentre,new Vector3(spawningArea.x*2, spawningArea.y*2,0));
    }




}
