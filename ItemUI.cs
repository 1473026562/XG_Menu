public class ItemUI:MonoBehaviour
{
	public ItemUI Init(ItemData data)
	{
		this.data = data;
		this.sprite = JxgUIPool.CreateSprite(this.transform);
		this.sprite.Set_Atlas_SpriteName(Atlas.MainMenu, "button_fore");
		this.sprite.MakePixelPerfect();
		this.sprite.type = UIBasicSprite.Type.Sliced; 
		this.sprite.transform.localPosition = new Vector3(0f, 0f, 0f);
		this.sprite.depth = 200;
		this.sprite.SetActive (data.isParent);
		
		this.button = ComponentCreator.Create<JxgImageButton>(this.transform);
		this.button.Init(Atlas.MainMenu, "button", "button_onclick");
		this.button.Background.Set_Size(200f, 67f);
		this.button.Background.type = UISprite.Type.Sliced;
		this.button.Label.trueTypeFont = GameSystem.Data.Font.DFYuan;
		this.button.Label.fontSize = 32;
		this.button.Label.SetEffect_Button();
		this.button.Label.text = data.btnText;
		this.button.transform.localPosition = new Vector3(0f, 0f, 0f);
		this.button.depth = 150;
		if (data.isParent)	this.button.ClickedAction = this.SwitchSubItems;
		else this.button.ClickedAction = this.BtnClicked;
		
		return this;
	}
	/////////////////////////////////成员区(包括属性)///////////////////////////////////////////////////////////////////////////////////////////////// 
	private JxgSprite sprite;
	private JxgImageButton button;
	private ItemData data;
	private bool isClicked=false;
	private float currentPosY=0f; 
	/////////////////////////////////方法区////////////////////////////////////////////////////////////////////
	/// <summary>
	/// B封闭点击事件
	/// </summary>
	/// <param name="btn">Button.</param>
	private void BtnClicked(JxgButtonBase btn)
	{
		this.data.btnAction.CheckAndRun ();
	}
	
	/// <summary>
	/// 开放菜单点击事件
	/// </summary>
	/// <param name="btn">Button.</param>
	private void SwitchSubItems(JxgButtonBase btn)
	{
		this.isClicked = !this.isClicked;
		this.SetItemsShow (this.isClicked);
	}
	/// <summary>
	/// 设置显示下级菜单的显示；
	/// </summary>
	/// <param name="show">If set to <c>true</c> show.</param>
	private void SetItemsShow(bool show)
	{
		if(this.data.itemDatas!=null)
		{
			foreach (var data in this.data.itemDatas) 
			{
				var itemUI = ComponentCreator.Create<ItemUI>(this.transform).Init (data);
				itemUI.transform.localPosition=this.AutoLayout();
			}
		}
	}
	/// <summary>
	/// A自动生成计算出子菜单的坐标
	/// </summary>
	/// <returns>The layout.</returns>
	private Vector3 AutoLayout()
	{
		Vector3 pos = this.data.IsMain ? Vector3.zero :  new Vector3 (this.button.Background.width, this.button.Background.height, 0f);
		this.currentPosY-=this.button.Background.height;
		return pos + new Vector3 (0f, currentPosY, 0f);
	}
	/// <summary>
	/// C关闭方法
	/// </summary>
	public void Close()
	{
		if (this.isClicked) 
		{
			Destroy(this);
			Destroy (this.gameObject);
		}
	}
}
