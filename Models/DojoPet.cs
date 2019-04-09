using System;

namespace DojoDachi.Models
{
    public class DojoPet
    {
        public static Random r = new Random();
        public int Happiness {get; set;}
        public int Fullness {get; set;}
        public int Energy {get; set;}
        public int Meals {get; set;}
        public string Message {get; set;}

        public DojoPet()
        {
            Happiness = 20;
            Fullness = 20;
            Energy = 50;
            Meals = 3;
        }
        public void UpdateStatus(int h, int f, int e, int m, string msg)
        {
            Happiness = h;
            Fullness = f;
            Energy = e;
            Meals = m;
            Message = msg;
        }


        public void Feed()
        {
            CheckDead();
            CheckWin();
            int chance = r.Next(0, 100);
            if(chance <= 25)
            {
                Meals--;
                Message = "DojoDachi did not feel like eating, -1 Meal";
            }
            else{
                if (Meals > 0)
                {
                    Meals--;
                        int num = r.Next(5,11);
                        Fullness += num;
                        Message = $"You fed DojoDachi, +{num} Fullness, -1 Meal";
                }
                else
                    Message = "Cannot feed DojoDachi, you have no more meals";
            }
            UpdateStatus(Happiness, Fullness, Energy, Meals, Message);
                // return Fullness;
        }

        public void Play()
        {
            CheckDead();
            CheckWin();
            int chance = r.Next(0, 100);
            if(chance <= 25)
            {
                Energy -= 5;
                Message = "DojoDachi did not feel like playing, -5 Energy";
            }
            else
            {
                Energy -= 5;
                int num = r.Next(5, 11);
                Happiness += num;
                Message = $"You played with DojoDachi, +{num} Happiness, -5 Energy";
                // return Happiness;  
            }
            UpdateStatus(Happiness, Fullness, Energy, Meals, Message);
                // return Happiness;  
        }

        public void Work()
        {
            CheckDead();
            CheckWin();
            Energy -= 5;
            int num = r.Next(1,4);
            Meals += num;
            Message = $"You made DojoDachi work, +{num} Meals, -5 Energy";
            UpdateStatus(Happiness, Fullness, Energy, Meals, Message);
            // return Meals;
        }

        public void Sleep()
        {
            CheckDead();
            CheckWin();
            Energy += 15;
            Fullness -= 5;
            Happiness -= 5;
            Message = $"DojoDachi had a great nights rest, +15 Energy, -5 Fullness, -5 Happiness";
            UpdateStatus(Happiness, Fullness, Energy, Meals, Message);
        }

        public bool CheckDead()
        {
            if(Fullness < 0 || Happiness < 0)
            {
                Message = "You killed DojoDachi, You LOST!! Play Again?";
                return true;
            }
            else
                return false;
        }

        public bool CheckWin()
        {
            if(Fullness >= 100 && Energy >= 100 && Happiness >= 100)
            {
                Message = "You WON! Play Again?";
                return true;
            }
            else
                return false;
        }
    }
}