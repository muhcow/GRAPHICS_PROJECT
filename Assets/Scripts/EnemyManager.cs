using UnityEngine;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {      
        public GameObject enemy;               
        public float spawnTime = 3f;            
        public Transform[] spawnPoints;        

        void Start()
        {
            // after a delay of spawn time call spawn function
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }


        void Spawn()
        {
            // find random spawn point index
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            //instatiate enemy at random spawn point and rotation
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }
}