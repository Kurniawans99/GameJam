using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [HideInInspector] public Vector3 targetPos;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Camera cam;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        gameInput.OnClick += GameInputOnClick;
    }

    private void GameInputOnClick(object sender, GameInput.OnClickArgs e)
    {
        Ray ray = cam.ScreenPointToRay(e.mousePos);


        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.TryGetComponent(out Enemy enemy))
            {
                targetPos = enemy.transform.position;
                Bow.Instance.Fire();
            }
        }
    }


}
