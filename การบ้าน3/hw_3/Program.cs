using System;

namespace hw_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue CPUQueue = new Queue();
            char instruction,data;
            int count = 0;

            while (true)
            {
                Console.Write("Instruction: ");
                instruction = char.Parse(Console.ReadLine());
                if (instruction == '?')
                {
                    break;
                }
                Console.Write("Data: ");
                data = char.Parse(Console.ReadLine());
                Node CPU = new Node(instruction, data);
                CPUQueue.Push(CPU);
            }

            Node instructionQueue;

            while (true)
            {
                instructionQueue = CPUQueue.Pop();
                count = 2;
                if (instructionQueue == null)
                {
                    break;
                }
            }
            Console.WriteLine("CPU cycles needed: {0}", count);
        }
    }
    class Node
    {
        public char Instruction,Data;      
        public Node Next;
        public Node(char instructionValue, char dataValue)
        {
            Instruction = instructionValue;
            Data = dataValue;
        }      
    }
    class Queue
    {
        private Node Root;
        public void Push(Node node)
        {
            if (Root == null)
            {
                Root = node;
            }
            else
            {
                Node ptr = Root;
                while (ptr.Next != null)
                {
                    ptr = ptr.Next;
                }
                ptr.Next = node;
            }
        }
        public Node Pop()
        {
            if (Root == null)
            {
                return null;
            }
            Node node = Root;
            Root = Root.Next;
            node.Next = null;
            return node;
        }
        public Node Get(int index)
        {
            Node node = Root;
            while (index > 0)
            {
                if (node == null)
                {
                    throw new IndexOutOfRangeException();
                }
                node = node.Next;
                index--;
            }
            return node;
        }
    }
}
