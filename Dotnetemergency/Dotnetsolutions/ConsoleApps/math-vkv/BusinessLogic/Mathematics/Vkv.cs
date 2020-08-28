using System;

namespace BusinessLogic.Mathematics{
    class Vkv{
        public Vkv(int a, int b, int c){
            A = a;
            B = b;
            C = c;
        }
        public int A{
            get;
            set;
        }

        public int B {
            get;
            set;
        }

        public int C{
            get;
            set;

        }

        public int? X1{
            get {
                if(Discriminant < 0 || A == 0){
                    return null;
                }

                return (int)((-1 * B) + Math.Sqrt(Discriminant))/(2*A);
            }
        }

        public int? X2 {
            get{
                if(Discriminant < 0 || A == 0){
                    return null;
                }

                return (int)((-1 * B) - Math.Sqrt(Discriminant))/(2*A);
            }
        }

        public string ShowEquation(){
            return $"{A}x² + {B}x + {C} = 0";
        }

        public int Discriminant{
            get {
                return (B*B) - (4*A*C);
            } 
        }

        
    }
}
