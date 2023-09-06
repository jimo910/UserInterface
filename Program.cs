using System;
using UserInterface.Views;
using UserInterface.TokenAuth;

namespace UserInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Hello World no dey");
            IView mainView = Factory.GetMainViewObject();
            mainView.RunView();

            Console.ReadKey();


  
      


        }
    }
}