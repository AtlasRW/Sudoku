using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Menu : BaseManager
{
    protected override void OnEnable()
    {
        AddComponent<MenuEvents>();
        MenuEvents.Play.Click.Subscribe(OnMenuClick);
    }

    protected override void OnDisable()
    {
        RemoveComponent<MenuEvents>();
        MenuEvents.Play.Click.Unsubscribe(OnMenuClick);
    }

    void OnMenuClick(ClickEvent e)
    {
        SceneManager.LoadScene("Game");
    }
}
