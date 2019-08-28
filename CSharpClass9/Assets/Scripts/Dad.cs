using System;
using UnityEngine;

public class Dad : MonoBehaviour
{
    public Boy boy;

    private void Start()
    {
        // 訂閱事件並給予回應
        boy.onNoMoney += hitBoy;
    }

    private void hitBoy()
    {
        Invoke("DelayHitBoy", 1);
    }

    private void DelayHitBoy()
    {
        Debug.Log("爸爸扁你一頓!!!");
    }
}
