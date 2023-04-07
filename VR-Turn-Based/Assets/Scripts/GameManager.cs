using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject drawObject;
    public GameObject planObject;
    public GameObject duelObject;

    public enum GameState { Draw, Plan, Duel }
    public GameState CurrentState;

    private void Start()
    {
        Instance = this;
        CurrentState = GameState.Draw;
        drawObject.SetActive(true);
        planObject.SetActive(false);
        duelObject.SetActive(false);
    }

    public void ChangeState()
    {
        switch (CurrentState)
        {
            case GameState.Draw:
                CurrentState = GameState.Plan;
                drawObject.SetActive(false);
                planObject.SetActive(true);
                break;
            case GameState.Plan:
                CurrentState = GameState.Duel;
                planObject.SetActive(false);
                duelObject.SetActive(true);
                break;
            case GameState.Duel:
                // Restart the game loop
                CurrentState = GameState.Draw;
                duelObject.SetActive(false);
                drawObject.SetActive(true);
                break;
        }
    }
}