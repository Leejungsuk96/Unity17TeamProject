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
    [SerializeField] private TextMeshProUGUI DamageTxt;
    [SerializeField] private GameObject selectedObjUI;

    private TowerStatHandler towerStat;
    private GameObject clickObj;
    private Rigidbody2D _rigidbody;


    private void Awake()
    {
        _controller = GetComponent<TopDownTowerController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        selectedObjUI.SetActive(false);
    }

    private void Start()
    {
        _controller.OnLookEvent += OnAim;
        _controller.OnClickEvent += Click;
        _controller.OnMoveEvent += Move;
    }

    private void Move()
    {
        if(clickObj == null)
        {
            Debug.Log("moveerror");
            return;
        }

        Debug.Log("move");

        if (selectedObjUI.activeSelf)
        {
            clickObj.transform.position = Vector2.MoveTowards(clickObj.transform.position, _aimDirection, towerStat.CurrentStats.speed * Time.deltaTime);
        }
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

        if (selectedObjUI.activeSelf)
        {
            selectedObjUI.SetActive(false);
        }

        RaycastHit2D hit = Physics2D.Raycast(_aimDirection, Vector2.zero, 0f);

        if (hit.collider == null)
        {
            NullClick();
        }
        else if(hit.collider != null)
        {
            selectedObjUI.SetActive(true);
            clickObj = hit.transform.gameObject;
            SelectedObjName.text = clickObj.name;

            towerStat = clickObj.GetComponent<TowerStatHandler>();
            DamageTxt.text = towerStat.CurrentStats.attackSO.power.ToString();
        }
    }
}
