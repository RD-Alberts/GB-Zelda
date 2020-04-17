using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HearthManager : MonoBehaviour
{
    public Image[] Hearts;
    public Sprite FullHeart;
    public Sprite HalfFullHeart;
    public Sprite EmptyHeart;
    public FloatValue HeartContainers;

    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }
    

    public void InitHearts()
    {
        for(int i = 0; i < HeartContainers.InitialValue; i++)
        {
            Hearts[i].gameObject.SetActive(true);
            Hearts[i].sprite = FullHeart;
        }
    }
}
