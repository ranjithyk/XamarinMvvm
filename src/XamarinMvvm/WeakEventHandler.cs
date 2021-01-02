using System;
using System.Reflection;
using System.Threading.Tasks;

namespace XamarinMvvm
{
	public delegate Task ActionAsync();

	public sealed class WeakEventHandler<TEventArgs> where TEventArgs : EventArgs
	{
		private readonly WeakReference _targetReference;
		private readonly MethodInfo _method;

		public WeakEventHandler(EventHandler<TEventArgs> callback)
		{
			_method = callback.GetMethodInfo();
			_targetReference = new WeakReference(callback.Target, true);
		}

		public void Handler(object sender, TEventArgs e)
		{
			var target = _targetReference.Target;
			if (target != null)
			{
                ((Action<object, TEventArgs>)_method.CreateDelegate(typeof(Action<object, TEventArgs>), target))?.Invoke(sender, e);
            }
		}
	}
	public sealed class AsyncWeakEventHandler<TEventArgs> where TEventArgs : EventArgs
	{
		private readonly WeakReference _targetReference;
		private readonly MethodInfo _method;

		public AsyncWeakEventHandler(ActionAsync callback)
		{
			_method = callback.GetMethodInfo();
			_targetReference = new WeakReference(callback.Target, true);
		}

		public void Handler(object sender, TEventArgs e)
		{
			var target = _targetReference.Target;
			if (target != null)
			{
				((Action<object, TEventArgs>)_method.CreateDelegate(typeof(Action<object, TEventArgs>), target))?.Invoke(sender, e);
			}
		}
	}
}