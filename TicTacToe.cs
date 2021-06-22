//7.5
using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        //массив с цифрами (в процессе игры они будут заменятся на крестик либо нолик)
        static char[] chars = {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
        //лист с занятыми ячейками
        static List<int> occupiedCells = new List<int>();
        //Состояние игрового поля
        static string fieldState = UpdateField(chars);
        //Ход игрока хрестика/нолика
        static bool isXTurn = true;
        //Ход первого/второго игрока
        static int playerTurn = 1;
        //Остаток ходов
        static int turnsLeft = 9;
        
        static void Main()
        {
            while (true)
            {
                string userChoiceStr;
                int userChoice;

                while (turnsLeft > 0)
                {
                    Console.WriteLine($"Player {playerTurn}: Choose your field: ");
                    
                    userChoiceStr = Console.ReadLine();
                    //проверяем, что бы игрок ввел число от 1 до 9
                    while (!int.TryParse(userChoiceStr, out userChoice) ||
                           (int.Parse(userChoiceStr) > 9 || int.Parse(userChoiceStr) < 1))
                    {
                        Console.WriteLine("Your choice should be an integer (1-9)");
                        Console.WriteLine($"Player {playerTurn}: Choose your field: ");
                        userChoiceStr = Console.ReadLine();
                    }
                    //парсим строку в int
                    userChoice = int.Parse(userChoiceStr);

                    switch (userChoice)
                    {
                        case 1:
                            CalculateTurn(1);
                            break;
                        case 2:
                            CalculateTurn(2);
                            break;
                        case 3:
                            CalculateTurn(3);
                            break;
                        case 4:
                            CalculateTurn(4);
                            break;
                        case 5:
                            CalculateTurn(5);
                            break;
                        case 6:
                            CalculateTurn(6);
                            break;
                        case 7:
                            CalculateTurn(7);
                            break;
                        case 8:
                            CalculateTurn(8);
                            break;
                        case 9:
                            CalculateTurn(9);
                            break;
                    }
                }
                
                Console.WriteLine("Press any key to reset the game");
                Console.ReadKey();
                Console.Clear();
                
                //возвращаем переменные в исходное состояние
                chars = new []{'1', '2', '3', '4', '5', '6', '7', '8', '9'};
                occupiedCells = new List<int>();
                fieldState = UpdateField(chars);
                //Ход игрока хрестика/нолика
                isXTurn = true;
                //Ход первого/второго игрока
                playerTurn = 1;
                //Остаток ходов
                turnsLeft = 9;
            }
        }

        static void CalculateTurn(int caseNum)
        {
            //если числа (caseNum) нету в листе с занятыми ячейками, то делаем ход
                            if (!occupiedCells.Contains(caseNum))
                            {
                                //если ход игрока первого игрока (крестика), то ставим крестик вместо цифры
                                if (isXTurn)
                                {
                                    chars[caseNum-1] = 'X';
                                    isXTurn = false;
                                }
                                //если ход игрока второго игрока (нолика), то ставим нолик вместо цифры
                                else
                                {
                                    chars[caseNum-1] = 'O';
                                    isXTurn = true;
                                }
                                
                                Console.Clear();
                                //обновляем поле
                                fieldState = UpdateField(chars);
                                //добавляем номер ячейки в лист
                                occupiedCells.Add(caseNum);
                                
                                //если игрок этим ходом выиграл, то меняем количество ходов на 0 и игра заканчивается
                                if (isWin(chars, playerTurn)) turnsLeft = 0;
                                //если не выиграл, то меняем номер игрока
                                else
                                {
                                    if (playerTurn == 1) playerTurn = 2;
                                    else playerTurn = 1;
                                }
                                //уменьшает количество ходов на 1
                                turnsLeft -= 1;
                            }
                            //если число (1) есть в листе с занятыми ячейками, то выводим ошибку
                            else
                            {
                                Console.WriteLine("This cell is already occupied!");
                            }
        }

        static string UpdateField(char[] chars)
        {
            string fieldState = "   |   |   \n" +
                                $" {chars[0]} | {chars[1]} | {chars[2]} \n" +
                                "   |   |   \n" +
                                "-----------\n" +
                                "   |   |   \n" +
                                $" {chars[3]} | {chars[4]} | {chars[5]} \n" +
                                "   |   |   \n" +
                                "-----------\n" +
                                "   |   |   \n" +
                                $" {chars[6]} | {chars[7]} | {chars[8]} \n" +
                                "   |   |   \n";
            Console.WriteLine(fieldState);
            return fieldState;
        }

        static bool isWin(char[] chars, int playerNum)
        {
            //сравниваем char'ы по горизонтали 
            if ((chars[0].Equals(chars[1]) && chars[0].Equals(chars[2])) 
                || (chars[3].Equals(chars[4]) && chars[3].Equals(chars[5])) 
                || (chars[6].Equals(chars[7]) && chars[6].Equals(chars[8])))
            {
                Console.WriteLine($"Player {playerNum} has won!");
                return true;
            }
            //сравниваем char'ы нахрест
            else if ((chars[0].Equals(chars[4]) && chars[0].Equals(chars[8])) ||
                     (chars[2].Equals(chars[4]) && chars[2].Equals(chars[6])))
            {
                Console.WriteLine($"Player {playerNum} has won!");
                return true;
            }
            //сравниваем char'ы по вертикали 
            else if ((chars[0].Equals(chars[3]) && chars[0].Equals(chars[6])) ||
                     (chars[1].Equals(chars[4]) && chars[1].Equals(chars[7])) ||
                     (chars[2].Equals(chars[5]) && chars[2].Equals(chars[8])))
            {
                Console.WriteLine($"Player {playerNum} has won!");
                return true;
            }
            else return false;
        }
    }
}