using System;
using UnityEngine;

public enum GameState
{
    MainMenu,
    Game,
    GameOver,
    Summary,
    Pause
}

public static class GameManager
{
    public static event Action OnKillAll, OnStartGame, OnEndGame;
    public static event Action<Car> OnKillCar, OnSpawnCar;
    public static event Action<GameState> OnGameStateChange;
    private static GameState currentState = GameState.MainMenu;
    private static int numCars = 0;

    public static void SetGameState(GameState newState)
    {
        if (newState == currentState) return;
        currentState = newState;
        OnGameStateChange?.Invoke(currentState);
    }

    //[ContextMenu("KillAll")]
    public static void KillAllCars()
    {
        OnKillAll?.Invoke();
    }

    public static void EndGame()
    {
        KillAllCars();
        OnEndGame?.Invoke();
        SetGameState(GameState.GameOver);
    }

    public static void StartGame()
    {
        OnStartGame?.Invoke();
        SetGameState(GameState.Game);
    }

    public static void KillCar(Car car)
    {
        OnKillCar?.Invoke(car);
        numCars--;
        if (numCars <= 0)
        {
            EndGame();
        }
    }

    public static void SpawnCar(Car car)
    {
        Debug.Log("Spawning Car " + car.name);
        OnSpawnCar?.Invoke(car);
        numCars++;
    }
}