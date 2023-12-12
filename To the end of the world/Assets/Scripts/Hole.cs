using System;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace DefaultNamespace
{
    public class Hole : MonoBehaviour
    {
        //le gameobject ou on veut que le player ressorte en remontant
        public GameObject sortie;
        //l'id de ce trou
        public int number;
        //la scene et l'id du tunel vers lequel il mène
        public String nextTunelScene;
        public int nextTunelNumber;

        private GameManager gameManager;

        private void Start()
        {
            gameManager = GameManager.Instance;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                gameManager.StartCoroutine(gameManager.goDown(this));
                
            }
        }
    }
}