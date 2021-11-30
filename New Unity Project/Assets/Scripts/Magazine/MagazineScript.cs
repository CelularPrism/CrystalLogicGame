using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagazineScript : MonoBehaviour
{
    [SerializeField] private Text textSlider;
    [SerializeField] private Text rightCount;

    [SerializeField] private Slider slider;

    public Item Item;
    public Transform transItem;

    // Update is called once per frame
    void Update()
    {
        slider.minValue = 1;
        slider.maxValue = Item.countItem;

        rightCount.text = Item.countItem.ToString();
        textSlider.text = slider.value.ToString();
    }
    
    public void OpenPanel()
    {
        transform.gameObject.SetActive(true);
        slider.value = 1;
    }

    public void Confirm()
    {
        transform.parent.GetComponent<MagazineUIManager>().EnabledItem(Item, transItem, (int)slider.value);
        transform.gameObject.SetActive(false);
    }
}
