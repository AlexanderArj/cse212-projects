using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue some items with different priorities and then dequeue them
    // Expected Result: Items are dequeued in order of highest priority first
    // Defect(s) Found: The loop condition missed the last item, used >= instead of >, and forgot to remove the dequeued item from the list

    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 10);
        priorityQueue.Enqueue("Medium", 5);

        Assert.AreEqual("High", priorityQueue.Dequeue());

        Assert.AreEqual("Medium", priorityQueue.Dequeue());

        Assert.AreEqual("Low", priorityQueue.Dequeue());

    }

    [TestMethod]
    // Scenario: Enqueue some items that share the same highest priority
    // Expected Result: The item closest to the front, should be dequeued first - FIFO
    // Defect(s) Found: Using >= from the comparison caused later items with the same priority to replace earlier ones


    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("High1", 5);
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High2", 5);

        Assert.AreEqual("High1", priorityQueue.Dequeue());

        Assert.AreEqual("High2", priorityQueue.Dequeue());

        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]

    // Scenario: Trying to dequeue from an empty priority queue
    // Expected Result: An error should be thrown with message "The queue is empty."
    // Defect(s) Found: N/A, no issues found

    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}