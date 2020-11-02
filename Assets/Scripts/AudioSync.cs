using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSync : MonoBehaviour
{

    public float bias;
    public float timeStep;
    public float timeToBeat;
    public float restSmoothTime;

    private float m_previousAudioValue;
    private float m_audioValue;
    private float m_timer;

    protected bool m_isBeat;



    private void Start()
    {
        
    }

    public virtual void OnUpdate()
    {
        m_previousAudioValue = m_audioValue;
        m_audioValue = AudioEngine.spectrumValue;

        if (m_previousAudioValue > bias && m_audioValue <= bias)
        {

            if (m_timer > timeStep)
            {
                OnBeat();
            }

        }

        if (m_previousAudioValue <= bias && m_audioValue > bias)
        {

            if (m_timer > timeStep)
            {
                OnBeat();
            }


        }

        m_timer += Time.deltaTime;

    }

    public virtual void OnBeat()
    {
        Debug.Log("beat");
        m_timer = 0;
        m_isBeat = true;



    }




    private void Update()
    {
        OnUpdate();
    }
}
