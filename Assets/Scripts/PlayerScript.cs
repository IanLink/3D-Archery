using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
#pragma warning disable 0649 //Disables warning of "Field never assigned" since the fields will be manually set in the inspector
    [Header("References")]
    [SerializeField]
    private GameObject arrow;
    
    [Header("Variables")]
    [SerializeField]
    private float arrowSpeed;

#pragma warning restore 0649

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject _arrow = Instantiate(arrow, transform.position, Quaternion.identity);
            _arrow.GetComponent<Rigidbody>().velocity = _arrow.transform.forward * arrowSpeed;
        }
    }
}
