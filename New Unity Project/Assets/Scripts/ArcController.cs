using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using ProBuilder2.MeshOperations;
using UnityEngine;

public class ArcController : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Grow(GetComponentInParent<ArcsControlller>()._growSpeed, GetComponentInParent<ArcsControlller>()._arcsLifeTime));
    }

    private float _scale;
    private float _timePast;
    private IEnumerator Grow(float growSpeed, float lifeTime)
    {
        while (true)
        { 
            _scale += Mathf.Pow(_timePast,2) * growSpeed;
            _timePast += Time.deltaTime;
            transform.localScale = new Vector3(_scale, _scale, 1);
            
            if (_timePast > lifeTime)
            {
                _scale = 0;
                _timePast = 0;
            }
            yield return null;
        }
    }
}
