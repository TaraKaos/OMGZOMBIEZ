using UnityEngine;
using System.Collections;

public class scr_GUI_GamePlay : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnGUI()
    {
        Cursor.visible = false;
        GUI.Box(new Rect(0, 0, 100, 50), "Health: " + scr_Player.Health);
        GUI.Box(new Rect(Screen.width - 100, 0, 100, 50), "Kills: " + scr_Player.Kills);
    }
}
