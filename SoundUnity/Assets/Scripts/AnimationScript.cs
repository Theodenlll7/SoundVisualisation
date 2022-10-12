using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public Material mat;
    public int band;
    public float startScale, scaleMuliplier;
    public bool useBuffer;
    public Animator animator;
    public Animator animator1;
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        if (useBuffer)
        {

            mat.SetFloat("_sizeY", AudioP.bandbuffer[band] * scaleMuliplier);
            if (AudioP.bandbuffer[0] > AudioP.bandbuffer[6])
            {
                animator.SetBool("Bass", true);
                animator1.SetBool("Bass", true);
            }
            else
            {
                animator.SetBool("Bass", false);
                animator1.SetBool("Bass", false);

            }

        }
        else
        {

            mat.SetFloat("_sizeY", AudioP.freqBand[band] * scaleMuliplier);
            // mat.SetFloat("_sizeX,", AudioP.freqBand[band] * scaleMuliplier);


        }
    }
}