using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CallerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void LlamarEscena(string nombreEscena)
    {
        //cambia la escena
        SceneManager.LoadScene(nombreEscena);
    }

    public void Exit()
    {
        Debug.Log("cerrando");
        Application.Quit();
    }
}
