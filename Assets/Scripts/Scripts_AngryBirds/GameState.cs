class GameState
{
    public static ModalScript modalScriptInstance;
    public static bool isLevelCompleted;
    public static void Pause(string title = null, string message = null)
    {
        modalScriptInstance.ShowModal(true, title, message);
    }
}