namespace MyApp
{
  internal class Program
  {
    static void Main(string[] args)
    {
      //--1--//
      Random rnd = new Random();
      Console.Write("Enter queue length: ");
      if (!int.TryParse(Console.ReadLine(), out int queueLength))
      {
        Console.WriteLine("Invalid input");
        return;
      }

      var queueNumbers = new Queue<int>();

      for (int i = 0; i < queueLength; i++)
      {
        queueNumbers.Enqueue(RandomNumber(rnd, 1, 100));
      }
      Console.WriteLine(string.Join(", ", queueNumbers));

      Console.Write("Enter how many elements to reverse: ");
      if (!int.TryParse(Console.ReadLine(), out int k))
      {
        Console.WriteLine("Invalid input");
        return;
      }

      ReverseFirstK(queueNumbers, k);
      Console.WriteLine(string.Join(", ", queueNumbers));
    }

    static int RandomNumber(Random rnd, int min, int max)
    {
      return rnd.Next(min, max);
    }

    static void ReverseFirstK(Queue<int> queue, int k)
    {
      Stack<int> stack = new Stack<int>();

      int remaining = queue.Count - k;

      for (int i = 0; i < k; i++)
      {
        stack.Push(queue.Dequeue());
      }

      while (stack.Count > 0)
      {
        queue.Enqueue(stack.Pop());
      }

      for (int i = 0; i < remaining; i++)
      {
        queue.Enqueue(queue.Dequeue());
      }
    }
  }
}


