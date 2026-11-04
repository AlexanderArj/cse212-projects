public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //
        //Definition: A multiple of a number is the product you get when you multiply that number by any integer (1, 2, 3, 4, ...)
        //Formula: Multiple = number * integer

        // 1) First create a double array of the specified "length" passed as an argument to the method.

        double[] result = new double[length];

        // 2) Create a loop that iterates from 0 to "length - 1" ( for (int i = 0; i < length; i++) )
        // 3) Inside the loop, move through the array using each index at a time
        // 4) Assign a value to each element of the array using the following formula:

        // result[i] = number * (i + 1)

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        // 5) Return the array, showing all elements as the multiples of the number for the specified length

        return result;

    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // 1) Create an auxiliary list of the same size as "data"

        List<int> aux = new List<int>(new int[data.Count]);

        // 2) Create  a loop that iterates through each element in the original data list, from 0 to (data.count - 1), that means from first to last element.
        // for (int i = 0; i < data.Count; i++)

        for (int i = 0; i < data.Count; i++)
        {
            // 3) Inside the loop, we can calculate the new index for each element as follows:
            // Add "amount" to the current index (i + amount)
            // We can use the modulo operator to wrap around
            // if the new position goes beyond the total number of elements
            // int newIndex = (i + amount) % data.Count;

            int newIndex = (i + amount) % data.Count;

            // 4) Assign each element from the original list into the aux. list at its corresponding "newIndex"

            aux[newIndex] = data[i];
        }

        // 5) Since we need to return original list modified, we need to clear it so it becomes empty, and then copy values from the aux list into it
        data.Clear();

        // 6) Finally, we copy all rearranged elementrs from aux. list back to our original list, using the method AddRange

        data.AddRange(aux);
        
    }
}
