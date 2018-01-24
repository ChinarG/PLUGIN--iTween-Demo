using UnityEngine;


/// <summary>
/// 测试脚本——球体运动类
/// </summary>
public class Test_1 : MonoBehaviour
{
	public GameObject SphereGameObject; //球体预设物
	public Transform  CyanTransform;    //中心球体的位置：青色球体位置


	/// <summary>
	/// 更新函数
	/// </summary>
	void Update()
	{
		RaycastHit hitinfo;                                                        //碰撞对象
		Ray        ray        = Camera.main.ScreenPointToRay(Input.mousePosition); //屏幕点转射线 —— 拿到射线对象
		bool       isCollider = Physics.Raycast(ray, out hitinfo);                 //射线是否照射到碰撞对象: hitinfo —— 返回bool值
		if (isCollider && hitinfo.collider.tag == "Ground")                        //如果照射到，并且对象标签是 “Ground”（标签需要自己设定地面为"Ground"）
		{
			CyanTransform.position = hitinfo.point; //移动红色物体的坐标 —— 到被照射的点上
		}
		if (Input.GetMouseButtonDown(0)) //如果点击鼠标左键
		{
			Spawn(); //调用生成方法
		}
	}


	/// <summary>
	///  生成物体
	/// </summary>
	void Spawn()
	{
		GameObject go                         = (GameObject) Instantiate(SphereGameObject); //实例化物体
		go.GetComponent<MySphere>().TargetPos = CyanTransform.position;                     //给物体身上的脚本中的 目标位置TargetPos 赋值：青色球体的位置
	}
}