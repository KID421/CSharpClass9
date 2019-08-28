using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Soldier soldierA = new Soldier("士兵 A");
    public Soldier soldierB = new Soldier("士兵 B");

    // 定義委派【簽名】
    // 修飾詞 委派 傳回類型 委派名稱 (參數);
    private delegate void SoldierAction();
    private delegate void SoldierAdd(int a);

    // 宣告委派欄位
    // 修飾詞 委派型別 欄位名稱
    private SoldierAction soldierAction;
    private SoldierAdd soldierAdd;

    private void Start()
    {
        // 委派 指定 方法
        soldierAction = soldierA.Defence;
        soldierAction += soldierB.Walk;
        soldierAction -= soldierA.Defence;
        soldierAction += soldierA.Walk;
        soldierAction += soldierA.Attack;

        soldierAdd = soldierA.AddHp;

        // 匿名函式 Lambda
        soldierAction += () => Debug.Log("所有動作執行結束。");
        soldierAdd += (x) =>
        {
            x = 10;
            Debug.Log(x);
        };

        soldierAction += () =>
        {
            Debug.Log("測試1");
            Debug.Log("測試2");
            Debug.Log("測試3");
        };

        // 執行委派
        soldierAction();
        soldierAdd(999);
    }
}
