using UnityEngine;
using System.Collections;

public class MovimentoPlayer : MonoBehaviour {
	
	public float aceleracao = 0.9f;
	public float desAceleracao = 0.2f;
	public float gravidade = 0.9f;
	public float forcaPulo = 10f;
	public float maxVelocidadeX = 3;
	
	private CharacterController jogador;
	private float velocidadeX;
	private float velocidadeY;
	
	void Start () {
		jogador = GetComponent<CharacterController>();
	}
	
	void Update () {
		if(Input.GetAxis("Horizontal") > 0){
			velocidadeX += aceleracao;
		}
		if(Input.GetAxis("Horizontal") < 0){
			velocidadeX -= aceleracao;
		}
		if(Input.GetButton("Jump") && jogador.isGrounded){
			velocidadeY = forcaPulo;
		}
		
		velocidadeX = Mathf.MoveTowards (velocidadeX, 0, desAceleracao);
		velocidadeX = Mathf.Clamp(velocidadeX, -maxVelocidadeX, maxVelocidadeX);
		
		if(!jogador.isGrounded){
			velocidadeY -= gravidade;
		}
		
		jogador.Move(new Vector3(velocidadeX * Time.deltaTime,velocidadeY * Time.deltaTime,0));
		
	}
}
