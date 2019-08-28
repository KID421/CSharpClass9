using System;
using UnityEngine;

public class ChickenManager : MonoBehaviour
{
    // 射線
    public Ray ray;
    // 碰撞物件
    public RaycastHit hit;

    // 定義委派
    private delegate void ChickenAction();
    // 宣告委派
    private ChickenAction chickenAction;

    private void Update()
    {
        // 滑鼠位置
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        // 射線 = 攝影機 主要 螢幕座標轉為射線(滑鼠位置)
        ray = Camera.main.ScreenPointToRay(mousePos);

        // 如果 物理 射線碰撞(射線，碰撞物件，距離) 打到物件
        if (Physics.Raycast(ray, out hit, 100))
        {
            //Debug.Log("打到物件：" + hit.collider.name);

            // 如果 按下左鍵 並且 根物件 root 不為空值
            if (Input.GetKeyDown(KeyCode.Mouse0) && hit.transform.root.GetComponent<Chicken>() != null)
            {
                switch (hit.collider.name)
                {
                    case "等待":
                        chickenAction += hit.transform.root.GetComponent<Chicken>().Idle;
                        break;
                    case "跑步":
                        chickenAction += hit.transform.root.GetComponent<Chicken>().Run;
                        break;
                    case "吃飯":
                        chickenAction += hit.transform.root.GetComponent<Chicken>().Eat;
                        break;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && chickenAction != null)
        {
            Debug.Log("委派：" + chickenAction);
            chickenAction();
            chickenAction = null;
        }
    }

    public Chicken[] chickens;

    private void Start()
    {
        chickens[0].onMoveOver += moveToZero1;
        chickens[1].onMoveOver += moveToZero2;
        chickens[2].onMoveOver += moveToZero3;
    }

    private void moveToZero1()
    {
        Vector3 pos = chickens[0].transform.position;
        pos.z = 0;
        chickens[0].transform.position = pos;
        Debug.Log("第一隻雞回到原點!");
    }
    private void moveToZero2()
    {
        Vector3 pos = chickens[1].transform.position;
        pos.z = 0;
        chickens[1].transform.position = pos;
        Debug.Log("第二隻雞回到原點!");
    }
    private void moveToZero3()
    {
        Vector3 pos = chickens[2].transform.position;
        pos.z = 0;
        chickens[2].transform.position = pos;
        Debug.Log("第三隻雞回到原點!");
    }
}
