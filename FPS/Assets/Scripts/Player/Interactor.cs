using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] Transform _interactionPoint;
    [SerializeField] private float interactionRange = .5f;
    [SerializeField] private LayerMask interactableMask;

    private readonly Collider[] _collider = new Collider[3];
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.direction * interactionRange;
        ray = new Ray(ray.origin, rayPoint);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && gameObject.tag != "Untagged")
        {
            // The ray hit something, you can now access information about the hit
            GameObject hitObject = hit.transform.gameObject;
            Debug.Log("Hit object: " + hitObject.tag);
            
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                Debug.Log("pick up");
            }
        }
    }
    private void interact(){
        
    }
}
