using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WszystkieZadania
{
	class StreamEnumerable<T> : IEnumerable<T>, IEnumerator<T>
	{
		private StreamReader _sr;

		public StreamEnumerable(StreamReader sr)
		{
			_sr = sr;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return this;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public bool MoveNext()
		{

				MessageBox.Show("Loaded: " + Load<Student>()?.Imie);
				return true;
		}

		public void Reset()
		{
			_sr.DiscardBufferedData();
		}

		public T Current { get; }

		object IEnumerator.Current => Current;

		public void Dispose()
		{
			_sr.Close();
			_sr.Dispose();
		}

		private T Load<T>() where T : new()
		{
			T obj = default(T);
			Type type = null;
			PropertyInfo property = null;

			while (!_sr.EndOfStream)
			{
				var ln = _sr.ReadLine();
				if (ln == "[[]]")
					return obj;
				else if (ln.StartsWith("[["))
				{
					type = Type.GetType(ln.Trim('[', ']'));
					if (typeof(T).IsAssignableFrom(type))
						obj = (T) Activator.CreateInstance(type);
				}
				else if (ln.StartsWith("[") && obj != null)
					property = type.GetProperty(ln.Trim('[', ']'));
				else if (obj != null && property != null)
					property.SetValue(obj, Convert.ChangeType(ln, property.PropertyType));
			}

			return default(T);
		}
	}
}
