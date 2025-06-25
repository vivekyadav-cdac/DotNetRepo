using System;


namespace DAY1._1
{
    internal class Properties
    {
        private int prop1;

        /*==========================================================*/
        /* Here we are creating the property for field :- prop1
         * This is helps in validation of the value to be set in field
         */
        /*===========================================================*/

        public int Prop1
        {
            set
            {
                if (value < 100)
                {
                    prop1 = value;
                }
                else
                {
                    Console.WriteLine("invalid prop1 value, value < 100");
                }
            }
            get
            {
                return prop1;
            }
        }

        /*===============================================================*/
        /*Here we are creating a field prop2 and creating auto property 
         *this won't do validation still we should always use property
         *In this case compiler generates the code for get; set;
         *To see generated code of get; set; 
         *Go to utility 
        /*===============================================================*/

        private int prop2;

            public int Prop2
            {
                set; get;
            }
    }
}
