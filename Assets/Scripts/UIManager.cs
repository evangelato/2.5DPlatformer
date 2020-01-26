using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinText;
    [SerializeField]
    private Text _livesText;
    // Start is called before the first frame update
    void Start()
    {
        _coinText.text = "Coin: " + 0;
        _livesText.text = "Lives: " + 3;
    }

    // Update coin display
    public void UpdateCoinDisplay(int coinNum)
    {
        _coinText.text = "Coin: " + coinNum.ToString();
    }

    public void UpdateLivesDisplay(int lives)
    {
        _livesText.text = "Lives: " + lives.ToString();
    }
}
