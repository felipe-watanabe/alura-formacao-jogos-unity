using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField]
    private float velocidade = 0.25f;

    [SerializeField]
    private float variacaoEixoY;

    private Vector3 posicaoAviao;

    private bool pontuei;

    private Pontuacao pontuacao;

    private void Awake()
    {
        this.transform.Translate(Vector3.up * Random.Range(-variacaoEixoY, variacaoEixoY));
    }

    private void Start()
    {
        this.posicaoAviao = GameObject.FindObjectOfType<Aviao>().transform.position;
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }

    private void Update() 
    {
        this.transform.Translate(Vector3.left * this.velocidade * Time.deltaTime);

        if (!pontuei && this.transform.position.x < this.posicaoAviao.x)
        {
            this.pontuacao.AdicionarPontos();
            pontuei = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        this.Destruir();
    }

    public void Destruir()
    {
        GameObject.Destroy(this.gameObject);
    }
}
