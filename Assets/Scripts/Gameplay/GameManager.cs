using UnityEngine;

[RequireComponent(typeof(CoinSystem), typeof(CoinUI))]
public class GameManager : MonoBehaviour
{
    private CoinSystem coinSystem;

    void Awake()
    {
        coinSystem = GetComponent<CoinSystem>();
    }

    public void AddCoin(int amount)
    {
        coinSystem.AddCoin(amount);
    }

    public int GetCurrentCoins()
    {
        return coinSystem.CurrentCoins;
    }
}
