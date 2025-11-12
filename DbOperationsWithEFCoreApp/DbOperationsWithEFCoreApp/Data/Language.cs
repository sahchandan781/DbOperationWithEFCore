namespace DbOperationsWithEFCoreApp.Data
{
    public class Language
    {
        public int LanguageId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<Book> Books { get; set;  }


    }
}
