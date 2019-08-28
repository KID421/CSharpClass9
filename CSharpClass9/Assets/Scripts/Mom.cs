using System;
using UnityEngine;

public class Mom : MonoBehaviour
{
    public Boy boy;

    private void Start()
    {
        // 訂閱事件並給予回應
        boy.onNoMoney += giveMoney;
        boy.onNoMoney += hitBoy;
    }

    private void giveMoney()
    {
        Debug.Log("*** 100 快拿去啦 = =");
        boy.money += 100;
    }

    private void hitBoy()
    {
        Debug.Log("媽媽扁你一頓!!!");
    }
}
