using System;

namespace DAY1
{
    // below code is not possible because 
    /*======================================================================*/
    //A namespace cannot directly contain members such as fields or methods.
    //A namespace can contain other namespaces, structs, and classes.
    /*=======================================================================*/

    //code:
    //int isthispossible = 0;

    /*=======================================================================*/
    //Also  C# does allow nested namespaces,
    //but they must be defined outside of classes, not inside
    /*=======================================================================*/

    public class NestedNameSpace
    {int outerint = 10;}
        
        namespace InnerNameSpace
        {
            public class InnerClass
            {
            public int innerint = 20;

                public void Inner()
                {
                    Console.WriteLine("accessing class data members, value :" + innerint); 
                }

            }
        }
   
}
