using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARMenu : MonoBehaviour {

	//deklarasi variabel untuk resize layar
	public GUISkin guiSkin;
	private float guiRatio;
	private float sWidth;
	private Vector3 GUIsF;

	public GameObject GedungFIS;
	public float kecepatanRotasi = 50f;
	bool statusRotasi = false;

	public Texture navAtas, navBawah, navKanan, navKiri;


	void Awake()
	{
		sWidth = Screen.width;
		guiRatio = sWidth / 1920;
		GUIsF = new Vector3 (guiRatio, guiRatio, 1);
	}
	void OnGUI() 
	{
		GUI.skin = guiSkin;
		Rotasi();
	}
	void Rotasi()
	{
		//membuat tombol di pojok kiri atas 
		GUI.matrix = Matrix4x4.TRS(new Vector3(GUIsF.x,GUIsF.y,0),Quaternion.identity,GUIsF);

		if (statusRotasi == false) 
		{
			if (GUI.Button (new Rect (1220, 20, 258, 89), "Rotation"))
			{
				statusRotasi = true;
			}	
		} 
		else 
		{
			if (GUI.Button (new Rect (1220, 20, 258, 89), "Stop Rotation"))
			{
				statusRotasi = false;
			}
		}
		exit();
	}
	void exit()
	{
		//membuat tombol di pojok kanan atas 
		GUI.matrix = Matrix4x4.TRS(new Vector3(Screen.width - 258*GUIsF.y,0),Quaternion.identity,GUIsF);

		if (GUI.Button (new Rect (-1220, 20, 258, 89), "Exit")) 
		{
			Application.Quit(); //keluar dari aplikasi
		}
	}
	void Update()
	{
		if (statusRotasi == true) 
		{
			GedungFIS.transform.Rotate (Vector3.up, kecepatanRotasi*Time.deltaTime);
		}
	}
	void Navigasi()
	{
		GUI.matrix = Matrix4x4.TRS (new Vector3 (Screen.width - 258 * GUIsF.x, Screen.height - 89 * GUIsF.y, 0), Quaternion.identity, GUIsF);

		if (GUI.RepeatButton (new Rect (-30, 0, 80, 80), navKiri)) {
			//Navigasi kiri
			GedungFIS.transform.Translate (Vector3.left *kecepatanRotasi *Time.deltaTime);
		}

		if (GUI.RepeatButton (new Rect (60, 0, 80, 80), navBawah)) {
			//Navigasi bawah
			GedungFIS.transform.Translate (Vector3.back *kecepatanRotasi *Time.deltaTime);
		}

		if (GUI.RepeatButton (new Rect (60, -90, 80, 80), navAtas)) {
			//Navigasi atas
			GedungFIS.transform.Translate (Vector3.forward *kecepatanRotasi *Time.deltaTime);
		}

		if (GUI.RepeatButton (new Rect (150, 0, 80, 80), navKanan)) {
			//Navigasi kanan
			GedungFIS.transform.Translate (Vector3.right * kecepatanRotasi * Time.deltaTime);
		}
	}
}
