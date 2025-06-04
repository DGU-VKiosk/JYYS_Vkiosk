// System
using System.Collections.Generic;

// Unity
using UnityEngine;

[System.Serializable]
public class MenuInfo
{
    public int id;
    public string name;
    public int price;

    public MenuInfo(int _id, string _name, int _price)
    {
        id = _id;
        name = _name;
        price = _price;
    }
}

[DisallowMultipleComponent]
public class CartManager : MonoBehaviour
{
    private Dictionary<int ,(MenuInfo info, int count)> cartDict = new();

    /// <summary>
    /// 장바구니에 추가하기 위한 메소드
    /// </summary>
    /// <param name="_id"></param>
    /// <param name="_name"></param>
    /// <param name="_price"></param>
    public void AddCart(int _id, string _name, int _price)
    {
        if (cartDict.ContainsKey(_id))
            cartDict[_id] = (cartDict[_id].info, cartDict[_id].count + 1);
        else
            cartDict[_id] = (new MenuInfo(_id, _name, _price), 1);
    }

    /// <summary>
    /// 장바구니에서 제거하기 위한 메소드
    /// </summary>
    /// <param name="_id"></param>
    public void RemoveCart(int _id)
    {
        if (cartDict.ContainsKey(_id))
        {
            var (info, count) = cartDict[_id];
            if (count <= 1)
                cartDict.Remove(_id);
            else
                cartDict[_id] = (info, count - 1);
        }
    }
}
