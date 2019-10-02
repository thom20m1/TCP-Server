using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Book
    {
        private string _title;
        private string _author;
        private int _pageNr;
        private long _isbn13;

        public string Title
        {
            get { return _title; }
            set
            {
                if (TitleCheck(value))
                { _title = value; }
            }
        }
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        public int PageNr
        {
            get { return _pageNr; }
            set
            {
                if (PageNrCheck(value))
                { _pageNr = value; }
            }
        }
        public long ISBN13
        {
            get { return _isbn13; }
            set { _isbn13 = value; }
        }

        private Book()
        {}
        public Book(string title, string author, int pageNr, long isbn13)
        {
            if(TitleCheck(title))
            { _title = title; }

            _author = author;

            if(PageNrCheck(pageNr))
            { _pageNr = pageNr; }

            if(ISBN13Check(isbn13))
            { _isbn13 = isbn13; }
        }


        private bool TitleCheck(string title)
        {
            bool result;
            if (title.Length<2)
            {
                Exception exception = new ArgumentException(message:"Titlen skal være mindst 2 bogstaver lang.");
                result = false;
                throw exception;
            }
            else
            {
                result = true;
            }
            return result;
        }
        private bool PageNrCheck(int pageNr)
        {
            bool result;
            if (pageNr <= 10 )
            {
                Exception exception = new ArgumentOutOfRangeException(message: "Bøger skal have mindst 10 sider.", paramName: "pageNr");
                result = false;
                throw exception;
            }
            else if(pageNr >= 1000)
            {
                Exception exceptionTwo = new ArgumentOutOfRangeException(message: "Bøger skal have under 1000 sider.", paramName: "pageNr");
                result = false;
                throw exceptionTwo;
            }
            else
            {
                result = true;
            }
            return result;
        }
        private bool ISBN13Check(long isbn13)
        {
            bool result;
            if(isbn13.ToString().Length!=13)
            {
                Exception exception = new ArgumentOutOfRangeException(message: "ISBN skal være 13 cifre langt", paramName: "isbn13");
                result = false;
                throw exception;
            }
            else
            {
                result = true;
            }
            return result;
        }

        public override string ToString()
        {
            return $"{nameof(Title)}: {Title}, {nameof(Author)}: {Author}, {nameof(PageNr)}: {PageNr}, {nameof(ISBN13)}: {ISBN13}";
        }

    }
}
