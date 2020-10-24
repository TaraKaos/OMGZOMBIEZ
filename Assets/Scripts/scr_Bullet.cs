using UnityEngine;
using System.Collections;

public class scr_Bullet : MonoBehaviour 
{
    float speed = 100.0f;
    public GameObject zombie;
    int ZombieCount = 1;
    int ZombieMax = 1;
    public GameObject pfx_ZombieSpawn;
    public GameObject pfx_ZombieDeath;

	// Use this for initialization
	void Start () 
    {

	}

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

	// Update is called once per frame
	void Update () 
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            Instantiate(pfx_ZombieDeath, transform.position, transform.rotation);
            scr_Player.Kills++;
            ZombieCount--;
            ZombieMax++;
            while (ZombieMax > ZombieCount)
            {
                Vector3 ZombieLocation = new Vector3(Random.Range(10, 90), 0, Random.Range(10, 80));
                Instantiate(zombie, ZombieLocation, transform.rotation);
                Instantiate(pfx_ZombieSpawn, ZombieLocation, transform.rotation);
                ZombieCount++;
            }
            Destroy(other.gameObject);
            DestroyBullet();
        }
    }
}
