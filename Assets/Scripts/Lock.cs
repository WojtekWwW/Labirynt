using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    bool locked = false;
        Animator key;
    private bool iCanOpen;

    private void Start()
    {
        key = GetComponent<Animator>();        
    }

   private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && iCanOpen && !locked)
        {

        }
    }
}
