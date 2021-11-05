using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FootstepsHandler : MonoBehaviour
{
    [SerializeField] private AudioSource sound1;
    [SerializeField] private AudioSource sound2;
    [SerializeField] private AudioSource sound3;
    [SerializeField] private AudioSource sound4;
    [SerializeField] private AudioSource sound5;
    
    public void Footstep1()
    {
        sound1.Play();
    }
    public void Footstep2()
    {
        sound2.Play();
    }
    public void Footstep3()
    {
        sound3.Play();
    }
    public void Footstep4()
    {
        sound4.Play();
    }
    public void Footstep5()
    {
        sound5.Play();
    }
}
