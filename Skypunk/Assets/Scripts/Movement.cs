using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 oldPos;
    Vector3 oldPosCam;
    Collider collider;
    SpriteRenderer oldCollider;

    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private SceneController scene;
    [SerializeField] private AudioSource clipAudio;

    public float radius = 0.1f;
    public float speed = 0.5f;

    float touchPosX = 0;
    float touchPosY = 0;

    void Start()
    {
        oldPos = transform.position;
        oldPosCam = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = cam.WorldToScreenPoint(transform.position);
        Vector3 lossyScale = transform.lossyScale * 3.5f;
        Vector2 nowPos = Input.mousePosition;

        if (Input.GetKey(KeyCode.Mouse0) &&
            (nowPos.x < scale.x + lossyScale.x && nowPos.x > scale.x - lossyScale.x) &&
            (nowPos.y < scale.y + lossyScale.y && nowPos.y > scale.y - lossyScale.y) && scene.moveable)
        {

            nowPos = cam.ScreenToWorldPoint(nowPos);
            float nowPosX = nowPos.x;
            float nowPosY = nowPos.y;

            transform.position = new Vector3(nowPosX, nowPosY);
            collider = GetCollider();
            if (collider != null && Mathf.Abs(transform.position.x - oldPos.x) < 300f)
            {
                int countChild = collider.gameObject.transform.childCount;

                collider.transform.GetChild(countChild - 1).gameObject.GetComponent<SpriteRenderer>().enabled = true;
                oldCollider = collider.transform.GetChild(countChild - 1).gameObject.GetComponent<SpriteRenderer>();

                collider = null;
            } else if (oldCollider != null)
            {
                oldCollider.enabled = false;
                oldCollider = null;
            }

        } else if (Physics.CheckSphere(transform.position, radius, layerMask) && Input.GetMouseButtonUp(0) && Mathf.Abs(transform.position.x - oldPos.x) < 300f && Mathf.Abs(transform.position.x - oldPos.x) > 0f) 
        {
            collider = GetCollider();

            oldPosCam.y = oldPosCam.y + collider.transform.position.y - oldPos.y;
            oldPos = collider.transform.position;

            //clipAudio.clip = collider.gameObject.GetComponent<AudioSource>().clip;
            //clipAudio.Play();

            scene.UseCard(collider.gameObject);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, oldPos, speed);
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, oldPosCam, speed);
        }
    }

    private Collider GetCollider()
    {
        Collider[] colliderList = Physics.OverlapBox(transform.position, new Vector2(500f, 2f), Quaternion.Euler(0, 0, 0), layerMask);
        float minDist = 100f;

        Collider coll = new Collider();

        foreach (Collider i in colliderList)
        {
            float dist = Vector3.Distance(transform.position, i.transform.position);
            int count = i.gameObject.transform.childCount;
            i.transform.GetChild(count - 1).gameObject.GetComponent<SpriteRenderer>().enabled = false;

            if (dist < minDist)
            {
                coll = i;
                minDist = dist;
            }
        }

        return coll;
    }
}
