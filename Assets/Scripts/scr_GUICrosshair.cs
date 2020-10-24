using UnityEngine;
using System.Collections;

public class scr_GUICrosshair : MonoBehaviour 
{
    public Texture2D crosshairTexture;
    Rect position;
    static bool OrigionalOn = true;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        position = new Rect((Screen.width - crosshairTexture.width) / 2, (Screen.height - crosshairTexture.height) / 2, crosshairTexture.width, crosshairTexture.height);
	}

    void OnGUI()
    {
        if (OrigionalOn == true)
        {
            GUI.DrawTexture(position, crosshairTexture);
        }
    }
}
