using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim = null;

    void Start()
    {
        GetRefrences();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if(AudioP.bandbuffer[0] > 1)
        {
            anim.SetFloat("Speed", 1, 0.3f, Time.deltaTime);
        

        }

      
    

    }

    private void GetRefrences()
    {
        anim = GetComponentInChildren<Animator>();
    }


}
