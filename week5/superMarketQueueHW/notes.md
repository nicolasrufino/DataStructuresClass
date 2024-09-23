Objective: Simulate a supermarket checkout system using a queue. In this system, customers arrive at the checkout and are processed in the order they arrived (FIFO – First In, First Out).
Requirements:
Customer Class:

Each customer will have:
A name.
Number of items they have to check out.
Time it takes to check out each item (e.g., 1 second per item).
Queue Simulation:

Use a queue to represent the line of customers waiting to check out.
Customers are added to the queue, and they are processed one by one.
The time taken for each customer is determined by the number of items they have.
Supermarket Class:

AddCustomer(string name, int items): Adds a new customer to the queue.
ProcessNextCustomer(): Dequeues the next customer and simulates the checkout process (e.g., print their name and how long it takes to process them).
DisplayQueue(): Displays the current queue of customers waiting to check out.


Bonus Feature (Optional for Fun):

Express Checkout Line: Implement a second queue for customers with 5 items or less, allowing for faster processing.