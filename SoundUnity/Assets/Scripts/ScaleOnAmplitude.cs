using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnAmplitude : MonoBehaviour
{
    public float startScale, maxScale;
    public bool useBuffer;
    Material _material;
    public float red, green, blue;
    void Start()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!useBuffer)
        {
            transform.localScale=new Vector3((AudioP.Amplitude*maxScale)+startScale, (AudioP.Amplitude*maxScale)+startScale, (AudioP.Amplitude*maxScale)+startScale);
            Color color = new Color(red * AudioP.Amplitude, green * AudioP.Amplitude, blue * AudioP.Amplitude);
            _material.SetColor("_EmissionColor", color);
        }
        if (useBuffer)
        {
            transform.localScale = new Vector3((AudioP.AmplitudeBuffer * maxScale) + startScale, (AudioP.AmplitudeBuffer * maxScale) + startScale, (AudioP.AmplitudeBuffer * maxScale) + startScale);
            Color color = new Color(red * AudioP.AmplitudeBuffer, green * AudioP.AmplitudeBuffer, blue * AudioP.AmplitudeBuffer);
            _material.SetColor("_EmissionColor", color);
        }
    }
}
