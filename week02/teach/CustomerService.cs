/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {

    public static void Run() {
        // Test 1
        // Scenario: Create a queue with an invalid size 0 or negative.
        // Expected Result: The default size should be 10.

        Console.WriteLine("Test 1");
        var service = new CustomerService(0);
        Console.WriteLine(service);

        // Defects Found: None. The constructor works correctly.

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Try to add more customers than the maximum queue size.
        // Expected Result: Allow customers up to the limit and display an error when exceeded.

        Console.WriteLine("Test 2");
        service = new CustomerService(2);
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine(service);
        // Defects Found:_queue.Count > _maxSize allows one extra customer

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Serve a customer when the queue has customers.
        // Expected Result: Display and remove the first customer added
        Console.WriteLine("Test 3");
        service = new CustomerService(4);
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine($"Before serving: {service}");
        service.ServeCustomer();
        Console.WriteLine($"After serving: {service}");

        // Defects Found: ServeCustomer removes the first customer but displays the second one.

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Try to serve a customer when the queue is empty.
        // Expected Result: display an error message instead of throwing an exception.

        Console.WriteLine("Test 4");
        service = new CustomerService(4);
        service.ServeCustomer();

        // Defects Found: There is no check for an empty queue

        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count > _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        _queue.RemoveAt(0);
        var customer = _queue[0];
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}