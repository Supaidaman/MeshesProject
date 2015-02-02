using UnityEngine;
using System.Collections;

public class applyTexWithMouse : MonoBehaviour {


    public Texture2D tex;
   
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(2)) {
           RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.renderer != null)
            {
                Debug.Log("oi");

                hit.transform.gameObject.renderer.material.mainTexture = tex;
            }
            else
            {
                Debug.Log("nooo");
            }

         }
	}
}
