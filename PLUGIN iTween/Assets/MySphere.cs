using UnityEngine;


/// <summary>
/// 球体自身挂载的脚本
/// </summary>
public class MySphere : MonoBehaviour
{
	public  Vector3         TargetPos;     //目标位置
	private GameObject      Sphere;        //子物体 圆球的位置
	public  iTween.EaseType ShangEaseType; //上过度动画的类型
	public  iTween.EaseType XiaEaseType;   //下过度动画的类型


	/// <summary>
	/// 初始化方法
	/// </summary>
	void Start()
	{
		Sphere = transform.Find("Sphere").gameObject;                                                                             //找到球体预设物的子物体：Sphere
		iTween.MoveTo(gameObject, iTween.Hash("time", .7,  "position", TargetPos, "easetype", iTween.EaseType.easeOutCubic));     //移动到青色球所在的位置
		iTween.FadeTo(gameObject, iTween.Hash("time", .5,  "delay",    3,         "alpha",    0, "onComplete", "DestroyTarget")); //修改透明度
		iTween.MoveBy(Sphere, iTween.Hash("time",     .35, "y",        5,         "easetype", ShangEaseType));                    //移动球体预设物子物体Sphere 相对位置 y轴 到5：即向上移动
		iTween.MoveBy(Sphere, iTween.Hash("delay",    .35, "time",     .35,       "y",        -5, "easetype", XiaEaseType));      //向下移动，并调用方法
		//MoveBY是在自身的基础上，做增量移动
		//MoveTo是移动到指定坐标
	}


	/// <summary>
	/// 删除物体
	/// </summary>
	private void DestroyTarget()
	{
		Destroy(gameObject); //删除物体
	}
}