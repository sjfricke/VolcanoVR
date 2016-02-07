using UnityEngine;
using System.Collections;

public class LocationMarkerDetect : MonoBehaviour {

    private RaycastHit hit;
    public Material locationMarketLookMaterial;
    public Material locationMarketNoLookMaterial;
    private Renderer currentItemLooked;
    public GameObject CardboardObject;
    private MeshRenderer[] currentLocation = null;
    public MeshRenderer startingMesh0;
    public MeshRenderer startingMesh1;
    private string currentName = "";
    private Vector3 destination;

    // Use this for initialization
    void Start () {        
        startingMesh0.GetComponent<Renderer>().enabled = false;
        startingMesh1.GetComponent<Renderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
           
            if (hit.transform.name == "InsideMarker" && currentName != "LocationMarkerTop") { return; }
            

            currentItemLooked = hit.collider.GetComponent<Renderer>();
            currentItemLooked.material = locationMarketLookMaterial;
            if (Input.GetMouseButton(0))
            {
                if (hit.transform.name == "InsideMarker" && currentName == "LocationMarkerTop") { Application.LoadLevel("CalibrationScreen"); }

                if (currentLocation != null) //starting
                {
                    currentLocation[0].GetComponent<Renderer>().enabled = true; //turns on LM from where leaving
                    currentLocation[1].GetComponent<Renderer>().enabled = true;
                } else
                {
                    startingMesh0.GetComponent<Renderer>().enabled = true;
                    startingMesh1.GetComponent<Renderer>().enabled = true;
                }
                                          
                currentLocation = hit.transform.parent.gameObject.GetComponentsInChildren<MeshRenderer>();
                currentName = hit.transform.parent.gameObject.transform.name;
                currentLocation[0].GetComponent<Renderer>().enabled = false;
                currentLocation[1].GetComponent<Renderer>().enabled = false;

                StartCoroutine(MyMethod(hit.transform.position));
                //CardboardObject.transform.position = hit.transform.position; //moves to location
            }
        } 
        else
        {
            if (currentItemLooked != null)
            {
                currentItemLooked.material = locationMarketNoLookMaterial;
            }
        }
    }

    IEnumerator MyMethod(Vector3 dest)
    {
        int count = 0;
        float final = 0;
        while (count < 60)
        {
            if (count > 30 && count < 53) final += .001f;
            CardboardObject.transform.position = Vector3.Lerp(CardboardObject.transform.position, dest, final + .012f);
            yield return new WaitForSeconds(.01f);
            count++;
        }
        CardboardObject.transform.position = dest;
        
    }

}
