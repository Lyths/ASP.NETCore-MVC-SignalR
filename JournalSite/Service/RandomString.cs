namespace JournalSite.Service
{
    public class RandomString
    {
        public static string Random()
        {
            Random r = new Random();
            string s = "";
            for (int i = 0; i < 10; i++)
            {
                var a = r.Next(0, 255);
                s += a;
            }
            return s;
        }
    }
}
