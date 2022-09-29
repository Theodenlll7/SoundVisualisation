using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyBoxChanger : MonoBehaviour
{
    public Material mat;
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
        if (useBuffer) {
            if (AudioP.bandbuffer[band] * scaleMuliplier >= 4) { mat.SetFloat("_sizeY",15); }
            mat.SetFloat("_sizeY", AudioP.bandbuffer[band] * scaleMuliplier);
           
            
        }
        else
        {
            if (AudioP.bandbuffer[band] * scaleMuliplier >= 4) { mat.SetFloat("_sizeY", 15); }
            else { 
            mat.SetFloat("_sizeY", AudioP.freqBand[band] * scaleMuliplier);
                // mat.SetFloat("_sizeX,", AudioP.freqBand[band] * scaleMuliplier);
            }

        }
    }
}
