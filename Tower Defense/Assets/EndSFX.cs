using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSFX : MonoBehaviour
{
    [SerializeField] private AudioSource endPathSFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            endPathSFX.Play();
        }
    }
}