using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequnce = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            
            int result = 0;

            while (sequnce.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());
                int currentIndexValue = 0;

                if (index < 0)
                {
                    int lastElement = sequnce[sequnce.Count - 1];
                    currentIndexValue = sequnce[0];
                    result += sequnce[0];
                    sequnce.RemoveAt(0);
                    sequnce.Insert(0, lastElement);

                    for (int i = 0; i < sequnce.Count; i++)
                    {
                        if (currentIndexValue >= sequnce[i])
                        {
                            sequnce[i] += currentIndexValue;
                        }
                        else
                        {
                            sequnce[i] -= currentIndexValue;
                        }
                    }

                }
                else if(index > sequnce.Count - 1)
                {
                    int firstElement = sequnce[0];
                    currentIndexValue = sequnce[sequnce.Count -1];
                    result += sequnce[sequnce.Count-1];
                    sequnce.RemoveAt(sequnce.Count - 1);
                    sequnce.Add(firstElement);
                    

                    for (int i = 0; i < sequnce.Count; i++)
                    {
                        if (currentIndexValue >= sequnce[i])
                        {
                            sequnce[i] += currentIndexValue;
                        }
                        else
                        {
                            sequnce[i] -= currentIndexValue;
                        }
                    }
                }
                else
                {
                    currentIndexValue = sequnce[index];
                    sequnce.RemoveAt(index);
                    result += currentIndexValue;

                    for (int i = 0; i < sequnce.Count; i++)
                    {
                        if (currentIndexValue >= sequnce[i])
                        {
                            sequnce[i] += currentIndexValue;
                        }
                        else
                        {
                            sequnce[i] -= currentIndexValue;
                        }
                    }
                }
                
            }
            Console.WriteLine(result);

        }
    }
}
