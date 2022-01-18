using System;
using UnityEngine;

public class UpDownPlatform : MonoBehaviour
{
    public float delta = 6.0f;  
    public float speed = 1f;
    private Vector3 _startPos;
    void Start()
    {
        _startPos = transform.position;
    }

    void FixedUpdate()
    {
        Vector3 v = _startPos;
        v.y += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var emptyObject = new GameObject();
                
            emptyObject.tag="Empty";
            emptyObject.transform.parent = transform;
            collision.gameObject.transform.parent = emptyObject.transform;
        }
        
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            collision.gameObject.transform.SetParent(null);
            Destroy (GameObject.FindWithTag("Empty"));
        }
    }
}
