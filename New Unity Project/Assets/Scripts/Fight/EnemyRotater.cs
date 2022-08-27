using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyRotater : MonoBehaviour
{
    [SerializeField] private Sprite[] array;
    [SerializeField] private Quaternion normalRotation;
    [SerializeField] private Quaternion fixedRotation;

    private SpriteRenderer _object;

    private void Start()
    {
        _object = transform.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        bool find = false;

        foreach (Sprite sprite in array)
        {
            if (_object.sprite == sprite)
            {
                transform.rotation = fixedRotation;
                find = true;
                break;
            }
        }

        if (!find)
            transform.rotation = normalRotation;
    }
}
