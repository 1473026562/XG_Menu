using UnityEngine;
using System.Collections;
using GameSystem;
using GameSystem.Data;
using GameSystem.IEvent;
using GameSystem.NetClient;
using GameSystem.View;
using GameSystem.Control;

/**
 *  MARK:--------------------这是一个示例;使用树形结构的方式来创建一个菜单栏;并指定所有的点击事件;自动运算坐标等--------------------
 */
public class Menu : MonoBehaviour
{
    /////////////////////////////////构造区(包括初始化)/////////////////////////////////////////////////////////////////////////////////////////////////
    public Menu Init()
    {
        this.transform.localPosition = Vector3.zero;
        this.Get_ComponentT<UIPanel>().depth = 200;
        this.name="菜单";
        
        //一级菜单
        ItemUI helpUI = ComponentCreator.Create<ItemUI> (this.transform);
        helpUI.name = "帮助菜单";
        
        ItemData helpData = helpUI.Get_ComponentT<ItemData> ();
        helpData.IsMain = true;
        helpData.Init ("帮助", null);
        
        //子菜单
        helpData.Add("帮助子1",delegate{Debug.LogError ("帮助子1被点击");});
        helpData.Add("帮助子2",delegate{Debug.LogError ("帮助子2被点击");});
        helpData.Add("帮助子3",delegate{Debug.LogError ("帮助子3被点击");});
        ItemData subItem = helpData.Add("帮助子4",delegate{Debug.LogError ("帮助子4被点击");});
        //孙菜单
        subItem.Add("子子1",delegate{Debug.LogError ("1点击");});
        subItem.Add("子子2",delegate{Debug.LogError ("2点击");});
        subItem.Add("子子3",delegate{Debug.LogError ("3点击");});
        subItem.Add("子子4",delegate{Debug.LogError ("4点击");});
        subItem.Add("子子5",delegate{Debug.LogError ("5点击");});
        
        helpUI.Init (helpData);
        helpUI.transform.localPosition = new Vector3 (-400f, 300f, 0f);
        
        
        
        
        ItemUI closeUI = ComponentCreator.Create<ItemUI> (this.transform);
        closeUI.name="关闭菜单";
        
        ItemData closeData = closeUI.Get_ComponentT<ItemData> ();
        closeData.IsMain = true;
        
        closeData.Init("关闭",delegate{Application.Quit();});
        closeUI.Init (closeData);
        closeUI.transform.localPosition = new Vector3 (-200f, 300f, 0f);
        
        return this;
    }
    
    /////////////////////////////////成员区(包括属性)///////////////////////////////////////////////////////////////////////////////////////////////// 
}
