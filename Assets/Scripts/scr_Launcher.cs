using UnityEngine;
using System.Collections;

public class scr_Launcher : MonoBehaviour 
{
    public GameObject Bullet;
    bool CanFire = true;

	// Use this for initialization
	void Start () 
    {
	
	}

    void ReadyWeapon()
    {
        CanFire = true;
    }

	// Update is called once per frame
	void Update () 
    {
        if (Input.GetButton("Fire1") && CanFire == true)
        {
            Instantiate(Bullet, transform.position, transform.rotation);
            GetComponent<AudioSource>().Play();
            CanFire = false;
            Invoke("ReadyWeapon", 0.5f);
        }
        if (Input.GetAxis("Triggers") > 0 && CanFire == true)
        {
            GetComponent<AudioSource>().Play();
            Instantiate(Bullet, transform.position, transform.rotation);
            CanFire = false;
            Invoke("ReadyWeapon", 0.5f);
        }
	}
}
