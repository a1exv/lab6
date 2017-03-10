using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public class Note
        {
            public string firstName{
                get; set;
            }
            public string secondName{get;set;}
            public DateTime dateofBirth;
            public int phoneNumber{get;set;}
            public string email{get;set;}
            public Note(){
                firstName = "unknown";
                secondName = "unknown";
                dateofBirth=new DateTime(2000,1,1);
                phoneNumber=100000;
                email="unknown@unknown.com";
            }
            public Note(string _firstName, string _secondName, DateTime dt, int _phone, string _email){
                firstName=_firstName;
                secondName=_secondName;
                dateofBirth=dt;
                phoneNumber=_phone;
                email=_email;
            }
            public override string ToString(){
                   return String.Format("Name - {0}, second name - {1}, date of birth - {2}, phone number - {3}, email - {4}", firstName, secondName, dateofBirth, phoneNumber, email);
            }
       
        }
        public class NotePad:IEnumerable
        {
            Note[] listnote;
            int n;
            int k = 0;
            public NotePad()
            {
                n = 10;
                listnote = new Note[n];
                Console.WriteLine("Notepad for {0} notes has created", n);
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
            }
            public NoteEnum GetEnumerator()
            {
                return new NoteEnum(listnote);
            }
            public NotePad(int n)
            {
                this.n = n;
                listnote = new Note[n];
                Console.WriteLine("Notepad for {0} notes has created", n);
            }
            public void SearchByFirstName(string _firstName)
            {
                for (int i = 0; i < k; i++)
                {
                    if (listnote[i].firstName == _firstName)
                    {
                        Console.WriteLine(listnote[i].ToString());
                    }
                }
            }
            public void SearchBySecondName(string _SecondName)
            {
                for (int i = 0; i < k; i++)
                {
                    if (listnote[i].secondName == _SecondName)
                    {
                        Console.WriteLine(listnote[i].ToString());
                    }
                }
            }
            public void SearchByDate(DateTime _dt)
            {
                for (int i = 0; i < k; i++)
                {
                    if (listnote[i].dateofBirth == _dt)
                    {
                        Console.WriteLine(listnote[i].ToString());
                    }
                }
            }
            public void SearchByPhone(int _phone)
            {
                for (int i = 0; i < k; i++)
                {
                    if (listnote[i].phoneNumber == _phone)
                    {
                        Console.WriteLine(listnote[i].ToString());
                    }
                }
            }
            public void SearchByEmail(string _email)
            {
                for (int i = 0; i < k; i++)
                {
                    if (listnote[i].email == _email)
                    {
                        Console.WriteLine(listnote[i].ToString());
                    }
                }
            }
            public void Add(Note nt)
            {
                listnote[k] = nt;
                k++;
            }
            public void Remove(int index)
            {
                List<Note> li = new List<Note>(listnote);
                li.RemoveAt(index);
                var tmp = li.ToArray();
                listnote = tmp;
            }
            public Note this[int index]
            {
                get
                {
                 
                    return listnote[index];
                }
                set
                {
                    listnote[index] = value;
                }
            }

        }
        public class NoteEnum : IEnumerator
        {
            public Note[] listnote;
            int position = -1;
            public NoteEnum(Note[] list)
            {
                listnote = list;
            }
            public bool MoveNext()
            {
                position++;
                return (position < listnote.Length);
            }
            public void Reset()
            {
                position = -1;
            }
            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
            public Note Current
            {
                get
                {
                    try
                    {
                        return listnote[position];
                    }
                    catch(IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        
        static void Main(string[] args)
        {
            NotePad nt = new NotePad(20);
            nt.Add(new Note("ivan", "ivanov", new DateTime(2010, 10, 5), 12345, "ivan@mail"));
            nt.Add(new Note("petr", "ivanov", new DateTime(2010, 10, 5), 12345, "ivan@mail"));
            nt.Add(new Note("ivan", "petrov", new DateTime(2010, 10, 5), 12345, "ivan@mail"));
            nt.Add(new Note("ivan", "ivanov", new DateTime(2010, 10, 5), 12345, "ivan@mail"));
            foreach (Note note in nt)
            {
                if (note != null)
                    Console.WriteLine(note.ToString());
                else break;
            }
            nt.SearchByFirstName("ivan");
        }
    }
}
