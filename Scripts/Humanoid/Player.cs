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
    private const string PLAYER_SHOOT = "Shoot";
    private Animator animator;


    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        gameInput.OnClick += GameInputOnClick;
    }

    private void Update()
    {
        HandleRotation();

    }
    private void HandleRotation()
    {
        Ray ray = cam.ScreenPointToRay(gameInput.GetMousePosition());
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 point = hit.point;
            point.y = transform.position.y;
            transform.LookAt(point);
        }
    }

    private void GameInputOnClick(object sender, EventArgs e)
    {
        animator.SetTrigger(PLAYER_SHOOT);

    }
    public void Fire()
    {
        Bow.Instance.Fire();

    }


}
