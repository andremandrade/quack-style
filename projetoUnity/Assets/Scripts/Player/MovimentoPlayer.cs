using UnityEngine;
using System.Collections;

public class MovimentoPlayer : MonoBehaviour {
	
	public float aceleracao = 0.9f;
	public float desAceleracao = 0.2f;
	public float gravidade = 0.9f;
	public float forcaPulo = 15f;
	public float maxVelocidadeX = 3;
	public float pontoAguaY = 1;	
	public float forcaAgua = 2f;

	private CharacterController jogador;
	private float velocidadeX;
	private float velocidadeY;

	
	void Start () {
		jogador = GetComponent<CharacterController>();
	}
	
	void Update () {
		bool emBaixoDaAgua = jogador.transform.position.y < pontoAguaY;

		if(Input.GetAxis("Horizontal") > 0){
			velocidadeX += aceleracao;
		}
		if(Input.GetAxis("Horizontal") < 0){
			velocidadeX -= aceleracao;
		}
		if(Input.GetButton("Jump") && (jogador.isGrounded || emBaixoDaAgua)){
			velocidadeY = forcaPulo;
		}
		
		velocidadeX = Mathf.MoveTowards (velocidadeX, 0, desAceleracao);
		velocidadeX = Mathf.Clamp(velocidadeX, -maxVelocidadeX, maxVelocidadeX);

		if(velocidadeY < gravidade && emBaixoDaAgua){
			velocidadeY += forcaAgua;
		}
		
		if(!jogador.isGrounded){
			 velocidadeY -= gravidade;

		}
		
		jogador.Move(new Vector3(velocidadeX * Time.deltaTime,velocidadeY * Time.deltaTime,0));
		
	}
}
