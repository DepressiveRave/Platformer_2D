using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SawTweener : MonoBehaviour
{
    public Transform[] sawPoints;
    public float sawSpeed;

    void Start()
    {
        Sequence sawSequence = DOTween.Sequence();

        for (int i = 0; i < sawPoints.Length; i++)
        {
            sawSequence.Append(transform.DOMove(sawPoints[i].position, sawSpeed).SetEase(Ease.Linear));
        }
        sawSequence.SetLoops(-1, LoopType.Restart);
    }
}
