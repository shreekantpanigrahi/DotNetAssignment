
namespace Question1
{
    public static class EmployeeExtensions
    {
        public static int CalcYearOfExp(this Employee emp)
        {
            return DateTime.Now.Year - emp.JoinDate.Year;
        }
    }
}
