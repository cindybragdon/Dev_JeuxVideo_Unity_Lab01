using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //itinialise les variables de déplacement des objects auquels sont reliés ce script
    private float speed = 20.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;

    private bool isVehiculeRunning;

    //J'ai écrit beaucoup trop de commentaire, mais je me servirai de ce projet comme référence.
    //Certains de ces commentaires proviennent du web ou de API Unity

    // Start is called before the first frame update
    void Start()
    {
        //Le véhicule est en marche au lancement
        isVehiculeRunning = true;
    }

    // Update is called once per frame
   
    void Update()
    {

        //Lorsqu'on appuie sur S (Stop) le véhicule ferme le moteur
        if(Input.GetKeyDown(KeyCode.S))
        {
            isVehiculeRunning = false;
        }

        //Lorsqu'on appuie sur G (Go) le véhicule ouvre le moteur
        else if(Input.GetKeyDown(KeyCode.G))
        {
            isVehiculeRunning = true;
        }

        //Laisse les flèches disponibles pour déplacer la voiture
        if(isVehiculeRunning)
        {
            //HorizontalInput récupère les valeurs horizontales A D
            //renvoie une valeur entre -1 et 1, 
            //où -1 signifie une pression complète vers la gauche, 1 une pression complète vers la droite, et 0 aucune pression.
            //Ces explications viennent de ChatGPT
            horizontalInput = Input.GetAxis ("Horizontal"); 
            forwardInput = Input.GetAxis ("Vertical"); 
            
            //Déplace la voiture vers l'avant ou l'arrière
            //Vector3.forward = vecteur pointant dans la direction avant de l'objet
            //Time.deltaTime = Temps écoulé depuis la dernière image
            //forwardInput = est la valeur récupérée des entrées utilisateur (haut/bas)
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

            //Fait tourner la voiture
            //transform.Rotate = Cette ligne fait tourner le véhicule autour de l'axe vertical (axe Y) 
            //Vector3.up = représente l'axe Y, autour duquel la rotation se produit
            //horizontalInput = est la valeur récupérée des entrées utilisateur (gauche/droite)
            //Time.deltaTime = garantit que la rotation est lissée en fonction du temps
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }
    }
}
