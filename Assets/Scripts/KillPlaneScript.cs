using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlaneScript : MonoBehaviour

    //Script for destroying objects that fall off the screen

{
#pragma warning disable 0649 //Disables warning of "Field never assigned" since the fields will be manually set in the inspector
    [SerializeField]
    private bool debug;
#pragma warning restore 0649

    private void OnTriggerEnter(Collider other)

    //Since Unity decided that changing isKinematic triggers OnTriggerExit, I had to make this weird box of box colliders and use OnTriggerEnter instead

    {
        if (debug)
        {
            Debug.Log("Kill Plane touching: " + other.name + " at position: " + other.transform.position);
        }
        if (other.tag != "Kill Box" && other.tag != "MainCamera")
        {
            Destroy(other.gameObject);
        }
    }
}
