namespace DataManagerDomain
{
    public class TxtFileDataBreaches : IDataBreachesFormatter
    {
        public string txtDataBreaches;
        public string[] ConvertToArray()
        {
            return txtDataBreaches.Split('\t');
        }
    }
}
