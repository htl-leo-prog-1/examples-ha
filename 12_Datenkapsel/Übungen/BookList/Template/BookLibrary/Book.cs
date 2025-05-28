/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: Book Library
 *--------------------------------------------------------------
 */

namespace BookLibrary;

public class Book
{
    private string _author = string.Empty;
    private string _title = string.Empty;
    private string _publisher = string.Empty;
    private string _isbn = string.Empty;

    public void SetAuthor(string author)
    {
        _author = author;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public void SetTitle(string title)
    {
        _title = title;
    }

    public string GetTitle()
    {
        return _title;
    }

    public void SetPublisher(string publisher)
    {
        _publisher = publisher;
    }

    public string GetPublisher()
    {
        return _publisher;
    }

    public void SetISBN(string isbn)
    {
        _isbn = isbn;
    }

    public string GetISBN()
    {
        return _isbn;
    }
}