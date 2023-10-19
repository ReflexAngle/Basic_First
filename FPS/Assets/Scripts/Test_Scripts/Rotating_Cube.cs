using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating_Cube : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
    private void Rotation(){
        transform.Rotate (Vector3.right * rotationSpeed * Time.deltaTime, Space.World);
        transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World );
    }
}
