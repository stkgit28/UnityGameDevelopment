using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator _anim;
    private static readonly int IdleDoorAnim = Animator.StringToHash("idleDoor");
    private static readonly int OpenedDoorAnim = Animator.StringToHash("openedDoor");
    
    
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _anim.SetBool(OpenedDoorAnim, true); 
        _anim.SetBool(IdleDoorAnim, false);

    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        _anim.SetBool(IdleDoorAnim, true);
        _anim.SetBool(OpenedDoorAnim, false);

    }


    
}
