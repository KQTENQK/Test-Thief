using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class Sygnalization : MonoBehaviour
{
    [SerializeField] float _increaseVolumeRate = 0.2f;

    private AudioSource _audioSource;
    private const float _startVolume = 0.1f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            _audioSource.Play();
            StartCoroutine(Sygnalize());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            StopCoroutine(Sygnalize());
            _audioSource.Stop();
        }
    }

    private IEnumerator Sygnalize()
    {
        float currentVolume = _startVolume;
        float minVolume = 0f;
        float targetVolume = 1f;
        
        while (true)
        {
            currentVolume = Mathf.MoveTowards(currentVolume, targetVolume, _increaseVolumeRate * Time.deltaTime);
            _audioSource.volume = currentVolume;

            if (currentVolume >= 1 || currentVolume <= 0.1f)
            {
                float temp = targetVolume;
                targetVolume = minVolume;
                minVolume = temp;
            }

            yield return null;
        }
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _startVolume;
    }
}
