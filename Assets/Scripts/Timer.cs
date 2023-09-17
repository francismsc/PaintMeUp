using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    int roundTimer;

    public static event Action<int> OnTimeUpdate;

    private void OnEnable()
    {
        Controller.OnTimerStart += () => StartCoroutine(Countdown());
        Controller.OnRightColor += () => StopCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        for(int i = roundTimer; i>0; i--)
        {
            OnTimeUpdate.Invoke(i);
            yield return new WaitForSeconds(1);
        }
    }
}
