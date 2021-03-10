using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] private GameObject _base;
    [SerializeField] private GameObject _ballonNode;
    private LineRenderer _lineRenderer;
    private void OnEnable()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        _lineRenderer.SetPosition(0, _base.transform.position);
        _lineRenderer.SetPosition(1, _ballonNode.transform.position);
    }

    public GameObject Base
    {
        get => _base;
        set => _base = value;
    }
}
