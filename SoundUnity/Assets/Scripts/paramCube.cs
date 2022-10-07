using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paramCube : MonoBehaviour
{
    public int maxScale;
    public int band;
    public float startScale, scaleMuliplier;
    public bool useBuffer;

    public bool uselightbuffer;
    public float lightminimiser;

    Material _material;
    void Start()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        float _scale = startScale;
        if (useBuffer)
        {
            _scale = AudioP.bandbuffer[band] * scaleMuliplier + startScale < maxScale ? AudioP.bandbuffer[band] * scaleMuliplier + startScale : maxScale;
        }
        else
        {
            _scale = AudioP.freqBand[band] * scaleMuliplier +startScale < maxScale ? AudioP.freqBand[band] * scaleMuliplier + startScale : maxScale;
        }
        Color _color = new Color();
        if (uselightbuffer) _color = _scale < (maxScale / 4) ? 
                new Color(AudioP.audioBandbuffer[band]/lightminimiser, AudioP.audioBandbuffer[band]/lightminimiser, AudioP.audioBandbuffer[band]/lightminimiser)
                : new Color(AudioP.audioBandbuffer[band], AudioP.audioBandbuffer[band], AudioP.audioBandbuffer[band]);
        else _color = new Color(AudioP.audioBand[band], AudioP.audioBand[band], AudioP.audioBand[band]);
        transform.localScale = new Vector3(transform.localScale.x, _scale, transform.localScale.z);
        _material.SetColor("_EmissionColor", _color);

        /*
        if (useBuffer)
        {
            if ((AudioP.bandbuffer[band] * scaleMuliplier) + startScale > maxScale)
            {
                transform.localScale = new Vector3(transform.localScale.x, maxScale, transform.localScale.z);

                Color _color = new Color(AudioP.audioBandbuffer[band], AudioP.audioBandbuffer[band], AudioP.audioBandbuffer[band]);
                _material.SetColor("_EmissionColor", _color);
            }
            else
            {
                if (uselightbuffer)
                {
                    if ((AudioP.bandbuffer[band] * scaleMuliplier) + startScale < maxScale / 2)
                    {
                        transform.localScale = new Vector3(transform.localScale.x, (AudioP.bandbuffer[band] * scaleMuliplier) + startScale, transform.localScale.z);
                        Color _color = new Color(AudioP.audioBandbuffer[band] - lightminimiser, AudioP.audioBandbuffer[band] - lightminimiser, AudioP.audioBandbuffer[band] - lightminimiser);
                        _material.SetColor("_EmissionColor", _color);
                    }
                    else
                    {

                        transform.localScale = new Vector3(transform.localScale.x, (AudioP.bandbuffer[band] * scaleMuliplier) + startScale, transform.localScale.z);

                        Color _color = new Color(AudioP.audioBandbuffer[band], AudioP.audioBandbuffer[band], AudioP.audioBandbuffer[band]);
                        _material.SetColor("_EmissionColor", _color);
                    }
                }
                else
                {
                    transform.localScale = new Vector3(transform.localScale.x, (AudioP.bandbuffer[band] * scaleMuliplier) + startScale, transform.localScale.z);

                    Color _color = new Color(AudioP.audioBandbuffer[band], AudioP.audioBandbuffer[band], AudioP.audioBandbuffer[band]);
                    _material.SetColor("_EmissionColor", _color);
                }


            }

        }
        else
            transform.localScale = new Vector3(transform.localScale.x, (AudioP.freqBand[band] * scaleMuliplier) + startScale, transform.localScale.z);*/
    }
}
