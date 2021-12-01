using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    [FormerlySerializedAs("Target")] public GameObject target;
    private Vector3 _offset;


    // Start is called before the first frame update
    void Start() {

        _offset = transform.position - target.transform.position;
        
    }

    // Update is called once per frame
    void Update() {
    
        transform.position = target.transform.position+_offset;

        
    }
}
