using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemManager : MySingleton<ItemManager>
{

    Dictionary<int,List<ItemInfo>> ItemInfos = new Dictionary<int, List<ItemInfo>>();

    public List<ItemInfo> t1 = new List<ItemInfo>();
    public List<ItemInfo> t2 = new List<ItemInfo>();

    public BaseItem[] itemPrefabs;

    private void Awake()
    {
        Init();
    }


    //��� ������ �������� �޾ƿͼ� �����ϰ� �ִ´�.
    public void Init()
    {
        ItemInfo[] infos = Resources.LoadAll<ItemInfo>("ItemInfo");
        //ItemInfos.Add( ScriptableObject.CreateInstance<ItemInfo>());

        for (int i = 0; i < infos.Length; i++)
        {
            if (!ItemInfos.ContainsKey((int)infos[i].itemType))
                ItemInfos.Add((int)infos[i].itemType, new List<ItemInfo>());
                
            ItemInfos[(int)infos[i].itemType].Add(infos[i]);

            if (infos[i].itemType == ItemType.EQUIP)
                t1.Add(infos[i]);
            else
                t2.Add(infos[i]);
        }


        int a = 0;
    }


    //�ش� Ÿ�� �߿��� �������� �������� ���� �������ش�.
    public BaseItem GetItemInfo(ItemType type)
    {
        int rand = Random.Range(0, ItemInfos[(int)type].Count);
        return CreateItem(ItemInfos[(int)type][rand]);
    }


    //�ش� ������ ���� �����۰�ü�� ����� �ش�.
    public BaseItem CreateItem(ItemInfo info)
    {
        BaseItem item = null;

        item = Instantiate<BaseItem>(itemPrefabs[(int)info.itemType]);
        
        item.Init(info, info.itemType);

        return item;
    }


}
