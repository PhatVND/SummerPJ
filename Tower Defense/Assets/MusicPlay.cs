using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlay : MonoBehaviour
{
    [SerializeField] public AudioSource  bgm;

    private void Start()
    {
        bgm.Play();
    }
}
