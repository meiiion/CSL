using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    public delegate void ItemHandler();
    public class Item
    {
        public event ItemHandler OnItemSelect;
        private string caption;
        public Item(string caption)
        {
            this.caption = caption;
        }
        public string Caption
        {
            get => caption;
            set
            {
                caption = value;
            }
        }
        protected internal void SelectItem() => OnItemSelect?.Invoke();
    }
    public class Menu
    {
        Item[] items = new Item[1];
        private int size;
        public int Size
        {
            get => size;
        }
        public Menu()
        {
            size = 0;
        }
        public void Add(Item item)
        {
            Array.Resize(ref items, ++size);
            items[size - 1] = item;
        }
        public void Add(string caption)
        {
            Array.Resize(ref items, ++size);
            items[size - 1] = new Item(caption);
        }
        public void Add(string caption, ItemHandler itemEvent)
        {
            Array.Resize(ref items, ++size);
            items[size - 1] = new Item(caption);
            items[size - 1].OnItemSelect += itemEvent;
        }
        public void Remove(int index)
        {
            if (index < 0 && index > size - 1) 
                throw new IndexOutOfRangeException();
            for (int i = index; i < size - 1; i++) 
                items[i] = items[i + 1];
            Array.Resize<Item>(ref items, --size);
        }
        public Item this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
            }
        }
    }
    public class GraphicalMenu : Menu
    {
        bool closeMenu;
        private int current;
        public GraphicalMenu() : base()
        {
            current = -1;
            closeMenu = false;
        }
        private void DrawGraphicalMenu()
        {
            Console.Clear();
            for (int i = 0; i < Size; i++)
            {
                if (i == current)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(base[i].Caption);
                Console.ResetColor();
            }
        }
        public void MainLoop()
        {
            Console.CursorVisible = false;
            current = 0;
            closeMenu = false;
            while (true)
            {
                DrawGraphicalMenu();
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        base[current].SelectItem();
                        break;
                    case ConsoleKey.UpArrow:
                        if (current > 0)
                            current--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (current < Size - 1)
                            current++;
                        break;
                }
                if (closeMenu) break;
            }
        }
        public void Close() => closeMenu = true;
    }
    public class NumericMenu : Menu
    {
        bool closeMenu;
        public NumericMenu() : base()
        {
            closeMenu = false;
        }
        private void DrawNumericMenu()
        {
            Console.Clear();
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine("[" + i + "] " + base[i].Caption);
            }
            Console.Write("Option: ");
        }
        public void MainLoop()
        {
            Console.CursorVisible = false;
            closeMenu = false;
            while (true)
            {
                DrawNumericMenu();
                try
                {
                    int option = Convert.ToInt32(Console.ReadLine());
                    if (option < 0 || option > Size - 1) 
                        throw new System.IndexOutOfRangeException();
                    base[option].SelectItem();
                }
                catch (System.FormatException)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong format");
                    Console.ResetColor();
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                }
                catch (System.Exception)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect option");
                    Console.ResetColor();
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                }
                if (closeMenu) break;
            }
        }
        public void Close() => closeMenu = true;
    }
}
