namespace PhoneBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Contact> contacts = new List<Contact>()
            {
                new Contact("Stephan", "+380345356"),
                new Contact("Оля", "+38032241124"),
                new Contact("Adam", "+48129311315"),
                new Contact("Павло", "+15-12512441"),
                new Contact("Ющенко", "+77777777"),
            };

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine(" ----------------------");
                Console.WriteLine(" |*Personal PhoneBook*|");
                Console.WriteLine(" ----------------------");
                Console.WriteLine();
                Console.WriteLine("Menu:");
                Console.WriteLine("------");
                Console.WriteLine("1.Add contact");
                Console.WriteLine("2.Show contacts");
                Console.WriteLine("3.Search contact(by name)");
                Console.WriteLine("4.Exit");
                Console.Write("Enter your choice (1-4): ");
                var choose = Console.ReadLine();
                var phoneBook = new PhoneBookCollection(contacts);
                string culture = "en";

                switch (choose)
                {
                    case "1":
                        Console.Write("Write name: ");
                        var name = Console.ReadLine();
                        Console.Write("Write number: ");
                        var number = Console.ReadLine();

                        var newContact = new Contact(name, number);
                        phoneBook.AddContact(newContact);
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        var groupedContacts = contacts.OrderBy(c => c.Name)
                                          .GroupBy(c => phoneBook.GroupKey(c.Name, culture));


                        foreach (var group in groupedContacts)
                        {
                            Console.WriteLine(group.Key + $"\n{new string('-', 10)}");

                            foreach (var contact in group)
                            {
                                Console.WriteLine($"{contact.Name}: {contact.Number}");
                            }

                            Console.WriteLine();
                        }
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Write("Enter contact name to search: ");
                        var searchName = Console.ReadLine();
                        phoneBook.SearchContact(searchName);
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        break;
                }

            }
        }
    }
}