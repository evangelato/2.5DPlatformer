using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinText;
    // Start is called before the first frame update
    void Start()
    {
        _coinText.text = "Coin: " + 0;
    }

    // Update coin display
    public void UpdateCoin(int coinNum)
    {
        _coinText.text = "Coin: " + coinNum.ToString();
    }
}
