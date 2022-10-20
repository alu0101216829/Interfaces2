using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cilindroA : MonoBehaviour
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
    Vector3 fuerzas = (gameObject.transform.position - player.transform.position) * 100;
    gameObject.GetComponent<Rigidbody>().AddForce(fuerzas);
  }
}
