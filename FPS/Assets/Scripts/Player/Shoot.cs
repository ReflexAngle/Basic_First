using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float damage = 10f;

    [SerializeField] private float range = 100f;

    [SerializeField] private float coolDown;
    [SerializeField] private Camera POV;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)){ Fire();}
    }

    private void Fire()
    {
        Debug.Log("Fire");
        RaycastHit hit;
        // shoots out a ray from the camera position
        if (Physics.Raycast(POV.transform.position, POV.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Debug.Log(tag);
            if (hit.transform.tag == "Enemy")
            {
                Debug.Log("destroy");
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
