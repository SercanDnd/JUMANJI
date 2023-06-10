using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BookAnimtion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(Vector3.up * 360, 5,RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(100, LoopType.Incremental);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<FallingFireMacig>().numberOfMacig += 1;
            Destroy(this.gameObject);
        }
    }
}
