using UnityEngine;
using System.Collections;

public class scr_Player : MonoBehaviour 
{
    public static int Health = 100;
    public static int Kills = 0;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        print("Health = " + Health);
        if (Health < 1)
        {
            Application.LoadLevel(2);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            Health -= 5;
        }
    }
}
