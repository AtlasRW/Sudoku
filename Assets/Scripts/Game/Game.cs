using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Game : BaseManager
{
    protected override void OnEnable()
    {
        AddComponent<GameEvents>();
        CreateBoard();

        GameEvents.Solved.Subscribe(OnSolved);
        GameEvents.Back.Subscribe(OnBack);
        GameEvents.Refresh.Subscribe(OnRefresh);
    }

    protected override void OnDisable()
    {
        GameEvents.Solved.Unsubscribe(OnSolved);
        GameEvents.Back.Unsubscribe(OnBack);
        GameEvents.Refresh.Unsubscribe(OnRefresh);

        RemoveComponent<GameEvents>();
        DestroyBoard();
    }

    void OnSolved(Board b)
    {
        Logger.Log($"SOLVED {b}");
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
        AddComponent<Board>();
    }

    void DestroyBoard()
    {
        RemoveComponent<Board>();
    }
}
