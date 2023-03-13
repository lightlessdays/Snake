using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgm : MonoBehaviour
{
    [SerializeField] GameObject audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(audioSource);
    }
}
