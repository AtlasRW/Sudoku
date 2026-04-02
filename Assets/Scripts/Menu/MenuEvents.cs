using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Menu))]
public class MenuEvents : BaseComponent
{
    public static ClickInput<Button> Play;
    public static ChangeInput<SliderInt, int> Slide;
    public static ChangeInput<SliderInt, int> Slide2;

    protected override void OnEnable()
    {
        Play = new("Play");
        Slide = new("Slide");
        Slide2 = new("Slide2");
    }
    protected override void OnDisable() { }
}
