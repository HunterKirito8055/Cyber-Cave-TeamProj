using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OrbHover : MonoBehaviour
{
    Sequence h;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(Random.Range(0.02f,1.5f));
        h = DOTween.Sequence();
        h.Append(this.transform.DOMoveY(0.10f, 0.5f).SetRelative().SetEase(Ease.InOutQuad));
        h.SetLoops(-1,LoopType.Yoyo);
    }
}
