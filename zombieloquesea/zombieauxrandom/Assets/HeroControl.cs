using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Enemy;
using NPC.Ally;


public class HeroControl : MonoBehaviour
{

    public Color col;
    public static System.Random veloRamdHeroe = new System.Random();
    public readonly float veloHeroe = veloRamdHeroe.Next (10, 14);
    public GameObject finalMensaje;

   GameObject empty;

    void Start()
    {

       
        GetComponent<MeshRenderer>().material.color = col;

        empty = new GameObject();
        empty.name = "Camera";
        empty.AddComponent<Camera>();
        empty.AddComponent<FPSim>();
        empty.transform.SetParent(this.transform);
        empty.transform.localPosition = Vector3.zero;

        GameObject heroe = gameObject;

        heroe.AddComponent<MoveHeroe>();
        heroe.GetComponent<MoveHeroe>().myVelo = veloHeroe;
        heroe.GetComponent<MoveHeroe>().veloCam = empty.GetComponent<FPSim>();

        finalMensaje = GameObject.Find("GAME OVER");
        finalMensaje.SetActive(false);// esto es para que le mensaje no se muestra desde el principio

    }


    

    void Update()
    {
 

    }

    

    private void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.name == "podrido")
        {
            finalMensaje.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
