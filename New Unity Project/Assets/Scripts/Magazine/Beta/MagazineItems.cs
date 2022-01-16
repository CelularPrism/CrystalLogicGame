using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineItems : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Magazine magazine;
    [SerializeField] private GameObject PanelSellItems;
    public DataLoot dataLoot;
    public int count;

    private Vector3 oldPos;
    private MagazineItemsOrder magazineItemsOrder;


    private void Start()
    {
        oldPos = transform.position;
    }

    void Update()
    {
        RectTransform transform = this.transform.GetComponent<RectTransform>();
        Vector3 center = cam.WorldToScreenPoint(transform.position);
        Vector3 size = transform.sizeDelta;

        if ((Vector3.Distance(center, Input.mousePosition) < size.x) && (Input.GetMouseButton(0)))
        {
            Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(pos.x, pos.y, 1);
            PanelSellItems.SetActive(true);
            if (Vector3.Distance(center, PanelSellItems.transform.position) < 5f)
            {
                float minDistance = 10000f;
                foreach (Transform item in PanelSellItems.transform)
                {
                    Debug.Log(item.name);
                    /*if (Vector3.Distance(center, item.position) < minDistance)
                    {
                        magazineItemsOrder = item.GetComponent<MagazineItemsOrder>();
                        minDistance = Vector3.Distance(center, item.position);
                    }*/
                }
            }
        }
        else
        {
            transform.position = oldPos;
            PanelSellItems.SetActive(false);
        }
    }
}
