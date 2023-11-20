using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;

public class MKBController
{

    private struct mouseInput
    {
        public const int mouse_eventLeftDown = 0x02;
        public const int mouse_eventLeftUp = 0x04;
        public const int mouse_eventRightDown = 0x08;
        public const int mouse_eventRightUp = 0x10;
        public const int mouse_eventWheel = 0x0800;
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
        mouse_event(mouseInput.mouse_eventLeftDown, 0, 0, 0, 0);
    }

    public void LeftMouseUp()
    {
        mouse_event(mouseInput.mouse_eventLeftUp, 0, 0, 0, 0);
    }

    public void LeftMouseClick()
    {
        LeftMouseDown();
        LeftMouseUp();
    }

    public void RightMouseDown()
    {
        mouse_event(mouseInput.mouse_eventRightDown, 0, 0, 0, 0);
    }

    public void RightMouseUp()
    {
        mouse_event(mouseInput.mouse_eventRightUp, 0, 0, 0, 0);
    }

    public void RightMouseClick()
    {
        RightMouseDown();
        RightMouseUp();
    }

    public void ScrollUp(int scrollAmount = 200)
    {
        mouse_event(mouseInput.mouse_eventWheel, 0, 0, scrollAmount, 0);
    }

    public void ScrollDown(int ScrollAmount = -200)
    {
        mouse_event(mouseInput.mouse_eventWheel, 0, 0, ScrollAmount, 0);
    }

    public void KeyType(string key)
    {
        SendKeys.Send(key);
    }

    public void KeyDown(byte key)
    {
        keyboardEvent(key, 0, 0, 0);
    }

    public void KeyUp(byte key)
    {
        keyboardEvent(key, 0, keyboardInput.keyEventUp, 0);
    }

    public void keyPress(byte key)
    {
        KeyDown(key);
        KeyUp(key);
    }


}
