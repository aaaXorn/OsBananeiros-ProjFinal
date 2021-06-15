using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodaCompartScript : MonoBehaviour
{
	public GameObject MagnetPrefab;
	
	public bool open;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void Screwdriver()
	{
		if(!open)
		{
			Instantiate(MagnetPrefab, transform.position + new Vector3(0, 0, 2), transform.rotation);
		}
	}
}
