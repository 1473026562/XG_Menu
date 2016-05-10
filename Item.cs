using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;
using GameSystem.Control;
using GameSystem.Data;
using GameSystem.IEvent;
using GameSystem.NetClient;
using GameSystem.View;

/// <summary>
///--------------------------ItemData
/// </summary>

public enum ItemDirection
{
	Horizontal,
	Vertical
}
public class ItemData : MonoBehaviour 
{
	/////////////////////////////////成员区(包括属性)///////////////////////////////////////////////////////////////////////////////////////////////// 
	public List<ItemData> itemDatas;
	public bool isParent;
	public Action btnAction;
	public string btnText;
	private ItemDirection direction=ItemDirection.Horizontal;
	public bool IsMain
	{
		get
		{
			return this.direction==ItemDirection.Vertical;
		}
		set
		{
		this.direction=value?ItemDirection.Vertical:ItemDirection.Horizontal;
		}
	}
	/////////////////////////////////行为区///////////////////////////////////////////////////////////////////////////////////////////////// 
	
	///子类设置自己
	public void Init(string btnText,Action btnAction)
	{ 
		this.isParent = false;
		this.btnText = btnText;
		this.btnAction = btnAction;
	}
	/// <summary>
	/// A添加子菜单
	/// </summary>
	/// <param name="itemText">Item text.</param>
	/// <param name="itemClick">Item click.</param>
	public ItemData Add(string itemText,Action itemClick=null)
	{
		this.isParent = true;
		ItemData data = new ItemData ();// ComponentCreator.Create<ItemData> (this.transform).Init ();
		data.Init (itemText, itemClick);
		if(this.itemDatas==null) this.itemDatas=new List<ItemData>();
		this.itemDatas.Add (data);
		return data;
	}
}
