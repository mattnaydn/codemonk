using System;
using System.Collections.Generic;

public class Seating
{
    public static void Main(string[] args)
    {
        int numTestCases = int.Parse(Console.ReadLine());
        List<int> seats = new List<int>();
        Seating seating = new Seating();
        
        for(int i=0; i<numTestCases; i++)
        {
            seats.Add(int.Parse(Console.ReadLine()));                
        }
        
        seats.ForEach(seat => 
        {
            string seatType = seating.calculateSeatType(seat);        
            Console.WriteLine(seating.findOpposite(seat, seatType)+" "+seatType);
        });
    }
    
    public string calculateSeatType(int seatNum)
    {
        if((seatNum % 6 == 0) || (seatNum % 6 == 1)) return "WS";
        else if((seatNum % 3 == 0) || ((seatNum - 1) % 3 == 0)) return "AS";
        else return "MS";
    }
    
    public int findOpposite(int seatNum, string seatType)
    {
        int[] rightFacing = {1,2,3,4,5,6,13,14,15,16,17,18,25,26,27,28,29,30,37,38,39,40,41,42,49,50,51,52,53,54,61,62,63,64,65,66,73,74,75,76,77,78,85,86,87,88,89,90,97,98,99,100,101,102};    
        int[] leftFacing = {7,8,9,10,11,12,19,20,21,22,23,24,31,32,33,34,35,36,43,44,45,46,47,48,55,56,57,58,59,60,67,68,69,70,71,72,79,80,81,82,83,84,91,92,93,94,95,96,103,104,105,106,107,108};
    
        int opposite;
    
        if(seatType.Equals("WS"))
        {
            if(contains(seatNum, rightFacing)) //if right facing
            {
                if(seatNum % 6 == 0) return seatNum+1;
                else return seatNum + 11;
            }
            if(seatNum % 6 == 0) return seatNum-11;
            else return seatNum-1;
            
        }
        else if(seatType.Equals("AS"))
        {
            if(contains(seatNum, rightFacing)) //if right facing
            {
                if(seatNum % 4 == 0) return seatNum + 5;
                else return seatNum + 7;
            }
            if(seatNum % 3 == 0) return seatNum - 5;
            else return seatNum - 7;
            
        }
        else
        {
            if(contains(seatNum, rightFacing)) //if right facing
            {
                return seatNum + 9;
            }
            return seatNum - 9;
        }
        return -1;
    }
    
    private bool contains(int seatNum, int[] list)
    {
        for(int i=0; i<list.Length; i++)
        {
            if(list[i] == seatNum)return true;
        }
        return false;
    }
}