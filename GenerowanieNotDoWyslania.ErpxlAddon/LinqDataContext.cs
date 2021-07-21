namespace GenerowanieNotDoWyslania.ErpxlAddon
{
    internal class LinqDataContext
    {
        private string connectionString;        

        public LinqDataContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        LinqDataContext linq = new LinqDataContext("");       
    }
}