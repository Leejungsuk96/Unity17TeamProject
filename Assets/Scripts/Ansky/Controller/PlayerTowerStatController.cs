using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerTowerStatController : MonoBehaviour
{
    private TopDownTowerController _controller;
    private Vector2 _aimDirection = Vector2.right;

    [SerializeField] private TextMeshProUGUI SelectedObjName;
    [SerializeField] private GameObject selectedObjUI;


    private void Awake()
    {
        _controller = GetComponent<TopDownTowerController>();
        selectedObjUI.SetActive(false);
    }

    private void Start()
    {
        _controller.OnLookEvent += OnAim;
        _controller.OnClickEvent += Click;
    }

    private void OnAim(Vector2 direction)
    {
        _aimDirection = direction;
    }

    private void NullClick()
    {
        if (selectedObjUI.activeSelf)
        {
            selectedObjUI.SetActive(false);
        }
    }

    private void Click()
    {
        selectedObjUI.SetActive(false);

        RaycastHit2D hit = Physics2D.Raycast(_aimDirection, Vector2.zero, 0f);

        if (hit.collider == null)
        {
            NullClick();
        }
        else if(hit.collider != null)
        {
            selectedObjUI.SetActive(true);
            GameObject clickObj = hit.transform.gameObject;
            SelectedObjName.text = clickObj.name;
        }
    }
}
