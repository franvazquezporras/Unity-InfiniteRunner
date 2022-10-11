using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMoneda : MonoBehaviour
{

   

 

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0f, 0f, 45f)*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D item)
    {
        if (item.gameObject.name == "Player")
            GameObject.Destroy(gameObject);        
    }

    
    
}
