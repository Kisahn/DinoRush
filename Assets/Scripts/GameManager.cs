using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int currentCoins = 0;
    [SerializeField]
    private Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoin(int coinToAdd)
    {
        currentCoins += coinToAdd;
        coinText.text = currentCoins.ToString();
    }

}
