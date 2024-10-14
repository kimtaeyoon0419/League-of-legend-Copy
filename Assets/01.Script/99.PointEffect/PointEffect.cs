using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEffect : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.15f);
        Destroy(gameObject);
    }
}
