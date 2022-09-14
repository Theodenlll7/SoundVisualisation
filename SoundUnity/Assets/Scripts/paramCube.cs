using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paramCube : MonoBehaviour
{
    public int band;
    public float startScale, scaleMuliplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale= new Vector3(transform.localScale.x, (AudioP.freqBand[band] * scaleMuliplier) + startScale, transform.localScale.z);
    }
}
