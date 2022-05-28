using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public AudioClip pickedClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
    public virtual void  Picked()
    {
        Debug.Log("Picked!");
        Destroy(this.gameObject);
    }
    public void Rotation()
    {
        transform.Rotate(new Vector3(1f, 0, 0));
    }
}
