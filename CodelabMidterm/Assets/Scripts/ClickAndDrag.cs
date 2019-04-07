using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
	//making a clickNDrag image, without fungus
	private Vector3 offset; 
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDrag()
	{
		Vector3 newPosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y,10f);
		transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
	}

	void OnMouseDown()
	{
		offset = gameObject.transform.position -
		         Camera.main.ScreenToWorldPoint((new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f)));
	}
}
