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
}
