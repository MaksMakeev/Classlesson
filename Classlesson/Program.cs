namespace Classlesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = new Stack("a", "b", "c");
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
            Console.WriteLine(s.Show());

            var deleted = s.Pop();
            Console.WriteLine($"Извлек верхний элемент '{deleted}' Size = {s.Size}");

            s.Add("d");
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
            Console.WriteLine(s.Show());

            s.Pop();
            s.Pop();
            s.Pop();
            Console.WriteLine($"size = {s.Size}, Top = {(s.Top == null ? "null" : s.Top)}");

            try
            {
                s.Pop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Что-то пошло не так!");
            }

            //Доп. задание 1
            var s1 = new Stack("a", "b", "c");
            s1.Merge(new Stack("1", "2", "3"));
            Console.WriteLine(s1.Show());

            //Доп. задание 2
            var s2 = Stack.Concat(new Stack("a", "b", "c"), new Stack("1", "2", "3"), new Stack("А", "Б", "В"));
            Console.WriteLine(s2.Show());
        }
    }
}
