using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor,_offsetColor;//
    [SerializeField] private SpriteRenderer _renderer,_rendererClose;
    [SerializeField] private GameObject _highlight;


    public bool isOccupied;
  


    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();  
    }

    private void Update()
    {
        if (isOccupied==true) 
        {
            _renderer = _rendererClose;
        }
        else
        {
            
        }
    }
    public void Init(bool isOffset)
    {
        //_renderer.color = isOffset ? _renderer.color = Color.red : _renderer.color = Color.blue;
        _renderer = isOffset ? _rendererClose : _renderer;
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
