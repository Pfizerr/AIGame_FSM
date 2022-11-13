using Microsoft.Xna.Framework.Input;

namespace AIGame
{
    public static class KeyMouseReader
    {
        public static KeyboardState keyState, oldKeyState = Keyboard.GetState();
        public static MouseState mouseState, oldMouseState = Mouse.GetState();

        public static bool KeyPressed(Keys key)
        {
            return keyState.IsKeyDown(key) && oldKeyState.IsKeyUp(key);
        }
        public static bool KeyHold(Keys key)
        {
            return keyState.IsKeyDown(key);
        }
        public static bool LeftClick()
        {
            return mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released;
        }

        public static bool LeftHold()
        {
            return mouseState.LeftButton == ButtonState.Pressed;
        }

        public static bool RightClick()
        {
            return mouseState.RightButton == ButtonState.Pressed && oldMouseState.RightButton == ButtonState.Released;
        }


        //Should be called at beginning of Update in Game
        public static void Update()
        {
            oldKeyState = keyState;
            keyState = Keyboard.GetState();
            oldMouseState = mouseState;
            mouseState = Mouse.GetState();
        }
    }
}