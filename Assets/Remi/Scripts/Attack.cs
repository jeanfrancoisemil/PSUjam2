using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class Attack : MonoBehaviour, Player.IArmeVerticaleActions, Player.IArmeHorizontaleActions, Player.IArmeZoneActions
{
	public float dmgValue = 4;
	public List<ThrowableWeapon> weapons;
	private List<Sprite> _weaponsSprites;
	public Transform attackCheck;
	[HideInInspector]public bool canAttack = true;

	public static Attack Instance;
	private float armeDirr;
	private Vector2 armeZoneDirr;
	private ThrowableWeapon currentWeapon;
	private WaitForSeconds _waitForSecondsSwitch;
	private WaitForSeconds _waitForSecondsAttack;
	
	private Player player;
	
	

	// Start is called before the first frame update
	void Start()
    {
	    if (Instance == null)
	    {
		    Instance = this;
	    }
	    else
	    {
		    Destroy(this);
	    }
	    
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

	    currentWeapon = weapons[0];
	    player.ArmeHorizontale.Enable();


	    _weaponsSprites = new List<Sprite>();
	    for (int i = 0; i < weapons.Count; i++)
	    {
		    _weaponsSprites.Add(weapons[i].GetComponent<SpriteRenderer>().sprite);
	    }
		SwitchWeapon(0);
    }
	public struct WeaponSprite
	{
		public int Index;
		public Sprite Sprite;
	}
	public WeaponSprite[] FetchWeapons()
	{
		var list = new List<int>()
		{
			0,
			1,
			2
		};
		list.Remove(weapons.IndexOf(currentWeapon));
	
		var results = new WeaponSprite[2];
		for (int i = 0; i < 2; i++)
		{
			results[i] = new WeaponSprite()
			{
				Index = list[i],
				Sprite = _weaponsSprites[list[i]]
			};
		}
		return results;
	}

    // Update is called once per frame
    void Update()
    {
	    


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
		canAttack = false;
		yield return _waitForSecondsAttack;
		canAttack = true;
	}

	

	public void SwitchWeapon(int index)
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



}
