class GameState
{
    public static ModalScript modalScriptInstance;
    public static bool isLevelCompleted;
    public static bool isLevelFailed;
    public static void Pause(string title = null, string message = null, string goButton = null)
    {
        modalScriptInstance.ShowModal(true, title, message, goButton);
    }
}