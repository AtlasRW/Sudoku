using UnityEngine.UIElements;

public class MenuEvents : BaseComponent
{
    public static BaseInput<Button> Play;

    protected override void OnEnable()
    {
        Play = new("Play");
    }
    protected override void OnDisable() { }
}
