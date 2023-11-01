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
    public event EventHandler OnPlayerShoot;
    private const string PLAYER_SHOOT = "Shoot";


    private void Awake()
    {
        Instance = this;
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
        OnPlayerShoot?.Invoke(this, EventArgs.Empty);

    }
    public void Fire()
    {
        Bow.Instance.Fire();

    }


}
