using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderController : MonoBehaviour
{
    private LadderMovement _ladderMovement;

    private void Start()
    {
        _ladderMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<LadderMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _ladderMovement.onLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _ladderMovement.onLadder = false;
        }
    }
}
