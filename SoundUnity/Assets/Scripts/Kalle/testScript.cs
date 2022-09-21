using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{

    public int band;
    public float startScale, scaleMuliplier;
    public bool useBuffer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioP.bandbuffer[band] * scaleMuliplier) + startScale, transform.localScale.z);
        }
        if (!useBuffer)
            transform.localScale = new Vector3(transform.localScale.x, (AudioP.freqBand[band] * scaleMuliplier) + startScale, transform.localScale.z);

    }
}
