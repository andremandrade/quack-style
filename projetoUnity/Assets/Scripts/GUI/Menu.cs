using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public int boxMenuWidth = Screen.width*4/5;
	public int boxMenuHeight = Screen.height*3/5;
	public int buttonsWidth = 100;
	public int buttonsHeight = 20;
	public int buttonsSpace = 40;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.BeginGroup (new Rect(Screen.width/2 - boxMenuWidth/2, Screen.height/2 - boxMenuHeight/2,
		                         boxMenuWidth, boxMenuHeight),"");
		bool teste1 = GUI.Button(new Rect(boxMenuWidth/2 - buttonsWidth/2, boxMenuHeight/2 - buttonsHeight/2
		                                  , buttonsWidth, buttonsHeight), "Fase 01");
		if(teste1){
			Application.LoadLevel("fase01");
		}
		GUI.Button(new Rect(boxMenuWidth/2 - buttonsWidth/2, boxMenuHeight/2 - buttonsHeight/2 
		                                  + 1 * buttonsSpace, buttonsWidth, buttonsHeight), "Fase 02");
		GUI.Button(new Rect(boxMenuWidth/2 - buttonsWidth/2, boxMenuHeight/2 - buttonsHeight/2 
		                                  + 2 * buttonsSpace, buttonsWidth, buttonsHeight), "Fase 03");
		bool testeSair =GUI.Button(new Rect(boxMenuWidth/2 - buttonsWidth/2, boxMenuHeight/2 - buttonsHeight/2 
		                    + 3 * buttonsSpace, buttonsWidth, buttonsHeight), "Sair");
		if(testeSair){
			Application.Quit();
		}
		GUI.EndGroup();
	}
}
