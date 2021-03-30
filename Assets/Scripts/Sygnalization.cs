using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sygnalization : MonoBehaviour
{
    private AudioSource _audioSource;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            _audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            StartCoroutine(StopSygnalizeWithDelay());
        }
    }

    private IEnumerator StopSygnalizeWithDelay()
    {
        yield return new WaitForSeconds(0.5f);
        _audioSource.Stop();
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
}
