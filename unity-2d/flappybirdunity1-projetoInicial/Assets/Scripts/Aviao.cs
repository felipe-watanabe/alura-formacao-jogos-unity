using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aviao : MonoBehaviour
{
    private Rigidbody2D fisica;

    [SerializeField]
    private float forca = 10f;

    private Diretor diretor;

    private Vector3 posicaoInicial;

    private AudioSource audioSource;

    private AudioClip[] memes;

    public void Reiniciar()
    {
        this.transform.position = this.posicaoInicial;
        this.fisica.simulated = true;
    }

    private void Awake()
    {
        this.fisica = this.GetComponent<Rigidbody2D>();
        this.posicaoInicial = this.transform.position;
        this.audioSource = this.GetComponent<AudioSource>();
        this.memes = Resources.LoadAll<AudioClip>("Audio/Colisao");
        Debug.Log(memes);
    }

    private void Start()
    {
        this.diretor = GameObject.FindObjectOfType<Diretor>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            this.Impulsionar();
        }
    }

    private void OnCollisionEnter2D(Collision2D colisao)
    {
        this.fisica.simulated = false;
        int index = Random.Range(0, 5);
        this.audioSource.clip = memes[index];
        Debug.Log(index);
        this.audioSource.Play();
        this.diretor.FinalizarJogo();
    }

    private void Impulsionar()
    {
        this.fisica.velocity = Vector2.zero;
        this.fisica.AddForce(Vector2.up * this.forca, ForceMode2D.Impulse);
    }
}
