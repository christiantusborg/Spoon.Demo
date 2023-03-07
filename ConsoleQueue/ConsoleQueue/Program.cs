// See https://aka.ms/new-console-template for more information

var queue = new PriorityQueue<string,int>();

queue.Enqueue("Anders",2);

queue.Enqueue("Tusborg",1);
queue.Enqueue("Anders2",2);
queue.Enqueue("Mette2",3);
queue.Enqueue("Tusborg2",1);
queue.Enqueue("Mette1",3);
while (true)
{
    if (queue.Count > 0)
    {
        var item = queue.Dequeue();
        Console.WriteLine(item);
    }
}