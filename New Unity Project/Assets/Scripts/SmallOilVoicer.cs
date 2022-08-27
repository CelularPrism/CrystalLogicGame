using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SceneController))]
public class SmallOilVoicer : MonoBehaviour
{
    [SerializeField] private Transform transformChilds;

    [Header("Oil")]
    [SerializeField] private int limitOil;

    [Header("Audio")]
    [SerializeField] private MusicManager musicManager;
    [SerializeField] private AudioClip audioClip;

    [Header("Animation")]
    [SerializeField] private Animator anim;

    private int _nowChild = 0;
    private SceneController _sceneController;

    private void Start()
    {
        _sceneController = GetComponent<SceneController>();
        _nowChild = transformChilds.childCount;
    }

    void Update()
    {
        if (_nowChild != transformChilds.childCount)
        {
            _nowChild = transformChilds.childCount;
            if (_sceneController.fuel <= limitOil)
            {
                musicManager.PlaySoundOnClick(audioClip);
                anim.Play("Base Layer.AnimationFuel", -1);
            }
        }
    }
}
