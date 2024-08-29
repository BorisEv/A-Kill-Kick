using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public static IEnumerator WaitForSecondsCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
