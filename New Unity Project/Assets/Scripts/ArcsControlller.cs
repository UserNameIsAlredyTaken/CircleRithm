using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ArcsControlller : MonoBehaviour
{
    public List<GameObject> _arcs;
    public float _instantiationDelay;
    public float _growSpeed;
    public float _arcsLifeTime;

    void Start()
    {
        _arcsLifeTime = _arcs.Count * _instantiationDelay;
        StartCoroutine(InstantiateArcs());
    }

    private IEnumerator InstantiateArcs()
    {
        foreach (var arc in _arcs)
        {
            arc.SetActive(true);
            yield return new WaitForSeconds(_instantiationDelay);
        }
    }
}
