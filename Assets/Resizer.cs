using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resizer : MonoBehaviour {
    private Vector2 cellSize;
    // Use this for initialization
    void Start () {
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
        Vector2 cellSize = GetComponent<GridLayoutGroup>().cellSize;
        
          
        
    }
	
	// Update is called once per frame
	void Update () {

        //727:75= Screen.width:x
        
        //409:100=Screen.height:x
        float resulty = (100 * Screen.height) / 536;
        float resultx = (75 * Screen.width) / 953;
        GetComponent<GridLayoutGroup>().cellSize = new Vector2(resultx,resulty);


    }
}
