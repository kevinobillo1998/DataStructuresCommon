namespace MyClasses;

public class MyString : IComparable
{
    //private string _stringField;

    /* C# can have properties which look like public variables to
       the outside, but when you assign a property it calls
       its set method, and when you retrieve the value it calls its
       get method.
    */
    /*public string StringField
    {
        get 
        {
            return _stringField;
        }
        set
        {
            _stringField = value;
        }
    }*/
    public string StringField { get; set; }

    public int StringLength
    {
        get
        {
            return StringField.Length;
        }
    }

    public MyString()
    {
        StringField = "";
    }

    public MyString(string s)
    {
        if (s == "3")
        {
            s = "3 which is the greatest magic numbeR!!!";
        }
        StringField = s;
    }

    public override string ToString()
    {
        return StringField;
    }

    /* We need to implement CompareTo in order to implement the IComparable
     * interface.
     * This method compares the current object to the one passed in.
     * Returns a negative value if the object precedes the passed in object
     * Returns a positive value if the object comes after the passed in object
     * returns zero if the objects are in the same position
     */
    public int CompareTo(object obj)
    {
        MyString other = (MyString)obj;
        int result = 0;
        // Let us compare based on Length.
        // If they're the same length, we'll go off of alphabetical order
        if (this.StringLength == other.StringLength)
        {
            result = this.StringField.CompareTo(other.StringField);
        }
        else
        {
            result = this.StringLength - other.StringLength;
        }
        return result;
    }

    public static bool operator < (MyString left, MyString right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator > (MyString left, MyString right)
    {
        return right.CompareTo(left) < 0;
    }
}
