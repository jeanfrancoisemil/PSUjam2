using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
[RequireComponent(typeof(Camera))]
public class CameraZoom : MonoBehaviour, Player.ICameraActions
{
    public float speed=3f;
    public float speedFollowPlayer;
    public float fullView = 15f;
    public float closeView = 5f;

    private bool _zoomWasPressed;
    private Camera _camera;
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerInputs.Player != null)
        {
            _player = PlayerInputs.Player;   
        }
        else
        {
            _player = new Player();
        }
        _player.Enable();
        _player.Camera.Enable();
        _player.Camera.SetCallbacks(this);
        _camera = GetComponent<Camera>();
    }
    private bool isZoomed = false;
    private bool isZooming;
    private bool isDezooming;
    // Update is called once per frame
    void Update()
    {
        var position = PlayerSingleton.Instance.transform.position;
        if (isZoomed && !isZooming)
        {
            transform.position = new Vector3(position.x, position.y, -1f);
        }
        if (_zoomWasPressed)
        {
            isZoomed = !isZoomed;
            _zoomWasPressed = false;
            isZooming = true;
        }
        if (isZooming)
        {
            transform.position = Vector3.MoveTowards(transform.position, isZoomed?new Vector3(position.x, position.y, -1f):new Vector3(0f,0f,-1f), speedFollowPlayer*Time.deltaTime);
            _camera.orthographicSize = Mathf.MoveTowards(_camera.orthographicSize, isZoomed ? closeView : fullView, speed * Time.deltaTime);
            if (isZoomed && _camera.orthographicSize <= closeView || !isZoomed && _camera.orthographicSize>=fullView)
            {
                isZooming = false;
            }
        }
    }

    public void OnScroll(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _zoomWasPressed = true;
        }
    }
}
