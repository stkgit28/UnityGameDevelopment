using UnityEngine;
using System.Collections;
public class dispare : MonoBehaviour
{
    public GameObject myGameObject;


    void Start()
    {
        //GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Renderer>().enabled = true;
        // gameObject.renderer.enabled = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Renderer>().enabled = false;
            // gameObject.renderer.enabled = false;
        }

    }
}