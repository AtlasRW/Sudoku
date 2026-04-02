using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : BaseManager
{
    public MenuData Data;

    protected override void OnEnable()
    {
        AddComponent<MenuEvents>();
        MenuEvents.Play.Subscribe(OnPlay);
        MenuEvents.Slide.Subscribe(OnSlide);
        MenuEvents.Slide2.Subscribe(OnSlide);
    }

    protected override void OnDisable()
    {
        RemoveComponent<MenuEvents>();
        MenuEvents.Play.Unsubscribe(OnPlay);
        MenuEvents.Slide.Subscribe(OnSlide);
    }

    void OnPlay(ClickEvent e)
    {
        SceneManager.LoadScene("Game");
    }

    void OnSlide(ChangeEvent<int> e)
    {
        Logger.Log(e.newValue);
    }
}
