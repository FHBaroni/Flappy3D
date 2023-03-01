using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip somBate;
    public AudioClip somPonto;
    public AudioClip somVoa; 
    public GameObject cameraPrincipal;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            Debug.Log("bateu");
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 6.0f, -10.0f);
            GetComponent<Rigidbody>().AddTorque(new Vector3(-100.0f, -100.0f, -100.0f));
            cameraPrincipal.SendMessage("FimDeJogo");  
            GetComponent<AudioSource>().PlayOneShot(somBate);
        }     
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "GameController")
        {
            cameraPrincipal.SendMessage("MarcaPonto");
            GetComponent<AudioSource>().PlayOneShot(somPonto);
        }
    }
    
    void SomVoa()
    {
        GetComponent<AudioSource>().PlayOneShot(somVoa);
    }
}
