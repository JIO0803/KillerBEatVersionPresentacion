using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class pointManager : MonoBehaviour
{
    public int moneyToAdd = 10;
    private int intmoney;
    public int realMoney;
    [SerializeField] private int currentMoney;
    private void Update()
    {
        realMoney = intmoney;
    }
    public void AddPoints()
    {
        int currentMoney = PlayerPrefs.GetInt("Money", 0);
        currentMoney += moneyToAdd;
        PlayerPrefs.SetInt("Money", currentMoney);
        intmoney = currentMoney;
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
    }

    // Método para restar dinero
    public void SubtractMoney(int amount)
    {
        currentMoney -= amount;
    }

    // Método para obtener el dinero actual
    public int GetCurrentMoney()
    {
        return currentMoney;
    }
}
