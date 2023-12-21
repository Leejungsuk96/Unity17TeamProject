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
    [SerializeField] private TextMeshProUGUI DelayTxt;
    [SerializeField] private TextMeshProUGUI RangeTxt;
    [SerializeField] private TextMeshProUGUI BulletTxt;
    [SerializeField] private GameObject selectedObjUI;

    private TowerStatHandler _stats;
    private RangedAttackData _attackData;
    private GameObject clickObj;


    private void Awake()
    {
        _controller = GetComponent<TopDownTowerController>();
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
            return;
        }


        if (selectedObjUI.activeSelf)
        {
            clickObj.transform.position = Vector2.MoveTowards(clickObj.transform.position, _aimDirection, _stats.CurrentStats.speed * Time.deltaTime);
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

        NullClick();

        RaycastHit2D hit = Physics2D.Raycast(_aimDirection, Vector2.zero, 0f);
        if(hit.collider == null)
        {
            NullClick();
        }
        else if(hit.collider != null)
        {
            clickObj = hit.transform.gameObject;
            _stats = clickObj.GetComponent<TowerStatHandler>();
            _attackData = _stats.CurrentStats.attackSO as RangedAttackData;

            if(clickObj.tag == "Player")
            {
                selectedObjUI.SetActive(true);
                SelectedObjName.text = clickObj.name;
                DamageTxt.text = _stats.CurrentStats.attackSO.power.ToString();
                DelayTxt.text = _stats.CurrentStats.attackSO.delay.ToString();
                RangeTxt.text = _attackData.range.ToString();
                BulletTxt.text = _attackData.numberofProjectilesPerShot.ToString();
            }
            else
            {
                NullClick();
            }
        }
    }
}
