using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScoreScript : MonoBehaviour
{
    TextMesh scoreText;
    // Use this for initialization
    void Start()
    {
        DOTween.Init(true, true);
        transform.DOMoveY(transform.position.y + 1, 1).OnComplete(() => Destroy(gameObject));
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

    }



    public void showScore(float points)
    {
        scoreText = gameObject.GetComponent<TextMesh>();

        scoreText.text = "+" + points + "";
    }
    // Update is called once per frame
    void Update()
    {

    }
}
