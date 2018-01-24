using UnityEngine;


/// <summary>
/// 测试iTween——哈希表类
/// </summary>
public class TEST1 : MonoBehaviour
{
	public GameObject      TargetGameObject; //目标物体：添加目标物体到inspector面板中
	public float           Time = 2;         //过渡时间
	public iTween.EaseType ITweenType;       //过渡动画曲线类型:可以外部调节


	/// <summary>
	/// 更新函数
	/// </summary>
	void Update()
	{
		if (Input.GetMouseButtonDown(0)) //如果点击鼠标左键
		{
			//iTween.MoveTo(TargetGameObject, new Vector3(3, 3, 3), Time); //移动（目标物体，目标位置，时间）


			//Hashtable args = new Hashtable();                 //实例化一个哈希表对象
			//args.Add("x",                3);                  //添加x坐标：3
			//args.Add("time",             2);                  //时间为：2秒
			//args.Add("delay",            0.1);                //延时：0.1秒
			//args.Add("oncomplete",       "onupdatefunction"); //动画结束时：回调函数
			//args.Add("oncompletetarget", gameObject);         //调用目标物体，脚本的 完成方法 onpupdatefunction
			//args.Add("looptype",         "pingpong");         //过度动画类型：来回动画
			//iTween.MoveTo(TargetGameObject, args);            //移动物体（目标物体，哈希表）


			//和上边方式一模一样，用iTween的Hash()函数，直接添加即可
			iTween.MoveTo(TargetGameObject,iTween.Hash("looptype", "pingpong", "oncompletetarget", gameObject, "oncomplete", "onupdatefunction", "delay", 0.1,"x", 3, "time", 2, "easetype", ITweenType));
		}


		if (Input.GetMouseButtonDown(1)) //如果点击鼠标右键
		{
			TargetGameObject.transform.position = Vector3.zero; //把物体位置归零
		}
	}


	/// <summary>
	/// 打印数字：名字自定义
	/// </summary>
	private void onupdatefunction()
	{
		print("动画完毕");
	}
}