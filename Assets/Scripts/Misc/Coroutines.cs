using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Coroutines : MonoBehaviour
{
    private static Coroutines _instance;

    private static Coroutines Instance
    {
        get
        {
            if (_instance == null)
            {
                var go = new GameObject(name: "Coroutine Manager");
                _instance = go.AddComponent<Coroutines>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    public static Coroutine StartRoutine(IEnumerator enumerator)
    {
        return Instance.StartCoroutine(enumerator);
    }

    public static void StopRoutine(IEnumerator enumerator)
    {
       Instance.StopCoroutine(enumerator);
    }
}
