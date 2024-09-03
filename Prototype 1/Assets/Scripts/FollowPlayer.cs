using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    //décalage de la caméra sur le joueur
    private Vector3 offset = new Vector3(0,5,-15);

    //Sera exécuté une fois au démarrage
    void Start()
    {
        
    }

    //Sera exécuté à chaque frame
    //Met à jour la position de la caméra à chaque frame
    void LateUpdate()
    {
        //Situe le joueur visé par le script et place la caméra selon le offset déclaré
        transform.position = player.transform.position + offset;
    }
}
