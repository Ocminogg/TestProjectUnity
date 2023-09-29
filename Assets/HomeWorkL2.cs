using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using static UnityEditor.Progress;


public class MyList
{
    private int[] m_array;

    public int Count { get; private set; }

    public int Capacity
    {
        get
        {
            return m_array.Length;
        }
        set
        {
            if (value > m_array.Length)
            {
                System.Array.Resize(ref m_array, value);
            }
        }
    }

    public MyList()
    {
        m_array = new int[4];

    }

    public MyList(int capacity)
    {
        m_array = new int[capacity];
    }

    public int this[int index]
    {
        get
        {
            CheckIndexRange(index);
            return m_array[index];
        }
        set
        {
            CheckIndexRange(index);
            m_array[index] = value;
        }
    }

    private bool CheckIndexRange(int index)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException();

        return true;
    }
    private void IncreaseCapacityIfNeed()
    {
        if (Count == Capacity)
        {
            Capacity *= 2;
        }
    }
    public void Add(int item)
    {
        IncreaseCapacityIfNeed();

        m_array[Count] = item;
        Count++;
        //ћен€ем размер массива
        //Array.Resize(ref m_array, m_array.Length + 1);
        //«аписали новое число в конец массива
        //m_array[m_array.Length - 1] = item;

        Debug.Log("ƒобавили значение в массив " + item);
        for (int i = 0; i < m_array.Length; ++i)
        {
            Debug.Log(m_array[i]);
        }

        Debug.Log("«акончили");
    }

    public void Insert(int index, int item)
    {
        IncreaseCapacityIfNeed();   
        int t1 = m_array[index];
        //—мещ€ем массив начина€ с индекса
        for (int i = index; i < m_array.Length; ++i)
        {
            int t2 = m_array[i + 1];
            m_array[i+1] = t1;
            t1 = t2;
        }
        m_array[index] = item;
        Count++;
        ////—оздаем пустую копию массива размером на один больше
        //int[] m_arrayCopy = new int[m_array.Length + 1];
        ////«аполн€ем m_arrayCopy до тех пор, пока не дойдем до нужного индекса
        //for (int i = 0; i < index+1; ++i)
        //{
        //    if (i == index)
        //    {
        //        m_arrayCopy[i] = item;
        //        continue;
        //    }
        //    m_arrayCopy[i] = m_array[i];
        //}
        ////«аполн€ем остальную часть массива начина€ с индекса
        //for (int i = index; i < m_array.Length; ++i)
        //{            
        //    m_arrayCopy[i+1] = m_array[i];
        //}
        //m_array = m_arrayCopy;

        Debug.Log("ƒобавили значение в массив по индексу" + item);
        for (int i = 0; i < m_array.Length; ++i)
        {
            Debug.Log(m_array[i]);
        }
        Debug.Log("«акончили");
        
    }

    public int IndexOf(int item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (m_array[i] == item)
            {
                return i;
            }
        }
        //Array.IndexOf(m_array, item);
        return -1;
    }

    public bool Remove(int item)
    {
        //создаю массив размеров на один меньше дл€ копировани€ в него нового
        int[] m_arrayCopy = new int[m_array.Length - 1];
        //флаг дл€ отслеживани€ удалени€ элемента, чтобы удалить только первое найденное вхождение
        bool flag = false;
        //поиск элемента дл€ удалени€ и заполнение нового
        //находим необходимое значение и останавливаем на нем цикл
        int index = 0;
        for (int i = 0; i < m_array.Length; ++i)
        {
            if ((m_array[i] == item) & (flag == false))
            {
                index = i;
                flag = true;
                break;
            }
            m_arrayCopy[i] = m_array[i];
        }
        //ѕродолжаем цикл, но уже пропустив удаленное значение 
        for (int i = index; i < m_array.Length-1; ++i)
        {            
            m_arrayCopy[i] = m_array[i+1];
        }
        m_array = m_arrayCopy;

        Debug.Log("¬ыполнили команду Remove");
        for (int i = 0; i < m_array.Length; ++i)
        {
            Debug.Log(m_array[i]);
        }

        return flag;

        
    }

    public void RemoveAt(int index)
    {
        int[] m_arrayCopy = new int[m_array.Length - 1];

        bool flag = false;

        for (int i = 0; i < m_array.Length; ++i)
        {
            if ((m_array[i] == m_array[index]) & (flag == false))
            {
                flag = true;
                break;
            }
            m_arrayCopy[i] = m_array[i];
        }
        for (int i = index; i < m_array.Length - 1; ++i)
        {
            m_arrayCopy[i] = m_array[i + 1];
        }
        m_array = m_arrayCopy;

        Debug.Log("¬ыполнили команду RemoveAt");
        for (int i = 0; i < m_array.Length; ++i)
        {
            Debug.Log(m_array[i]);
        }
    }

    public bool Contains(int item)
    {
        for (int i = 0; i < m_array.Length; ++i)
        {
            if (m_array[i] == item)
            {
                return true;                
            }         
        }        
        return false;
    }

    public void Clear()
    {
        Array.Clear(m_array,0, m_array.Length);
    }
}


public class HomeWorkL2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //List<MyList> list = new List<MyList>();
        MyList myList = new MyList(0);
        myList.Add(1);
        myList.Add(5);
        myList.Insert(1, 3);
        Debug.Log("¬ыполнили команды Add и Insert");
        for (int i = 0; i < myList.Count; ++i)
        {
            Debug.Log(myList[i]);
        }

        myList.Capacity = 4;
        myList.Remove(3);
        myList.RemoveAt(0);

        Debug.Log("¬ыполнили команды Remove и RemoveAt");
        for (int i = 0; i < myList.Count; ++i)
        {
            Debug.Log(myList[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
