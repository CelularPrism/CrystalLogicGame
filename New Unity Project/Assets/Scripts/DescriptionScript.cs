using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionScript : MonoBehaviour
{
    public DataLoot dataLoot;
    [SerializeField] private Transform panelDescription;
    private Camera cam;

    private Vector2 scale;
    private Vector2 sizeTextField;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        scale = transform.GetComponent<RectTransform>().sizeDelta;
        sizeTextField = panelDescription.GetChild(1).GetComponent<RectTransform>().sizeDelta;
    }

    private void Update()
    {
        if (dataLoot != null)
        {
            if (panelDescription.gameObject.activeSelf && Input.GetButton("Fire1"))
                panelDescription.gameObject.SetActive(false);

            if (CheckInput() && Input.GetButtonDown("Fire2"))
            {
                Vector3 sizePanel = panelDescription.GetComponent<RectTransform>().sizeDelta;
                Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
                panelDescription.position = new Vector3(mousePos.x + sizePanel.x / 4.5f, mousePos.y - sizePanel.y / 5, 0f);
                panelDescription.gameObject.SetActive(true);
                sizeTextField = panelDescription.GetChild(1).GetComponent<RectTransform>().sizeDelta;
                UpdateText(dataLoot.Description);
            }

            if (sizeTextField != panelDescription.GetChild(1).GetComponent<RectTransform>().sizeDelta)
            {
                RectTransform rectTransform = panelDescription.GetComponent<RectTransform>();
                sizeTextField = panelDescription.GetChild(1).GetComponent<RectTransform>().sizeDelta;
                rectTransform.sizeDelta = new Vector3(rectTransform.sizeDelta.x, sizeTextField.y + 26f);
            }
        }
    }

    private void UpdateText(string text)
    {
        Transform textField = panelDescription.GetChild(1);
        textField.GetComponent<Text>().text = text;
    }

    private bool CheckInput()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 trans = transform.position;
        if (mousePos.x >= trans.x - scale.x / 2 &&
            mousePos.x <= trans.x + scale.x / 2 &&
            mousePos.y >= trans.y - scale.y / 2 &&
            mousePos.y <= trans.y + scale.y / 2)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos gizmos = new Gizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, scale / 2);
    }
}