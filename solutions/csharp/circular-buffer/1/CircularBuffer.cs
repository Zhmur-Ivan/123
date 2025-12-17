using System;

public class CircularBuffer<T>
{
    private readonly T[] _buffer;
    private int _head;   // індекс найстарішого елемента (звідси читаємо)
    private int _tail;   // індекс, куди будемо записувати наступний елемент
    private int _count;  // скільки елементів зараз у буфері

    public CircularBuffer(int capacity)
    {
        if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));
        _buffer = new T[capacity];
        _head = 0;
        _tail = 0;
        _count = 0;
    }

    public T Read()
    {
        if (_count == 0)
            throw new InvalidOperationException("Buffer is empty.");

        T value = _buffer[_head];
        _head = NextIndex(_head);
        _count--;
        return value;
    }

    public void Write(T value)
    {
        if (_count == _buffer.Length)
            throw new InvalidOperationException("Buffer is full.");

        _buffer[_tail] = value;
        _tail = NextIndex(_tail);
        _count++;
    }

    public void Overwrite(T value)
    {
        if (_count == _buffer.Length)
        {
            // Буфер повний: перезаписуємо найстаріший елемент,
            // тобто зсуваємо head вперед (викидаємо "старий" слот).
            _buffer[_tail] = value;
            _tail = NextIndex(_tail);
            _head = _tail; // або: _head = NextIndex(_head) (див. примітку нижче)
        }
        else
        {
            Write(value);
        }
    }

    public void Clear()
    {
        _head = 0;
        _tail = 0;
        _count = 0;
    }

    private int NextIndex(int index) => (index + 1) % _buffer.Length;
}
