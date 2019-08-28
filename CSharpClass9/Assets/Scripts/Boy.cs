using UnityEngine;

public class Boy : MonoBehaviour
{
    public int money = 100;

    // 定義委派【簽名】
    public delegate void boyAction();
    // 定義事件
    // 修飾詞 事件 委派型別 事件名稱
    public event boyAction onNoMoney;

    private void Update()
    {
        money -= 1;

        if (money == 0)
        {
            Debug.Log("我把錢花光光囉~");

            // 引發事件
            onNoMoney();
        }
    }
}
