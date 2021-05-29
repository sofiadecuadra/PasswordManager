namespace DataManagerDomain
{
    public class TextBoxDataBreaches : IDataBreachesFormatter
    {
        public string txtDataBreaches;
        public string[] ConvertToArray ()
        {
            return txtDataBreaches.Split('\n');
        }
    }
}