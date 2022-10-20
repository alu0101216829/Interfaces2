using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter() 
    {
        Debug.Log("colision");
        gameObject.transform.localScale += new Vector3(0.1f + Time.deltaTime, 0.1f + Time.deltaTime, 0.1f + Time.deltaTime);
    }
}
