using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UniFileControl : MonoBehaviour {

	public GameObject target;
	public GameObject sampleObject;

	private GameObject targetObj;
	private string imagePath;

	// Use this for initialization
	void Start () {
		UniFileBrowser.use.SetPath (@"C:\Users\asus\Desktop\Images");
		//UniFileBrowser.use.limitToInitialFolder = true;
		imagePath = PlayerPrefs.GetString("imagePath");
		if (imagePath == "") {
			imagePath = @"C:\Users\asus\Desktop\Images\Blue_bubble.png";
		}
		Texture2D targetTex = LoadPNG (imagePath);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SelectImage() {
		print ("Select Image!");
		UniFileBrowser.use.OpenFileWindow (OpenFile);
	}

	void OpenFile (string pathToFile) {
		var fileName = Path.GetFileName (pathToFile);
		string message = "You selected file: " + fileName;
		print(pathToFile);
		Texture2D targetTex = LoadPNG (pathToFile);
		PlayerPrefs.SetString ("imagePath", pathToFile);
	}

	public Texture2D LoadPNG(string filePath){
		Texture2D tex = null;
		byte[] fileData;

		if (File.Exists (filePath)) {
			fileData = File.ReadAllBytes (filePath);
			tex = new Texture2D (2, 2);
			tex.LoadImage (fileData);
		
		}
			
		target.GetComponent<SpriteRenderer> ().sprite = Sprite.Create (tex, new Rect (0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f),100);
		sampleObject.GetComponent<SpriteRenderer> ().sprite = Sprite.Create (tex, new Rect (0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f),100);

		return tex;
	}
}
