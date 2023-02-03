using List;

var doubleLinkedList = new DoubleLinkedList<int>();

doubleLinkedList.Add(1);
doubleLinkedList.Add(2);
doubleLinkedList.Add(3);
doubleLinkedList.Add(3);
doubleLinkedList.AddToMiddle(412);
doubleLinkedList.AddToMiddle(544);
doubleLinkedList.AddToMiddle(467);
doubleLinkedList.ReversDoubleList();

foreach (var ii in doubleLinkedList)
    Console.WriteLine(ii);  