using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent (typeof (AudioSource))]
public class AudioP : MonoBehaviour
{
    private AudioSource audioSource;
    public static float[] samples = new float[512];
    public static float[] freqBand = new float[8];
    public static float[] bandbuffer = new float[8];
    float[] bufferdecrase = new float[8];
    public float changeRate = .5f;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();


        string microphonename = Microphone.devices[0];
        //audioSource.clip = Microphone.Start(microphonename, true, 10, 44100);
        audioSource.loop = true;
        //while (!(Microphone.GetPosition(null) > 0)) { }
        audioSource.Play();
    }


    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer2();
    }

    void GetSpectrumAudioSource() 
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {
        int count = 0;

        for(int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            if (i == 7) { sampleCount += 2; }
            for (int j = 0; j < sampleCount; j++) {
                average += samples[count]*(count+1);
                    count++;
            }
            average /= count;
            freqBand[i] = average * 10;
        }
    }

    void BandBuffer()
    {
        for(int i= 0; i < 8; ++i)
        {
            if (freqBand[i] > bandbuffer[i])
            {
                bandbuffer[i] = freqBand[i];
                bufferdecrase[i] = 0.005f;
            }
            if (freqBand[i] < bandbuffer[i])
            {
                bandbuffer[i] -= bufferdecrase[i];
                bufferdecrase[i] = 1.2f;
            }
        }
    }
    void BandBuffer2()
    {
        for (int i = 0; i < 8; ++i)
        {
            bandbuffer[i] = Mathf.Lerp(bandbuffer[i], samples[i], changeRate * Time.deltaTime);
        }
    }
}
