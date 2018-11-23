using UnityEngine;
using System.Collections;

namespace PE2D
{
	/// <summary>
	/// Simplified version of the circular buffer found at: http://geekswithblogs.net/blackrob/archive/2014/09/01/circular-buffer-in-c.aspx.
	/// Generic storage, used to store particles.
	/// </summary>
	public class CircularArray<T>
	{
		private int start;
	
		/// <summary>
		/// Pointer to first entry in array. Note this will not usually be 0.
		/// </summary>
		/// <value>The start.</value>
		public int Start {
			get { return start; }
			set { start = value % list.Length; }
		}
	
		/// <summary>
		/// Current object count.
		/// </summary>
		/// <value>The count.</value>
		public int Count { get; set; }

		/// <summary>
		/// Total object count.
		/// </summary>
		/// <value>The capacity.</value>
		public int Capacity { get { return list.Length; } }

		/// <summary>
		/// Gets a value indicating whether this <see cref="PE2D.CircularArray`1"/> has reached capacity.
		/// </summary>
		/// <value><c>true</c> if reached capacity; otherwise, <c>false</c>.</value>
		public bool reachedCapacity {
			get {
				return Count == Capacity;
			}
		}

		private T[] list;
	
		/// <summary>
		/// Initializes a new instance of the <see cref="PE2D.CircularArray`1"/> class.
		/// </summary>
		/// <param name="capacity">Capacity.</param>
		public CircularArray (int capacity)
		{
			list = new T[capacity];
		}
	
		/// <summary>
		/// Gets or sets the <see cref="PE2D.CircularArray`1"/> with the specified i.
		/// </summary>
		/// <param name="i">The index.</param>
		public T this [int i] {
			get { return list [(start + i) % list.Length]; }
			set { list [(start + i) % list.Length] = value; }
		}
	}
}