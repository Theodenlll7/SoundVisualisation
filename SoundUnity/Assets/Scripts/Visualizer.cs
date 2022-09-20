using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualizer : MonoBehaviour
{
    public GameObject samplething;
    GameObject[] sampleCube = new GameObject[512];
    public float maxScale;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<512; i++)
        {
            GameObject instanceSampleCube = (GameObject)Instantiate(samplething);
            instanceSampleCube.transform.position = this.transform.position;
            instanceSampleCube.transform.parent = this.transform;
            instanceSampleCube.name = "samplecube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703123f * i, 0);
            instanceSampleCube.transform.position = Vector3.forward * 300;
            sampleCube[i] = instanceSampleCube;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 512; i++)
        {
            if (sampleCube != null)
            {

                sampleCube[i].transform.localScale = new Vector3(1, (AudioP.samples[i]*maxScale) + 1, 1);
                sampleCube[i].GetComponent<Renderer>().material.color = new Color(0, (AudioP.samples[i] * maxScale), 0);
            }
        }
    }
}
