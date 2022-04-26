using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeObstaculos : MonoBehaviour
{
    [SerializeField]
    private float intervaloDeCriacao;

    [SerializeField]
    private GameObject objeto;

    private float cronometro;

    private void Awake()
    {
        this.cronometro = intervaloDeCriacao;
    }
    private void Update()
    {
        this.cronometro -= Time.deltaTime;
        if (this.cronometro <= 0)
        {
            GameObject.Instantiate(objeto, this.transform.position, Quaternion.identity);
            this.cronometro = intervaloDeCriacao;
        }
    }
}
