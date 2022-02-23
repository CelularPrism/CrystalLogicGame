using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineItems : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Magazine magazine;
    [SerializeField] private Transform PanelHint;
    private DataLoot dataLoot;
    private int count;
    private int price;
    private bool isProductMag;

    private Vector3 oldPos;
    private MagazineItemsOrder magazineItemsOrder = null;

    private void Start()
    {
        oldPos = Vector3.zero;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        RectTransform transform = this.transform.GetComponent<RectTransform>();
        Vector3 center = cam.WorldToScreenPoint(transform.position);
        Vector3 size;

        if (transform.position.z == 0)
            size = transform.sizeDelta;
        else
            size = transform.sizeDelta * 2;

        if ((Vector3.Distance(center, Input.mousePosition) < size.x) && (Input.GetMouseButton(0)))
        {
            Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(pos.x, pos.y, 1);

            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 1;
            transform.GetChild(2).gameObject.SetActive(false);

            float distance = Vector3.Distance(this.transform.position, PanelHint.position);
            //distance = distance % 50;
            //Debug.Log(distance);

            if (distance < 85f)
            {
                float minDistance = 10000f;
                foreach (Transform item in PanelHint.GetChild(1))
                {
                    Vector3 itemPos = cam.WorldToScreenPoint(item.position);
                    pos = cam.WorldToScreenPoint(this.transform.position);

                    if (Vector3.Distance(pos, itemPos) < minDistance)
                    {
                        if (item.GetComponent<MagazineItemsOrder>() != magazineItemsOrder && magazineItemsOrder != null)
                            magazineItemsOrder.LightOff();

                        magazineItemsOrder = item.GetComponent<MagazineItemsOrder>();
                        magazineItemsOrder.LightOn();
                        minDistance = Vector3.Distance(pos, itemPos);
                    }
                }
            } else
            {
                if (magazineItemsOrder != null)
                    magazineItemsOrder.LightOff();
                magazineItemsOrder = null;
            }
        }
        else if (magazineItemsOrder != null)
        {
            magazineItemsOrder.LightOff();
            magazineItemsOrder.Insert(dataLoot, count, price, isProductMag);
            magazineItemsOrder = null;
        }
        else
        {
            this.transform.localPosition = oldPos;
            if (dataLoot != null)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 0;
                transform.GetChild(2).gameObject.SetActive(true);
            }
        }
    }

    public void SetData(DataLoot dataLoot, int count, int price, bool isProductMag)
    {
        this.isProductMag = isProductMag;
        this.dataLoot = dataLoot;
        this.price = price;
        this.count = count;
        magazineItemsOrder = null;
    }

    public void DeleteDataLoot()
    {
        dataLoot = null;
    }

    public int GetCount()
    {
        return count;
    }

    public int GetPrice()
    {
        return price;
    }

    public DataLoot GetData()
    {
        return dataLoot;
    }
}
