using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

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
        GameEvents.Solved.Unsubscribe(OnSolved);
        GameEvents.Back.Click.Unsubscribe(OnBack);
        GameEvents.Refresh.Click.Unsubscribe(OnRefresh);

        RemoveComponent<GameEvents>();
        DestroyBoard();
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
