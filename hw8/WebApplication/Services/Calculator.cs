namespace WebApplication
{
    public class Calculator
    {
        public string Add(decimal arg1, decimal arg2) => $"{arg1 + arg2}";

        public string Sub(decimal arg1, decimal arg2) => $"{arg1 - arg2}";
        
        public string Mult(decimal arg1, decimal arg2) => $"{arg1 * arg2}";
        
        public string Div(decimal arg1, decimal arg2) => arg2 == 0? "Dividing by zero" : $"{arg1 / arg2}";

    }
}