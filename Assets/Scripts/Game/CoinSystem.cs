using UnityEngine;

[RequireComponent(typeof(CoinUI))]
public class CoinSystem : MonoBehaviour
{
    [SerializeField] private int currentCoins = 0;
    public int CurrentCoins => currentCoins;

    private CoinUI coinUI;

    void Awake()
    {
        coinUI = GetComponent<CoinUI>();
    }

    public void AddCoin(int amount)
    {
        currentCoins += amount;
        coinUI.UpdateCoinDisplay(currentCoins);
    }
}
