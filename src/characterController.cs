using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class characterController : MonoBehaviour
{
  // Start is called before the first frame update
  [Header("Personaje")]
  [Tooltip("velocidad del personaje")]
  public float velocidad = 2.0f;
  [Header("Con que teclas desea mover el personaje")]
  public bool wasd = true;
  public bool flechas = false;

  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
    if (wasd) {
      if (Input.GetKey("s")) {
        //Debug.Log("s");
        gameObject.transform.Translate(0, 0, -7 * Time.deltaTime * velocidad);
      }
      if (Input.GetKey("w")) {
        //Debug.Log("w");
        gameObject.transform.Translate(0, 0, 7 * Time.deltaTime * velocidad);
      }
      if (Input.GetKey("a")) {
        //Debug.Log("a");
        gameObject.transform.Translate(-7 * Time.deltaTime * velocidad, 0, 0);
      }
      if (Input.GetKey("d")) {
        //Debug.Log("d");
        gameObject.transform.Translate(7 * Time.deltaTime * velocidad, 0, 0);
      }
    }
    if (flechas) {
      /*float horizontalInput = Input.GetAxis("Horizontal");
      gameObject.transform.Translate(horizontalInput * velocidad * Time.deltaTime * 7, 0, 0);
      float verticalInput = Input.GetAxis("Vertical");
      gameObject.transform.Translate(0, 0, verticalInput * velocidad * Time.deltaTime * 7);*/
      if (Input.GetKey("down")) {
        //Debug.Log("down");
        gameObject.transform.Translate(0, 0, -7 * Time.deltaTime * velocidad);
      }
      if (Input.GetKey("up")) {
        //Debug.Log("up");
        gameObject.transform.Translate(0, 0, 7 * Time.deltaTime * velocidad);
      }
      if (Input.GetKey("left")) {
        //Debug.Log("left");
        gameObject.transform.Translate(-7 * Time.deltaTime * velocidad, 0, 0);
      }
      if (Input.GetKey("right")) {
        //Debug.Log("right");
        gameObject.transform.Translate(7 * Time.deltaTime * velocidad, 0, 0);
      }
    }
    if (Input.GetKeyDown("space")) {
      GameObject[] tipoA = GameObject.FindGameObjectsWithTag("tipoA");
      for (int i = 0; i < tipoA.Length; i++) {
        float distancia = Vector3.Distance(tipoA[i].transform.position, gameObject.transform.position);
        if (distancia < 10f) {
          tipoA[i].GetComponent<cilindroA>().pushCylinder(gameObject);
        }
      }
    }
    GameObject[] tipoB = GameObject.FindGameObjectsWithTag("tipoB");
    for (int i = 0; i < tipoB.Length; i++) {
      float distancia = Vector3.Distance(tipoB[i].transform.position, gameObject.transform.position);
      if (distancia < 10f) {
        tipoB[i].GetComponent<cilindroB>().pushCylinder(gameObject);
      }
    }
  }

  public void minim() {
    //Debug.Log("minim");
    gameObject.transform.localScale -= new Vector3(0.001f, 0.001f, 0.001f);
  }

  public void maxim() {
    gameObject.transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);
  }

}
