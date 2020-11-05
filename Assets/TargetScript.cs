using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float partsMinSpeed, partsMaxSpeed;

#pragma warning disable 0649 //Disables warning of "Field never assigned" since the fields will be manually set in the inspector
    [SerializeField]
    private Rigidbody[] partsR;
#pragma warning restore 0649

    private void Start()//Testing purpose
    {
        Invoke("HitTarget", 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Arrow")
        {
            HitTarget();
        }
    }

    private void HitTarget() //Makes parts fly in random directions
    {
        foreach (Rigidbody r in partsR)
        {
            r.isKinematic = false;
            r.velocity = RandomPartDirection();  
        }
    }

    public Vector3 RandomPartDirection()//Gives a random direction in a sphere within a minimum and a maximum
    {
        return Vector3.right * RandomSignMinMax(partsMinSpeed, partsMaxSpeed) + Vector3.up * RandomSignMinMax(partsMinSpeed, partsMaxSpeed) + Vector3.forward * RandomSignMinMax(partsMinSpeed, partsMaxSpeed);
    }

    public float RandomSignMinMax(float min, float max)//Returns a random value between a min and a max with a random sign
    {
        return Random.Range(min, max) * Mathf.Sign(Random.value - 0.5f);
    }

}
