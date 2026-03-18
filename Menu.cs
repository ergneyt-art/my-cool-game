using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoolGame
{
    public static class Menu // add commets
    {
        public static void ShowMainMenu()
        {
        }

        public static void StartNewGame()
        {
        }

        public static void LoadGame()
        {
        }

        public static void ShowSettings()
        {
        }
    }

    public interface IGetInfo
    {
        public void ShowInfo(object obj)
        {
        }
    }

    public interface IMoveing 
    {
        public void Move()
        {

        }

        public void Jump()
        {

        }

        public void Turn()
        {

        }

        public void Stop()
        {

        }
    }
}
