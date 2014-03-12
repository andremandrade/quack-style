using UnityEngine;
using System.Collections;

public class Pato : MonoBehaviour {

	public bool noChao = true;
	public float aceleracao = 0.9f;
	public float desAceleracao = 0.2f;
	public float gravidade = 0.9f;
	public float forcaPulo = 15f;
	public float maxVelocidadeX = 3;
	public float pontoAguaY = 1;	
	public float forcaAgua = 2f;

	private float velocidadeX;
	private float velocidadeY;
	private CapsuleCollider capsula;

	void Start () {
		capsula = (CapsuleCollider) transform.GetComponent ("CapsuleCollider");
	}
	
	void Update () {
		bool emBaixoDaAgua = rigidbody.transform.position.y < pontoAguaY;

		if (Physics.Raycast (transform.position, -transform.up, capsula.radius)) {
			noChao = true;
		} else {
			noChao = false;
		}
		if(Input.GetAxis("Horizontal") > 0){
			velocidadeX += aceleracao;
		}
		if(Input.GetAxis("Horizontal") < 0){
			velocidadeX -= aceleracao;
		}
		if(Input.GetButton("Jump") && (noChao || emBaixoDaAgua)){
			velocidadeY = forcaPulo;
			animation.Stop();
			animation.Play("jump");
		}
		
		velocidadeX = Mathf.MoveTowards (velocidadeX, 0, desAceleracao);
		velocidadeX = Mathf.Clamp(velocidadeX, -maxVelocidadeX, maxVelocidadeX);
		
		if(velocidadeY < gravidade && emBaixoDaAgua){
			velocidadeY += forcaAgua;
		}
		
		if(!noChao){
			velocidadeY -= gravidade;
		}
		
		rigidbody.velocity = new Vector3(velocidadeX * Time.deltaTime,velocidadeY * Time.deltaTime,0);
	}
}