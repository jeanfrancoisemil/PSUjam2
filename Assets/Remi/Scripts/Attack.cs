using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour, Player.IArmeVerticaleActions, Player.IArmeHorizontaleActions, Player.IArmeZoneActions, Player.ISwitchArmeActions
{
	public float dmgValue = 4;
	public List<ThrowableWeapon> weapons;
	public Transform attackCheck;
	[HideInInspector]public bool canAttack = true;


	private float armeDirr;
	private Vector2 armeZoneDirr;
	private bool switchArme;
	private ThrowableWeapon currentWeapon;
	private WaitForSeconds _waitForSecondsSwitch;
	private WaitForSeconds _waitForSecondsAttack;
	[HideInInspector]public bool canSwitch;
	
	private Player player;
	
	public GameObject cam;

	public UnityEvent attackEvent;

	// Start is called before the first frame update
	void Start()
    {
	    if (PlayerInputs.Player != null)
	    {
		    player = PlayerInputs.Player;   
	    }
	    else
	    {
		    player = new Player();
	    }
	    _waitForSecondsSwitch = new WaitForSeconds(0.25f);
	    _waitForSecondsAttack = new WaitForSeconds(0.25f);
	    player.ArmeVerticale.SetCallbacks(this);
	    player.ArmeHorizontale.SetCallbacks(this);
	    player.ArmeZone.SetCallbacks(this);
	    player.SwitchArme.SetCallbacks(this);
	    player.SwitchArme.Enable();

	    currentWeapon = weapons[0];
	    player.ArmeHorizontale.Enable();

	    canSwitch = true;

    }

    // Update is called once per frame
    void Update()
    {
	    
	    if (switchArme)
	    {
		    if (canSwitch)
		    {
			    var index = weapons.IndexOf(currentWeapon);
			    var newIndex = index == weapons.Count - 1 ? 0 : index + 1;
			    SwitchWeapon(newIndex);	
		    }
		    switchArme = false;
	    }


	    if (armeDirr != 0 && canAttack)
	    {
		    var transform1 = transform;
		    var throwableWeapon = Instantiate(currentWeapon, transform1.position + new Vector3(transform1.localScale.x * 0.5f,0f), Quaternion.identity); 
		    throwableWeapon.positiveDirection = armeDirr>0f; 
		    throwableWeapon.name = "ThrowableWeapon";
		    StartCoroutine(AttackCooldown()); 
	    }
	}

	IEnumerator AttackCooldown()
	{
		attackEvent.Invoke();
		canAttack = false;
		yield return _waitForSecondsAttack;
		canAttack = true;
	}
	IEnumerator SwitchCooldownn()
	{
		canSwitch = false;
		yield return _waitForSecondsSwitch;
		canSwitch = true;
	}


	public void DoDashDamage()
	{
		dmgValue = Mathf.Abs(dmgValue);
		Collider2D[] collidersEnemies = Physics2D.OverlapCircleAll(attackCheck.position, 0.9f);
		for (int i = 0; i < collidersEnemies.Length; i++)
		{
			if (collidersEnemies[i].gameObject.tag == "Enemy")
			{
				if (collidersEnemies[i].transform.position.x - transform.position.x < 0)
				{
					dmgValue = -dmgValue;
				}
				collidersEnemies[i].gameObject.SendMessage("ApplyDamage", dmgValue);
				cam.GetComponent<CameraFollow>().ShakeCamera();
			}
		}
	}

	void SwitchWeapon(int index)
	{
		
		
		currentWeapon = weapons[index];
		
		if (currentWeapon.arme == ThrowableWeapon.TypeArme.Horizontale)
		{
			player.ArmeVerticale.Disable();
			player.ArmeZone.Disable();
			player.ArmeHorizontale.Enable();
		}
		else if (currentWeapon.arme == ThrowableWeapon.TypeArme.Verticale)
		{
			player.ArmeVerticale.Enable();
			player.ArmeZone.Disable();
			player.ArmeHorizontale.Disable();
		}
		else if (currentWeapon.arme == ThrowableWeapon.TypeArme.Zone)
		{
			player.ArmeVerticale.Disable();
			player.ArmeZone.Enable();
			player.ArmeHorizontale.Disable();
		}


	}

	public void OnShootUp(InputAction.CallbackContext context)
	{
		armeDirr = context.ReadValue<float>();
	}

	public void OnShootRight(InputAction.CallbackContext context)
	{
		armeDirr = context.ReadValue<float>();
	}

	public void OnShootDir(InputAction.CallbackContext context)
	{
		armeZoneDirr = context.ReadValue<Vector2>();
	}

	public void OnSwitch(InputAction.CallbackContext context)
	{
		if (context.started)
		{
			switchArme = true;
		}
	}

}
