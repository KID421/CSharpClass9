using UnityEngine;

public class Soldier
{
    private string _name;

    public Soldier(string name)
    {
        _name = name;
    }

    public void Walk()
    {
        Debug.Log(_name + " 行走。");
    }

    public void Attack()
    {
        Debug.Log(_name + " 攻擊。");
    }

    public void Defence()
    {
        Debug.Log(_name + " 防禦。");
    }

    public void AddHp(int getHp)
    {
        Debug.Log(_name + " 增加血量 " + getHp);
    }

    public void AddMp(int getMp)
    {
        Debug.Log(_name + " 增加魔力 " + getMp);
    }
}
