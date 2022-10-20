using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cilindroB : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
    
  }

  public void pushCylinder(GameObject player) {
    Vector3 fuerzas = (gameObject.transform.position - player.transform.position) * 10;
    gameObject.GetComponent<Rigidbody>().AddForce(fuerzas);
  }

  /*private void OnCollisionEnter(Collision collision) {
    if (collision.transform.tag == "Player") {
      GameObject player = GameObject.FindWithTag("Player");
      Vector3 fuerzas = (gameObject.transform.position - player.transform.position/100) * 100000;
      gameObject.GetComponent<Rigidbody>().AddForce(fuerzas);
    }
  }*/
}
