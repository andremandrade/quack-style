using UnityEngine;
using System.Collections;

public class Som : MonoBehaviour {
	private UILabel labelSom;
	public bool somLigado = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		labelSom = GetComponentInChildren<UILabel>();
		if (somLigado) {
				somLigado = false;
				labelSom.text = "Ligar Som";
		} else {
				somLigado = true;
				labelSom.text = "Desligar Som";
		}
	}
}
