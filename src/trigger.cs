using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    // Start is called before the first frame update
  void Start()
  {
        
  }

  // Update is called once per frame
    void Update()
  {
       
  }

  void OnColissionEnter() 
  {
    Debug.Log("Colission");
  }

  void OnTriggerEnter() 
  {
    Debug.Log("Is trigger");
  }
}
