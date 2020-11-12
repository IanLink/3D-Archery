using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
    
    //Detects collision with arrow and makes destroys the target

{
    public Vector2 partsMinMaxSpeed;

#pragma warning disable 0649 //Disables warning of "Field never assigned" since the fields will be manually set in the inspector
    [SerializeField]
    private Rigidbody[] partsR;
#pragma warning restore 0649

    private void Start()
    {
        //Invoke("HitTarget", 2f);//For testing purposes
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Target collision with: " + other.name);
        if (other.tag == "Arrow")
        {
            Debug.Log("Target Hit!");
            HitTarget();
        }
    }

    private void HitTarget() //Makes parts fly in random directions and random angular velocity
    {
        foreach (Rigidbody r in partsR)
        {
            r.isKinematic = false;
            r.velocity = Random.onUnitSphere * Random.Range(partsMinMaxSpeed.x, partsMinMaxSpeed.y);
            r.angularVelocity = Random.onUnitSphere * Random.Range(partsMinMaxSpeed.x, partsMinMaxSpeed.y);
            r.transform.SetParent(null, true);
            Debug.Log("Part position: " + r.transform.position);
        }
        Destroy(gameObject);
    }

    //public Vector3 RandomCubeDirection()//Gives a random direction in a cube within a minimum and a maximum
    //{
    //    return Vector3.right * RandomSignMinMax(partsMinSpeed, partsMaxSpeed) + Vector3.up * RandomSignMinMax(partsMinSpeed, partsMaxSpeed) + Vector3.forward * RandomSignMinMax(partsMinSpeed, partsMaxSpeed);
    //}

    //public float RandomSignMinMax(float min, float max)//Returns a random value between a min and a max with a random sign
    //{
    //    return Random.Range(min, max) * Mathf.Sign(Random.value - 0.5f);
    //}

}
