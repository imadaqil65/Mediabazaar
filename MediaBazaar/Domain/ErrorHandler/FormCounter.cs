namespace Domain.FormCounter
{
    public class FormCounter
    {
        private static int number = 0;

        public static int Formcounter
        {
            get { return number; }
            set
            {
                if (value == 0 || value == 1)
                {
                    number = value;
                }
            }
        }
    }
}

