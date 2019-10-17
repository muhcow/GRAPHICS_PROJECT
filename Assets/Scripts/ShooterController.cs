using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
    public ParticleSystem gunEffect;

    float timer;
    ParticleSystem gunParticles;


    void Awake ()
    {
        //gunParticles = GetComponent<ParticleSystem>();
    }


    void Update ()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }




    void Shoot()
    {
        gunEffect.Stop();
        gunEffect.Play();
    }
 
}