using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject cerca;
    public GameObject arbusto;
    public GameObject nuvem;
    public GameObject pedra;
    public GameObject cano;

    void Start()
    {
        InvokeRepeating("CriaCerca", 1, 0.4f);
        InvokeRepeating("CriaObjetos", 1, 0.75f);
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
            case 4 : novoObj = Instantiate(cano); posicaoYrandom =Random.Range(-2,0.2f);
                posicaoXrandom = novoObj.transform.position.x;break;
            default: break;
        }
        novoObj.transform.position = new Vector3(posicaoXrandom, posicaoYrandom, novoObj.transform.position.z);
        novoObj.transform.rotation = Quaternion.Euler(novoObj.transform.rotation.x,rotacaoYrandom, novoObj.transform.rotation.z);

    }
}
