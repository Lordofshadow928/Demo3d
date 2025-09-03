using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunAmmo : MonoBehaviour
{
	public int ammoCount;
	public GrenadeLauncher gun;
	public Animator anim;
	public AudioSource reloadSounds;
	public UnityEvent loadAmmoChanged;

	private int _loadedAmmo;
	public int LoadedAmmo
	{
		get => _loadedAmmo;
		set
		{
			_loadedAmmo = value;
			loadAmmoChanged.Invoke();
			if (_loadedAmmo <= 0)
			{
				LockShooting();
			}
			else
			{
				UnlockShooting();
			}
		}
	}

	private void Start()
	{
		RefillAmmo();
	}

	public void SingleFireAmmoCounter()
	{
		LoadedAmmo--;
	}

	private void LockShooting()
	{
		gun.enabled = false;
	}

	private void UnlockShooting()
	{
		gun.enabled = true;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			Reload();
		}
	}

	private void Reload()
	{
		anim.SetTrigger("Reload");
		LockShooting();
	}
	
	public void AddAmmo()
	{
		RefillAmmo();
	}

	private void RefillAmmo()
	{
		LoadedAmmo = ammoCount;
	}
}
