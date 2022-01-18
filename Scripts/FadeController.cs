using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{

    public Animator animator;
    
    private static readonly int FadeOut = Animator.StringToHash("FadeOut");
    private static readonly int FadeIn = Animator.StringToHash("FadeIn");
    
    private int nextLevel;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void FadeToLevel(int levelIndex)
    {
        nextLevel = levelIndex;
        animator.SetTrigger(FadeIn);
        Invoke(nameof(GoToNextLevel),3f);
    }

    private void GoToNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

 
}
