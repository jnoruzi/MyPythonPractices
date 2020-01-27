using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace cityNameChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! 2");

            Solution sl = new Solution();
            Console.WriteLine(sl.GetSolution(
                        "image.png, Zanjan, 2019-02-01 12:12:12.000\n"+
                        "pic.jpg, Tehran, 2018-12-12 10:10:10.000\n"+
                        "imagep.png, Zanjan, 2017-02-01 12:12:12.000\n"+
                        "pica.jpg, Tehran, 2019-12-12 10:10:10.000\n"+
                        "picb.jpg, Tehran, 2020-12-12 10:10:10.000\n"+
                        "picc.jpg, Tehran, 2018-12-12 10:10:10.000\n"+
                        "picd.jpg, Tehran, 2017-12-12 10:10:10.000\n"+
                        "pice.jpg, Tehran, 2016-12-12 10:10:10.000\n"+
                        "picf.jpg, Tehran, 2020-10-12 10:10:10.000\n"+
                        "bigpic.jpeg, Zanjan, 2018-10-10 12:10:10.000\n"+
                        "picg.jpg, Tehran, 2018-11-12 10:10:10.000\n"+
                        "pich.jpg, Tehran, 2018-10-12 10:10:10.000\n"+
                        "pici.jpg, Tehran, 2018-09-12 10:10:10.000\n"+
                        "picj.jpg, Tehran, 2016-08-12 10:10:10.000\n"+
                        "pick.jpg, Tehran, 2020-02-12 10:10:10.000\n"+
                        "picl.jpg, Tehran, 2019-02-12 10:10:10.000\n"+
                        "picm.jpg, Tehran, 2019-07-12 10:10:10.000\n"+
                        "imagea.png, Zanjan, 2019-02-01 12:12:12.000\n"+
                        "picn.jpg, Tehran, 2018-12-12 10:10:10.000\n"+
                        "imagep.png, Zanjan, 2017-02-01 12:12:12.000"
                ));
        }
    }

    public class Photo
    {
        public Photo(){}
        public string Name {get;set;}
        public string Extension {get;set;}
        public string City {get;set;}
        public DateTime CaptureDate {get;set;}
        public int OriginalOrder {get;set;}
        public int OrderInGroup {get;set;}
    }
    
    public class Solution {
    
    public Solution(){}
    public string GetSolution(string S) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        string[] fileNames = ((String)S).Split('\n');
        
        List<Photo> lstPhoto = new List<Photo>();
        
        for(int i = 0;i< fileNames.Count();i++)
        {
            string[] photoInfo = fileNames[i].Split(',');
            Photo tmpPhoto = new Photo()
            {
                Name = photoInfo[0].Split('.')[0],
                Extension = photoInfo[0].Split('.')[1].Trim(),
                City = photoInfo[1].Trim(),
                CaptureDate = Convert.ToDateTime(photoInfo[2]),
                OriginalOrder = i+1
                
            };
            
            lstPhoto.Add(tmpPhoto);
        }
        
        List<Photo> sortedResult = lstPhoto.OrderBy(x => x.City).ThenBy(x => x.CaptureDate).ToList();
        
            int orderInGroup = 0;
            
            string cityName = "";
            for(int i=0; i < sortedResult.Count(); i++)
            {
                if(cityName != sortedResult[i].City)
                {
                    orderInGroup = 0;
                    cityName = sortedResult[i].City;
                }
                orderInGroup++;
                sortedResult[i].OrderInGroup = orderInGroup;  
            }
            
        List<Photo> deSortedResult = sortedResult.OrderBy(x => x.OriginalOrder).ToList();
        
        StringBuilder sbResult = new StringBuilder();
        
        for(int i = 0; i<deSortedResult.Count();i++)
        {
            int maxCount = deSortedResult.Count(x=>x.City==deSortedResult[i].City);
            
            string zero = "";
            for(    
                    int j=0;
                    j < Math.Abs(maxCount/10) - Math.Abs(deSortedResult[i].OrderInGroup/10);
                    j++
                )
            {
                zero = zero + "0";
            }
            
            sbResult.AppendLine(deSortedResult[i].City +
            zero +
            deSortedResult[i].OrderInGroup + "."+deSortedResult[i].Extension);   
        }
        
        return sbResult.ToString();
    }
}
}