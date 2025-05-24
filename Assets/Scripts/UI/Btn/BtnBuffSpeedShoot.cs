using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BtnBuffSpeedShoot : CCHTMonoBehaviour
{
	[SerializeField] protected SpaceshipCtrl spaceshipCtrl;
	public SpaceshipCtrl SpaceshipCtrl => spaceshipCtrl;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadSpaceshipCtrl();
	}

	protected void LoadSpaceshipCtrl()
	{
		if (this.spaceshipCtrl != null) return;
		this.spaceshipCtrl = GameObject.FindObjectOfType<SpaceshipCtrl>();
		Debug.LogWarning(transform.name + ": LoadSpaceshipCtrl", gameObject);
	}

	public void OnButtonClick()
	{
		Debug.Log("buff tốc độ bắn");
		this.spaceshipCtrl.BulletShipCtrl.setTimeandConfirmShoot(2,true);
	}
}
