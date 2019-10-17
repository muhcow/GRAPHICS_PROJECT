using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    UnityEngine.AI.NavMeshAgent nav;
    public GameObject myParticleSystem;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update()
    {
        nav.SetDestination(player.position);
    }

     // Handle collisions
    void OnTriggerEnter(Collider col)
    {
        GameObject newParticleSystem = Instantiate(this.myParticleSystem);
        newParticleSystem.transform.position = this.transform.position;
    }
}
