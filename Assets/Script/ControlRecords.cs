using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlRecords : MonoBehaviour
{
    [SerializeField]
    Text recordmenu;
    // Start is called before the first frame update
    void Start()
    {
        //rescata el record del juego
        recordmenu.text = "Record: " + PlayerPrefs.GetInt("PuntosRecord", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
