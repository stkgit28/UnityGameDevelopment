using TMPro;
using UnityEngine;

public class ButtonsTextController : MonoBehaviour
{
    public TextMeshProUGUI hintTextR;
    public TextMeshProUGUI hintTextQ;

    void Start ()
    {
        hintTextR.enabled = true;
        hintTextQ.enabled = false;
        Invoke(nameof(ChangeText), 5f);//invoke after 5 seconds
    }
    
    void DisableText()
    { 
        hintTextQ.enabled = false; 
    }

    void ChangeText()
    {
        hintTextR.enabled = false;
        hintTextQ.enabled = true; 
        Invoke(nameof(DisableText), 5f);//invoke after 5 seconds
    }
}
