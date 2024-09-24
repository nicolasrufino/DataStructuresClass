using System;
using System.Collections.Generic;

public class Customer
{
    public string Name { get; set; }
    public int Items { get; set; }
    public int CheckoutTimePerItem { get; set; }

    public Customer(string name, int items, int checkoutTimePerItem)
    {
        Name = name;
        Items = items;
        CheckoutTimePerItem = checkoutTimePerItem;
    }
}

public class Supermarket
{
    private Queue<Customer> _queue;

    public Supermarket()
    {
        _queue = new Queue<Customer>();
    }

    public void AddCustomer(string name, int items, int checkoutTimePerItem)
    {
        Customer customer = new Customer(name, items, checkoutTimePerItem);
        _queue.Enqueue(customer);
    }

    public void ProcessNextCustomer()
    {
        if (_queue.Count == 0)
        {
            Console.WriteLine("There are no customers in the queue");
            return;
        }

        Customer customer = _queue.Dequeue();
        int totalCheckoutTime = customer.Items * customer.CheckoutTimePerItem;
        Console.WriteLine($"Processing {customer.Name}\nThe following order contains: {customer.Items} items.\nTotal checkout time: {totalCheckoutTime} seconds.");
    }

    public void DisplayQueue()
    {
        Console.WriteLine("The queue:\n");
        foreach (Customer customer in _queue)
        {
            Console.WriteLine($"\n\n{customer.Name} has the following items: \n{customer.Items}");
        }
    }
}
