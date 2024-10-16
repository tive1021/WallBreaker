using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource _ballPopaudioSource;
    [SerializeField] private AudioSource _brickPopaudioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void BallPop()
    {
        _ballPopaudioSource.Play();
    }

    public void BrickPop()
    {
        _brickPopaudioSource.Play();
    }

}
