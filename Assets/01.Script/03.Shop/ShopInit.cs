using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInit : MonoBehaviour
{
    [SerializeField] private List<ItemData> WeaponData;
    [SerializeField] private List<ItemData> ArmorData;
    //[SerializeField] private List<ItemData> WeaponData;

    [SerializeField] GameObject btnPrefab;

    [SerializeField] private List<GameObject> currentBtn;

    void Start()
    {
        
    }

    private void ChangeBtnList(List<ItemData> list)
    {
        foreach (GameObject obj in currentBtn)
        {
            Destroy(obj);
        }

        foreach (ItemData item in list)  // TODO
        {
            // 아이템 선택 버튼 생성
            // 해당 버튼 list에 있는 값으로 수정
        }
    }
}
