using UnityEngine;

public class Chicken : MonoBehaviour
{
    // 動畫控制器
    private Animator ani;

    // 定義委派
    public delegate void ChickenMethod();
    // 定義事件
    public event ChickenMethod onMoveOver;

    private void Update()
    {
        if (transform.position.z >= 2)
        {
            // 引發
            onMoveOver();
        }
    }

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void Idle()
    {
        Debug.Log(gameObject.name + " 等待...");
    }

    public void Run()
    {
        transform.position += transform.forward;
        ani.SetTrigger("跑");
        Debug.Log(gameObject.name + " 跑步...");
    }

    public void Eat()
    {
        ani.SetTrigger("吃");
        Debug.Log(gameObject.name + " 吃...");
    }
}
