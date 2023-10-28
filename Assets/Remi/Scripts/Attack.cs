using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour, Player.IArmeVerticaleActions, Player.IArmeHorizontaleActions, Player.IArmeZoneActions, Player.ISwitchArmeActions
{
	public float dmgValue = 4;
	public GameObject bullet;
	public Transform attackCheck;
	private Rigidbody2D m_Rigidbody2D;
	public Animator animator;
	public bool canAttack = true;
	public bool isTimeToCheck = false;
	String currentWeapon;

	private float armeVerticalDirr;
	private float armeHorizontalDirr;
	private Vector2 armeZoneDirr;
	private bool switchArme;

	public bool canSwitch;
	
	private Player player;
	
	public GameObject cam;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Start is called before the first frame update
	void Start()
    {
	    if (player == null)
	    {
		    player = new Player();
	    }
	    
	    player.ArmeVerticale.SetCallbacks(this);
	    player.ArmeHorizontale.SetCallbacks(this);
	    player.ArmeZone.SetCallbacks(this);
	    player.SwitchArme.SetCallbacks(this);
	    player.SwitchArme.Enable();

	    currentWeapon = "WeaponHorizontal";
	    player.ArmeHorizontale.Enable();

	    canSwitch = true;

    }

    // Update is called once per frame
    void Update()
    {
	    
	    Debug.Log("current weapon = " + currentWeapon);
	    
	    if (switchArme)
	    {
		    Debug.Log("tentative de switch");
		    if(!canSwitch) return;
		    
		    Debug.Log("switch sucess");
		    if (currentWeapon == "WeaponHorizontal")
		    {
			    SwitchWeapon("WeaponVertical");
			    StartCoroutine(SwitchCooldownn());
			    return;
		    }
		    if (currentWeapon == "WeaponVertical")
		    {
			    SwitchWeapon("WeaponZone");
			    StartCoroutine(SwitchCooldownn());

			    return;
		    }
		    if (currentWeapon == "WeaponZone")
		    {
			    SwitchWeapon("WeaponHorizontal");
			    StartCoroutine(SwitchCooldownn());

			    return;
		    }
	    }

	    if (player.ArmeVerticale.enabled)
	    {
		    if (armeVerticalDirr != 0f)
		    {
			    if(!canAttack){return;}
				
			    GameObject throwableWeapon = Instantiate(bullet, transform.position + new Vector3(transform.localScale.x * 0.5f,-0.2f), Quaternion.identity) as GameObject; 
			    Vector2 direction = new Vector2(0, armeVerticalDirr);
			    throwableWeapon.GetComponent<ThrowableWeapon>().direction = direction; 
			    throwableWeapon.name = "ThrowableWeapon";

			    StartCoroutine(AttackCooldown());

		    }
	    }

	    if (player.ArmeHorizontale.enabled)
	    {
		    if (armeHorizontalDirr != 0f)
		    {
			    if(!canAttack){return;}
				
			    GameObject throwableWeapon = Instantiate(bullet, transform.position + new Vector3(transform.localScale.x * 0.5f,-0.2f), Quaternion.identity) as GameObject; 
			    Vector2 direction = new Vector2(armeHorizontalDirr, 0);
			    throwableWeapon.GetComponent<ThrowableWeapon>().direction = direction; 
			    throwableWeapon.name = "ThrowableWeapon";
		    
			    StartCoroutine(AttackCooldown());
				
		    }
	    }

	    if (player.ArmeZone.enabled)
	    {
		    if (armeZoneDirr.y != 0 && armeZoneDirr.x != 0)
		    {
			    if(!canAttack){return;}
				
			    Debug.Log("tentative de shoot zone");
			    
			    GameObject throwableWeapon = Instantiate(bullet, transform.position + new Vector3(transform.localScale.x * 0.5f,-0.2f), Quaternion.identity) as GameObject; 
			    Vector2 direction = new Vector2(armeZoneDirr.x, armeZoneDirr.y); 
			    throwableWeapon.GetComponent<ThrowableWeapon>().direction = direction; 
			    throwableWeapon.name = "ThrowableWeapon";
		    
			    StartCoroutine(AttackCooldown());
		    }
	    }
	}

	IEnumerator AttackCooldown()
	{
		canAttack = false;
		yield return new WaitForSeconds(0.25f);
		canAttack = true;
	}
	IEnumerator SwitchCooldownn()
	{
		canSwitch = false;
		yield return new WaitForSeconds(0.25f);
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

	void SwitchWeapon(String weapon)
	{
		Debug.Log("switch !");
		
		bullet = GameObject.Find(weapon).GetComponentInChildren<ThrowableWeapon>().gameObject;
		
		if (weapon == "WeaponHorizontal")
		{
			player.ArmeVerticale.Disable();
			player.ArmeZone.Disable();
			player.ArmeHorizontale.Enable();
		}
		else if (weapon == "WeaponVertical")
		{
			player.ArmeVerticale.Enable();
			player.ArmeZone.Disable();
			player.ArmeHorizontale.Disable();
		}
		else if (weapon == "WeaponZone")
		{
			player.ArmeVerticale.Disable();
			player.ArmeZone.Enable();
			player.ArmeHorizontale.Disable();
		}

		currentWeapon = weapon;

	}

	public void OnShootUp(InputAction.CallbackContext context)
	{
		armeVerticalDirr = context.ReadValue<float>();
	}

	public void OnShootRight(InputAction.CallbackContext context)
	{
		armeHorizontalDirr = context.ReadValue<float>();
	}

	public void OnShootDir(InputAction.CallbackContext context)
	{
		armeZoneDirr = context.ReadValue<Vector2>();
	}

	public void OnSwitch(InputAction.CallbackContext context)
	{
		switchArme = context.performed;
	}
}
