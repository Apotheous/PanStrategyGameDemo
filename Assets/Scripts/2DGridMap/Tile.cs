using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    public void Init(bool isOffset)
    {
        //_renderer.color = isOffset ? _renderer.color = Color.red : _renderer.color = Color.blue;
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    private void OnMouseEnter()
    {
        if (_highlight != null)
        {
            _highlight.SetActive(true);
        }
    }    
    private void OnMouseExit()
    {
        if (_highlight != null)
        {
            _highlight.SetActive(false);
        }
    }
}
