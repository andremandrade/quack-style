using UnityEngine;
using System.Collections;

public class MovimentoPlayer : MonoBehaviour {
	
	public float aceleracao = 0.9f;
	public float desAceleracao = 0.2f;
	public float gravidade = 0.9f;
	public float forcaPulo = 15f;
	public float maxVelocidadeX = 3;
	public float pontoAguaY = 0.5f;	
	public float forcaAgua = 2f;

	private CharacterController jogador;
	private float velocidadeX;
	private float velocidadeY;
	private float anguloX;
	private float anguloY;


	
	void Start () {
		jogador = GetComponent<CharacterController>();
	}

	private Vector3 moveDirection = Vector3.zero;
	
	void Update () {
		bool emBaixoDaAgua = jogador.transform.position.y < pontoAguaY;
		bool naSuperficie = jogador.transform.position.y == pontoAguaY;

		anguloX = 90;

		if(Input.GetAxis("Horizontal") > 0){
			velocidadeX += aceleracao;
			anguloY = 90;
		}
		if(Input.GetAxis("Horizontal") < 0){
			velocidadeX -= aceleracao;
			anguloY = 270;
		}
		if(Input.GetButton("Jump") && (jogador.isGrounded || emBaixoDaAgua)){
			velocidadeY = forcaPulo;
		}
		
		velocidadeX = Mathf.MoveTowards (velocidadeX, 0, desAceleracao);
		velocidadeX = Mathf.Clamp(velocidadeX, -maxVelocidadeX, maxVelocidadeX);

		if(velocidadeY <= gravidade && emBaixoDaAgua){
			velocidadeY += forcaAgua;
			if(naSuperficie){
				velocidadeY = 0;
			}
		}
		
		if (!jogador.isGrounded) {
			velocidadeY -= gravidade;
			if (velocidadeY > 0) {
				anguloX = -30;
			}

			if (velocidadeY < 0) {
				anguloX = 30;
			}
		} 

		if(jogador.isGrounded || naSuperficie){
			anguloX = 0;
		}

		moveDirection.Set (velocidadeX * Time.deltaTime, velocidadeY * Time.deltaTime, 0);

		jogador.transform.rotation = Quaternion.Euler( new Vector3(anguloX, anguloY,0));
		jogador.Move(moveDirection );
	}
}
