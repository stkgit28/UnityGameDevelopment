using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject muscle in GameObject.FindGameObjectsWithTag("Faded"))
             {
                Renderer myRenderer = muscle.GetComponent<Renderer>();
		Color solidColor = myRenderer.material.color;
         	Color fadedColor = new Color(solidColor.r, solidColor.g, solidColor.b, 0.2f);
                 myRenderer.material.color = Color.Lerp(solidColor, fadedColor, 1f);
             }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
