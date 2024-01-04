using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvents_Test : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
    }
    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(Vector3.Distance(player.position, transform.position) <= 12)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                player.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            } else
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
    }
    private void OnMouseExit()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
    }
}
