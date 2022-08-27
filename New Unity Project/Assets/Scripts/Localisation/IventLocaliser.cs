using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IventManager))]
public class IventLocaliser : MonoBehaviour
{
    [SerializeField] private TextLocaliserUI header;
    [SerializeField] private TextLocaliserUI text;
    [SerializeField] private TextLocaliserUI varA;
    [SerializeField] private TextLocaliserUI varB;

    private IventManager _iventManager;
    private DataIvent _nowDataIvent;

    void Start()
    {
        _iventManager = GetComponent<IventManager>();
        _nowDataIvent = _iventManager.GetIvent();
    }

    // Update is called once per frame
    void Update()
    {
        /*Debug.Log(_nowDataIvent);
        if (_nowDataIvent != _iventManager.GetIvent())
        {
            _nowDataIvent = _iventManager.GetIvent();
            Debug.Log(_nowDataIvent);

            DataLocalisationIvent data = _nowDataIvent.localisationIvent;
            if (data.iventHeader != "")
                header.key = data.iventHeader;

            text.key = data.text;
            varA.key = data.varA;
            varB.key = data.varB;
        }*/
    }
}
