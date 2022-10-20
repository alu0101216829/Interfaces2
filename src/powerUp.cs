using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
    GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
    for (int i = 0; i < player.Length; i++) {
      float distancia = Vector3.Distance(player[i].transform.position, gameObject.transform.position);
      if (distancia < 3f) {
        player[i].GetComponent<characterController>().minim();
      } 
    }

    GameObject[] sphere = GameObject.FindGameObjectsWithTag("Sphere");
    for (int i = 0; i < sphere.Length; i++) {
      float distancia = Vector3.Distance(sphere[i].transform.position, gameObject.transform.position);
      if (distancia < 3f) {
        player[i].GetComponent<characterController>().maxim();
      } 
    }
  }

private void OnCollisionEnter(Collision collision) {
  /*if (collision.transform.tag == "Player") {
    gameObject.transform.localScale -= new Vector3(1f, 1f, 1f);
  }
  if (collision.transform.tag == "Sphere") {
    gameObject.transform.localScale += new Vector3(1f, 1f, 1f);
  }*/
}
}
