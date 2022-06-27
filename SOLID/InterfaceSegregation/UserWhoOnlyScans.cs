namespace SOLID.InterfaceSegregation
{
    public class UserWhoOnlyScans: Scanner {

        Scanner scanner;

        public void Scan()
        {
            scanner.Scan();
        }
    }
}
