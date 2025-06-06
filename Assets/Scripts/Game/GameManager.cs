using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Game : BaseManager
{
    Board board;

    protected override void OnEnable()
    {
        AddComponent<GameEvents>();
        CreateBoard();

        GameEvents.Solved.Subscribe(OnSolved);
        GameEvents.Back.Click.Subscribe(OnBack);
        GameEvents.Refresh.Click.Subscribe(OnRefresh);
    }

    protected override void OnDisable()
    {
        RemoveComponent<GameEvents>();
        DestroyBoard();

        GameEvents.Solved.Unsubscribe(OnSolved);
        GameEvents.Back.Click.Unsubscribe(OnBack);
        GameEvents.Refresh.Click.Unsubscribe(OnRefresh);
    }

    void OnSolved(Board b)
    {
        Debug.Log($"SOLVED {b}");
    }

    void OnBack(ClickEvent e)
    {
        SceneManager.LoadScene("Menu");
    }

    void OnRefresh(ClickEvent e)
    {
        DestroyBoard();
        CreateBoard();
    }

    void CreateBoard()
    {
        board = Board.Create();
    }

    void DestroyBoard()
    {
        if (board) board.Destroy();
    }
}
