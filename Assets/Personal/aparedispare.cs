using UnityEngine;
using System.Collections;

public class aparedispare : MonoBehaviour
{
    public GameObject myGameObject;

    //public DemoCollegeStudentController MyPlayer;

    void Start()
    {
        //GetComponent<MeshRenderer>().enabled = true;
        transform.Find("semn2").GetComponent<Renderer>().enabled = false;
        transform.Find("semn").GetComponent<Renderer>().enabled = true;
    // gameObject.renderer.enabled = true;
    }

    private void Update()
    {
        Restart();
    }

        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //GetComponent<MeshRenderer>().enabled = false;
            transform.Find("semn2").GetComponent<Renderer>().enabled = true;
            transform.Find("semn").GetComponent<Renderer>().enabled = false;
            // gameObject.renderer.enabled = false;
            //transform.Find("MyPlayer").cun++;
        }

    }


        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                transform.Find("semn2").GetComponent<Renderer>().enabled = false;
                transform.Find("semn").GetComponent<Renderer>().enabled = true;
            }
        }
}
