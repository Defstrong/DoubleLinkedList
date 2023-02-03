using System.Collections;
using System.Collections.Specialized;
using Entity;
namespace List
{
    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        Node<T> startPoint;
        Node<T> endPoint;
        public int count;


        public void FindElementWhitIdx(int idxElement, ref Node<T> elementForOut)
        {
            elementForOut = startPoint;
            int idxForFind = 1;
            while (idxForFind != idxElement && count > 0)
            {
                elementForOut = elementForOut.Next;
                idxForFind++;
            }
        }

        public void Add(T element)
        {
            Node<T> elementToAdd = new Node<T>(element);
            if(count == 0)
            {
                endPoint = elementToAdd;
            }
            if (startPoint is null)
            {
                startPoint = elementToAdd;
                count++;
            }
            else
            {
                startPoint.Previous = elementToAdd;
                elementToAdd.Next = startPoint;
                startPoint = elementToAdd;
                count++;
            }
        }
        public bool AddToMiddle(T element)
        {
            int idxMiddleElement = (count / 2) + (count % 2);
            var elementToAddMiddle = new Node<T>(element);
            Node<T> middleElement = null;
            FindElementWhitIdx(idxMiddleElement, ref middleElement);

            if (count == 0)
                startPoint = elementToAddMiddle;
            if (middleElement is not null)
            {
                if (count == 0)
                {
                    startPoint = elementToAddMiddle;
                    count++;
                }
                middleElement.Next.Previous = elementToAddMiddle;
                elementToAddMiddle.Next = middleElement.Next;

                middleElement.Next = elementToAddMiddle;

                elementToAddMiddle.Previous = middleElement;
                count++;
                return true;
            }

            return false;
        }

        public bool RemoveEndPoint()
        {
            if(count > 0)
            {
                endPoint.Previous.Next = null;
                endPoint = endPoint.Previous;
                count++;
                return true;
            }
            return false;
        }

        public bool RemoveStartPoint()
        {
            if(count > 0)
            {
                startPoint = startPoint.Next;
                startPoint.Previous = null;
            }
            return false;
        }


        public void ReversDoubleList()
        {
            Console.WriteLine();
            if(count > 0)
            {
                int count2 = count;
                var dupleStartPoint = startPoint;
                while(count2 != 0)
                {
                    (dupleStartPoint.Next, dupleStartPoint.Previous) = (dupleStartPoint.Previous, dupleStartPoint.Next);
                    dupleStartPoint = dupleStartPoint.Previous;
                    count2--;
                }
                (startPoint, endPoint) = (endPoint, startPoint);
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = startPoint;

            while (currentNode is not null)
            {
                yield return currentNode.Data;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
