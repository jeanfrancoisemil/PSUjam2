using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
[DefaultExecutionOrder(-1)]
public class WeaponChoice : MonoBehaviour, Player.IWavePauseActions
{
    private Image[] _choices;
    private int _currentChoice;
    public static WeaponChoice Instance;
    private Player _player;
    public Image weaponIcon1;
    public Image weaponIcon2;
    public void Start()
    {
        _choices = GetComponentsInChildren<Image>(true);
        if (PlayerInputs.Instance != null)
        {
            _player = PlayerInputs.Player;
        }
        else
        {
            _player = new Player();
            _player.Enable();
        }
        _player.WavePause.SetCallbacks(this);
        _player.WavePause.Disable();
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private bool _pause;
    public void SetPause()
    {
        _pause = true;
        _player.WavePause.Enable();
    }
    public void UnsetPause()
    {
        _pause = false;
        _player.WavePause.Disable();
    }
    public void Update()
    {
        if (!_pause) return;
        if (_leftButton)
        {
            _leftButton = false;
            _currentChoice = _currentChoice > 0 ? _currentChoice-1 : _choices.Length - 1;
            SwitchButton(_currentChoice);
        }
        if (_rightButton)
        {
            _rightButton = false;
            _currentChoice = _currentChoice < _choices.Length - 1 ? _currentChoice+1 : 0;
            SwitchButton(_currentChoice);
        }
    }

    private void SwitchButton(int currentChoice)
    {
        for (int i = 0; i < _choices.Length; i++)
        {
            if (i == currentChoice)
            {
                _choices[i].gameObject.SetActive(true);
            }
            else
            {
                _choices[i].gameObject.SetActive(false);
            }
        }
    }
    private bool _leftButton;
    public void OnLeftButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _leftButton = true;
        }
    }
    private bool _rightButton;
    public void OnRightButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _rightButton = true;
        }
    }
    public void SetSprites(Attack.WeaponSprite spriteOne,Attack.WeaponSprite spriteTwo)
    {
        weaponIcon1.sprite = spriteOne.Sprite;
        weaponIcon2.sprite = spriteTwo.Sprite;
    }
    public void OnEnter(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            UnsetPause();
            GameManager.Instance.SetWeapon(_currentChoice);
        }
    }
}
