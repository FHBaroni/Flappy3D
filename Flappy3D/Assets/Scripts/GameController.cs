using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public GameObject cerca;
    public GameObject arbusto;
    public GameObject nuvem;
    public GameObject pedra;
    public GameObject cano;
    public GameObject particulas;

    public Text textoScore;

    bool comecou;
    bool acabou;

    int pontuacao;

    public GameObject player;

    void Start()
    {
        Physics.gravity = new Vector3(0,-33,0);
        textoScore.fontSize = 50;        
        textoScore.text = "Toque Para Iniciar";
    }
    
        void Update()
    {
        if (Input.anyKeyDown)
        {
            if (!acabou)
            {
                if (!comecou)
                {
                    comecou = true;
                    InvokeRepeating("CriaCerca", 1, 0.4f);
                    InvokeRepeating("CriaObjetos", 1, 0.75f);

                    player.GetComponent<Rigidbody>().useGravity = true;
                    player.GetComponent<Rigidbody>().isKinematic = false;

                    textoScore.text = pontuacao.ToString();
                    textoScore.fontSize = 70;
                    textoScore.alignment = TextAnchor.UpperCenter;
                    textoScore.rectTransform.anchorMin = new Vector2(0.5f, 1f);
                    textoScore.rectTransform.anchorMax = new Vector2(0.5f, 1f);
                    textoScore.rectTransform.pivot = new Vector2(0.5f, 1f);
                }
            VoaPlayer();
            }
        }

        player.transform.rotation = Quaternion.Euler(- player.GetComponent<Rigidbody>().velocity.y, 0, 0);

    }

    void CriaCerca()
    {
        Instantiate(cerca);
    }

    void CriaObjetos()
    {
        int sorteioObj = Random.Range(1, 5);

        float posicaoXrandom = Random.Range(-1.4f, 2.7f);
        float posicaoYrandom = Random.Range(1.25f, 4.5f);
        float rotacaoYrandom = Random.Range(0, 360);

        GameObject novoObj = new GameObject();

        switch (sorteioObj)
        {
            case 1: novoObj = Instantiate(pedra); posicaoYrandom = novoObj.transform.position.y; break;
            case 2: novoObj = Instantiate(arbusto); posicaoYrandom = novoObj.transform.position.y; break;
            case 3: novoObj = Instantiate(nuvem); break;
            case 4:
                novoObj = Instantiate(cano); posicaoYrandom = Random.Range(-2, 0.2f);
                posicaoXrandom = novoObj.transform.position.x; break;
            default: break;
        }
        novoObj.transform.position = new Vector3(posicaoXrandom, posicaoYrandom, novoObj.transform.position.z);
        novoObj.transform.rotation = Quaternion.Euler(novoObj.transform.rotation.x, rotacaoYrandom, novoObj.transform.rotation.z);

    }
    void VoaPlayer()
    {
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 10.0f, 0.0f);
        GameObject novaParticula = Instantiate(particulas);
        novaParticula.transform.position = player.transform.position + new  Vector3(0,1,0) ;
        player.SendMessage("SomVoa");
    }
   
    void FimDeJogo()
    {
        acabou = true;
        CancelInvoke("CriaCerca");
        CancelInvoke("CriaObjetos");
        Invoke(nameof(RecerregaCena), 1);
    }

    void MarcaPonto()
    {
        pontuacao++;
        textoScore.text = pontuacao.ToString();             
    }

    void RecerregaCena()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
