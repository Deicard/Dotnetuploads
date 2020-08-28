using System;
using BusinessLogic.Mathematics;

namespace BusinessLogic.Application{
    class MathApp{
        public string Vkv(int a, int b, int c){
            Vkv vkv = new Vkv(a, b, c);
            string output = $"{vkv.ShowEquation()} \nDiscriminant:  {vkv.Discriminant}\n";

            if(vkv.Discriminant < 0){
                output +=  $"No solution!";
                return output;

            }else if(vkv.Discriminant == 0){
                 output +=  $"X1=X2: {vkv.X1}";
                 return output;

            }//endif


            output += $"X1: {vkv.X1}\nX2: {vkv.X2}";
            return output;
        }
    }
}
