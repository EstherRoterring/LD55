using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DontDestroy : MonoBehaviour
{
    [SerializeField] GameObject musicManager;
    void Awake()
    {
        DontDestroyOnLoad(musicManager);
    }
}
