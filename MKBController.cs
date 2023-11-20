using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;

//https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.sendkeys.send?view=windowsdesktop-8.0&redirectedfrom=MSDN#System_Windows_Forms_SendKeys_Send_System_String_

public class MKBController
{

    private struct mouseInput
    {
        public const int mouseEventLeftDown = 0x02;
        public const int mouseEventLeftUp = 0x04;
        public const int mouseEventRightDown = 0x08;
        public const int mouseEventRightUp = 0x10;
        public const int mouseEventWheel = 0x0800;
    }

    private struct keyboardInput
    {
        public const int keyEventDown = 0x0001;
        public const int keyEventUp = 0x0002;
    }

    [DllImport("user32.dll")] static extern bool SetCursorPos(int X, int Y);
    [DllImport("user32.dll")] static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
    [DllImport("user32.dll")] static extern void keyboardEvent(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);


    public void moveMouse(int x, int y)
    {
        SetCursorPos(x, y);
    }

    public void LeftMouseDown()
    {
        mouse_event(mouseInput.mouseEventLeftDown, 0, 0, 0, 0);
    }

    public void LeftMouseUp()
    {
        mouse_event(mouseInput.mouseEventLeftUp, 0, 0, 0, 0);
    }

    public void LeftMouseClick()
    {
        LeftMouseDown();
        LeftMouseUp();
    }

    public void RightMouseDown()
    {
        mouse_event(mouseInput.mouseEventRightDown, 0, 0, 0, 0);
    }

    public void RightMouseUp()
    {
        mouse_event(mouseInput.mouseEventRightUp, 0, 0, 0, 0);
    }

    public void RightMouseClick()
    {
        RightMouseDown();
        RightMouseUp();
    }

    public void ScrollUp(int scrollAmount = 200)
    {
        mouse_event(mouseInput.mouseEventWheel, 0, 0, scrollAmount, 0);
    }

    public void ScrollDown(int ScrollAmount = -200)
    {
        mouse_event(mouseInput.mouseEventWheel, 0, 0, ScrollAmount, 0);
    }

    public void KeyType(string key)
    {
        SendKeys.SendWait(key);
    }

}
